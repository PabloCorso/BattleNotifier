using System;
using BattleNotifier.Model;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Printing;
using BattleNotifier.Utils;
using System.Diagnostics;
using BattleNotifier.Controller;
using System.Drawing;
using Utils;

namespace BattleNotifier.View
{
    public partial class BattleNotification : BaseNotification
    {
        public bool IsPrinting { get; set; }
        private Timer timer;
        private bool transparentStyle = false;
        private int battleDuration;
        private int countdown;
        private bool showToolTip = true;
        private string fullAttributesText;
        private int maxAttributesLength = 70;
        public BattleNotification() { }

        public BattleNotification(Battle battle, double timeLeft, BattleNotificationSettings settings)
            : base(settings)
        {
            InitializeComponent();
            SetupDialogLocation(settings.Basic.DisplayScreen);
            SetupControls(battle);
            if (settings.General.TransparentStyle)
                SetupOutlineLabels();

            battleDuration = battle.Duration;

            if (timeLeft > 0)
                StartBattleCountdown(Convert.ToInt32(timeLeft));
            else
                CountdownLabel.Text = GetCountdownDisplayText(Convert.ToInt32(timeLeft)) + " / " + battleDuration + ":00";

            if (settings.General.HidePrintMap)
            {
                PrintMapButton.Visible = false;
                MapCheckBox.Location = new Point(PrintMapButton.Location.X - (MapCheckBox.Width - PrintMapButton.Width), MapCheckBox.Location.Y);
            }
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        const int WS_MINIMIZEBOX = 0x20000;
        const int CS_DBLCLKS = 0x8;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }

        private void SetupOutlineLabels()
        {
            transparentStyle = true;
            FormBorderStyle = FormBorderStyle.None;
            Height += 15;

            MinimizeButton.Visible = true;
            CloseButton.Visible = true;
            BackColor = Color.Gray;
            this.TransparencyKey = Color.Gray;
            CloseButton.BackColor = Color.Gray;
            MinimizeButton.BackColor = Color.Gray;
            PrintMapButton.BackColor = Color.Gray;

            HeadlineOutlineLabel.Text = HeadlineLinkLabel.Text;
            HeadlineOutlineLabel.Visible = true;
            HeadlineLinkLabel.Visible = false;

            BattleTypeOutlineLabel.Text = BattleTypeLabel.Text;
            BattleTypeOutlineLabel.Visible = true;
            BattleTypeLabel.Visible = false;

            DurationOutlineLabel.Text = DurationLabel.Text;
            DurationOutlineLabel.Visible = true;
            DurationLabel.Visible = false;

            CountdownOutlineLabel.Visible = true;
            CountdownLabel.Visible = false;

            AttributesOutlineLabel.Visible = true;
            AttributesLabel.Visible = false;
        }

        private void StartBattleCountdown(int startTime)
        {
            countdown = startTime;
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(BattleCountdownTimer_Tick);
            BattleCountdownTimer_Tick(null, null);
            timer.Start();
        }

        private void BattleCountdownTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate () { BattleCountdownTimer_Tick(sender, e); }));
                }
                else
                {
                    if (countdown > battleDuration * 60)
                        CountdownLabel.Text = "Starts in " + GetCountdownDisplayText(countdown - battleDuration * 60);
                    else
                    {
                        if (countdown == 0)
                            timer.Stop();
                        TimeSpan time = new TimeSpan(0, 0, countdown);
                        string display = "(" + GetCountdownDisplayText(countdown) + ")";
                        if (transparentStyle)
                            CountdownOutlineLabel.Text = display;
                        else
                            CountdownLabel.Text = display;
                    }

                    countdown--;
                }
            }
            catch (ObjectDisposedException ex)
            {
                Logger.Log(500, ex);
                // Timer ticked while form being disposed. Fixed using forms timer.
            }
        }

        private string GetCountdownDisplayText(int seconds)
        {
            if (seconds <= 0)
                return "Finished";

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

        private void SetupDialogLocation(int displayScreen)
        {
            StartPosition = FormStartPosition.Manual;
            Screen screen = Screen.PrimaryScreen;
            if (displayScreen <= Screen.AllScreens.Length && displayScreen > 0)
                screen = Screen.AllScreens[displayScreen - 1];
            int screenWidth = screen.WorkingArea.Width;
            int screenHeight = screen.WorkingArea.Height;
            Left = screen.WorkingArea.Left + screenWidth - this.Width;
            Top = screenHeight - this.Height;
        }

        private void PrintMapButton_Click(object sender, EventArgs e)
        {
            if (NotificationsController.Instance.Map != null)
            {
                IsPrinting = true;

                PrintMapDialog.AllowSomePages = true;
                PrintMapDialog.AllowSelection = false;
                PrintDocument printDoc = new PrintDocument();
                DialogResult result = PrintMapDialog.ShowDialog();

                // If the result is OK then print the document. 
                if (result == DialogResult.OK)
                {
                    PrintMapDocument.Print();
                }

                IsPrinting = false;
            }
        }

        private void PrintMapDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Image map = NotificationsController.Instance.Map;
            map = map.ChangeColor(Color.FromArgb(48, 112, 212), Color.White);
            map = map.ChangeColor(Color.FromArgb(23, 18, 60), Color.LightGray);
            map = map.ChangeColor(Color.Gray, new List<Color>() { Color.White, Color.LightGray });
            e.Graphics.DrawImage(map, 0, 0);
            e.HasMorePages = false;
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


        protected override void CloseFormParticulars()
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Tick -= BattleCountdownTimer_Tick;
                timer = null;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            NotificationsController.Instance.EndBattleNotification();
        }

        private void HeadlineOutlineLabel_Click(object sender, EventArgs e)
        {
            string link = HeadlineLinkLabel.Links[0].LinkData.ToString();
            System.Diagnostics.Process.Start(link);
        }

        private void MinimizeButton_MouseMove(object sender, MouseEventArgs e)
        {
            MinimizeButton.Focus();
        }
    }
}
