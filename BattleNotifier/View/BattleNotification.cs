using System;
using BattleNotifier.Model;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Printing;
using BattleNotifier.Utils;
using System.Diagnostics;
using System.Reflection;
using BattleNotifier.Controller;
using System.Drawing;

namespace BattleNotifier.View
{
    public partial class BattleNotification : Form
    {
        private int battleDuration;
        private int countdown;
        private bool showToolTip = true;
        private string fullAttributesText;
        private int maxAttributesLength = 70;
        public BattleNotification() { }
        // TODO hacer que se pueda mantener abierto.
        public BattleNotification(Battle battle, int timeLeft, BattleNotificationSettings settings)
        {
            InitializeComponent();
            SetupDialogLocation();
            SetupControls(battle);

            battleDuration = battle.Duration;

            if (timeLeft > 0)
                StartBattleCountdown(timeLeft);

            if (settings.General.TransparentStyle)
            {
                MinimizeButton.Visible = true;
                CloseButton.Visible = true;
                BackColor = Color.Gray;
                this.TransparencyKey = Color.Gray;
                Height += 20;
                FormBorderStyle = FormBorderStyle.None;
            }
        }

        private delegate void BlankDelegate();
        public void CloseForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new BlankDelegate(this.CloseForm));
            }
            else
            {
                this.Close();
            }
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
        }

        private void SetupDialogLocation()
        {
            StartPosition = FormStartPosition.Manual;
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            Left = screenWidth - this.Width;
            Top = screenHeight - this.Height;
        }

        private void PrintMapButton_Click(object sender, EventArgs e)
        {
            if (NotificationsController.Instance.Map != null)
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
            e.Graphics.DrawImage(NotificationsController.Instance.Map, e.MarginBounds);
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
            NotificationsController.Instance.BattleNotificationClosed();
            this.Dispose();
        }

        private void MapCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            NotificationsController.Instance.BattleNotificationMapPressed();
        }

        private void HeadlineLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Send the URL to the operating system.
            Process.Start(e.Link.LinkData as string);
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
