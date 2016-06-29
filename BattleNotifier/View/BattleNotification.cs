using System;
using BattleNotifier.Model;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Printing;
using BattleNotifier.Utils;
using System.Diagnostics;
using BattleNotifier.Controller;
using System.Drawing;

namespace BattleNotifier.View
{
#if DEBUG
    public partial class BattleNotification : MiddleClass
#else
    public partial class BattleNotification : BaseNotification
#endif
    {
        public bool IsPrinting { get; set; }
        private bool transparentStyle = false;
        private bool showToolTip = true;
        private string fullAttributesText;
        private int maxAttributesLength = 70;

        public BattleNotification(Battle battle, double timeLeft, int startHeight, BattleNotificationSettings settings)
            : base(settings, battle.Duration)
        {
            InitializeComponent();

            InitializeBattleTimer(timeLeft);
            SetupDialogLocation(settings.Basic.DisplayScreen, startHeight);

            SetupControls(battle);

            if (settings.General.TransparentStyle)
                SetupOutlineLabels();

            if (settings.General.HidePrintMap)
            {
                PrintMapButton.Visible = false;
                MapCheckBox.Location = new Point(PrintMapButton.Location.X - (MapCheckBox.Width - PrintMapButton.Width), MapCheckBox.Location.Y);
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

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (!closing)
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

        private void BattleNotification_MouseDown(object sender, MouseEventArgs e)
        {
            MaintainShown = true;
        }

        #region BaseNotification implementation

        protected override string GetCountdownBattleEndedText()
        {
            return "Finished";
        }

        protected override void SetCountdownText(string countdownText)
        {
            if (transparentStyle)
                CountdownOutlineLabel.Text = countdownText;
            else
                CountdownLabel.Text = countdownText;
        }

        protected override void CloseFormParticulars()
        {
        }

        #endregion

        #region Labels

        private void SetupOutlineLabels()
        {
            transparentStyle = true;
            FormBorderStyle = FormBorderStyle.None;
            Height += 15;

            MinimizeButton.Visible = true;
            CloseButton.Visible = true;
            BackColor = Color.Gray;
            TransparencyKey = Color.Gray;
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

        #endregion

        #region Print Map

        private void PrintMapButton_Click(object sender, EventArgs e)
        {
            MaintainShown = true;
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

        #endregion
    }
}
