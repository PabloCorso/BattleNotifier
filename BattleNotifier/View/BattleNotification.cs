using System;
using System.Media;
using BattleNotifier.Model;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using BattleNotifier.Utils;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace BattleNotifier.View
{
    public partial class BattleNotification : TransDialog
    {
        private MapNotification mn;
        private WMPLib.WindowsMediaPlayer player;
        private int battleDuration;
        private string mapUrl;
        private Image map;
        private int countdown;
        private bool showToolTip = true;
        private string fullAttributesText;
        private int maxAttributesLength = 70;

        // TODO hacer que se pueda mantener abierto.
        public BattleNotification(Battle battle, int timeLeft, BattleNotificationSettings settings)
        {
            InitializeComponent();
            SetupDialogLocation();
            SetupControls(battle);

            if (settings.LifeSeconds > 0)
            {
                BattleNotificationTimer.Interval = settings.LifeSeconds * 1000;
                BattleNotificationTimer.Enabled = true;
            }

            battleDuration = battle.Duration;
            bool mapLoaded = true;
            try
            {
                map = WebRequestHelper.GetImageFromUrl(mapUrl);
            }
            catch (Exception)
            {
                mapLoaded = false;
            }

            if (mapLoaded && settings.ShowMapDialog)
                ShowMapDialog();
            if (timeLeft > 0)
                StartBattleCountdown(timeLeft);
            if (settings.PlaySound)
                if (!string.IsNullOrEmpty(settings.SoundPath) && File.Exists(settings.SoundPath))
                    PlaySound(settings.SoundPath);
                else
                    PlayDefaultSound();
        }

        public int Interval
        {
            get { return this.BattleNotificationTimer.Interval; }
            set { this.BattleNotificationTimer.Interval = value; }
        }

        public void EndNotification()
        {
            this.Close();
        }

        private void ShowMapDialog()
        {
            try
            {
                int newWidth = 320;
                int aux = (320*100) / map.Width; 
                int newHeight = (aux*map.Height) / 100 ;
                Bitmap newImage = new Bitmap(newWidth, newHeight);
                using (Graphics gr = Graphics.FromImage(newImage))
                {
                    gr.SmoothingMode = SmoothingMode.HighQuality;
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    gr.DrawImage(this.map, new Rectangle(0, 0, newWidth, newHeight));
                }

                // Initialize map notification
                mn = new MapNotification(newImage);
                mn.StartPosition = FormStartPosition.Manual;
                int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
                int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
                mn.Left = screenWidth - mn.Width;
                mn.Top = screenHeight - mn.Height - this.Height - 20;

                mn.Show();
            }
            catch (Exception) 
            {
                // Could not show map dialog.
            }
        }

        private void PlaySound(string path)
        {
            try
            {
                player = new WMPLib.WindowsMediaPlayer();
                player.URL = path;
                player.controls.play();
            }
            catch (Exception)
            {
                PlayDefaultSound();
            }
        }

        private void PlayDefaultSound()
        {
            SoundPlayer sound = new SoundPlayer(Properties.Resources.smb_1_up);
            sound.Play();
        }

        private void StartBattleCountdown(int startTime)
        {
            countdown = startTime;
            BattleCountdownTimer_Tick(null, null);
            BattleCountdownTimer.Start();
        }

        private void BattleCountdownTimer_Tick(object sender, EventArgs e)
        {
            if (countdown > battleDuration * 60)
                CountdownLabel.Text = "Starts in " + GetCountdownDisplayText(countdown - battleDuration * 60);
            else
            {
                if (countdown == 0)
                    BattleCountdownTimer.Stop();
                TimeSpan time = new TimeSpan(0, 0, countdown);
                CountdownLabel.Text = "(" + GetCountdownDisplayText(countdown) + ")";
            }

            countdown--;
        }

        private string GetCountdownDisplayText(int seconds)
        {
            if (seconds <= 0)
                return "Battle finished";

            TimeSpan time = new TimeSpan(0, 0, seconds);
            string hours = time.Hours == 0 ? "" : time.Hours + ":";
            string mins = time.Hours > 0 && time.Minutes < 10 ? "0" + time.Minutes : time.Minutes.ToString();
            string secs = time.Seconds < 10 ? "0" + time.Seconds : time.Seconds.ToString();

            return hours + mins + ":" + secs;
        }

        private void SetupControls(Battle battle)
        {
            HeadlineLinkLabel.Text = battle.Name + " by " + battle.Desginer;
            if (HeadlineLinkLabel.Width + HeadlineLinkLabel.Location.X > this.Width - HeadlineLinkLabel.Location.X * 2)
                HeadlineLinkLabel.Text = HeadlineLinkLabel.Text.Substring(0, 24) + "...";
            LinkLabel.Link battleLink = new LinkLabel.Link();
            battleLink.LinkData = battle.Url;
            HeadlineLinkLabel.Links.Add(battleLink);

            BattleTypeLabel.Text = EnumExtensions.GetDescription(battle.Type) + " battle";

            List<string> attributes = new List<string>();
            foreach (BattleAttribute att in EnumExtensions.GetFlags(battle.Attributes))
            {
                attributes.Add(EnumExtensions.GetDescription(att));
            }
            fullAttributesText = Util.FirstCharToUpper(string.Join(", ", attributes).ToLower());
            if (fullAttributesText.Length > maxAttributesLength)
                AttributesLabel.Text = fullAttributesText.Substring(0, maxAttributesLength) + "...";
            else
                AttributesLabel.Text = fullAttributesText;

            DurationLabel.Text = battle.Duration + " mins";

            this.mapUrl = battle.MapUrl;
        }

        private void SetupDialogLocation()
        {
            StartPosition = FormStartPosition.Manual;
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            Left = screenWidth - this.Width;
            Top = screenHeight - this.Height;
        }

        private void BattleNotificationTimer_Tick(object sender, EventArgs e)
        {
            EndNotification();
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        private void PrintMapButton_Click(object sender, EventArgs e)
        {
            if (map != null)
            {
                PrintMapDialog.AllowSomePages = true;
                PrintMapDialog.AllowSelection = false;

                DialogResult result = PrintMapDialog.ShowDialog();

                // If the result is OK then print the document. 
                if (result == DialogResult.OK)
                {
                    PrintMapDocument.Print();
                }
            }
        }

        private void PrintMapDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(map, e.MarginBounds);
        }

        private void AttributesLabel_Click(object sender, EventArgs e)
        {
            if (showToolTip && fullAttributesText.Length > maxAttributesLength)
            {
                AttributesToolTip.SetToolTip(AttributesLabel, fullAttributesText);
                showToolTip = false;
            }
            else
            {
                AttributesToolTip.RemoveAll();
                showToolTip = true;
            }
        }

        private void BattleNotification_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (player != null && player.controls != null)
                    player.controls.stop();
            }
            catch (Exception)
            {
                // Nothing happend here, no one saw anything. Get back to work.
            }

            if (this.mn != null)
                this.mn.EndNotification();
            this.Dispose();
        }

        private void MapCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (mn == null)
                ShowMapDialog();
            else
            {
                mn.EndNotification();
                mn = null;
            }
        }

        private void HeadlineLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Send the URL to the operating system.
            Process.Start(e.Link.LinkData as string);
        }
    }
}
