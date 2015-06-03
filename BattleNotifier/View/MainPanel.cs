using System;
using System.Windows.Forms;
using BattleNotifier.Controller.ViewInterface;
using BattleNotifier.Controller;
using System.Collections.Generic;
using BattleNotifier.Model;
using BattleNotifier.Utils;

namespace BattleNotifier.View
{
    public partial class MainPanel : UserControl, IMainPanel
    {
        public string SoundPath { get; set; }
        public List<string> AutocompleteKuskisList { get; set; }

        private BattleNotifierController battleNotifier;
        private const string playSymbol = "▶";
        private const string stopSymbol = "■";
        private const string smallPlusSymbol = "+";
        private const string bigPlusSymbol = "＋";
        private const string allDesigners = "All designers";
        private const string allBattleTypes = "All battle types";

        public MainPanel(BattleNotifierController battleNotifier)
        {
            InitializeComponent();
            this.battleNotifier = battleNotifier;

            AutocompleteKuskisList = new List<string>();
            
#if DEBUG
            Simulate1Button.Visible = true;
            SimulateBattle2Button.Visible = true;
#endif
        }

        private void MainPanel_Load(object sender, EventArgs e)
        {
            var acs = SearchDesignerTextBox.AutoCompleteCustomSource;
            foreach (string kuski in AutocompleteKuskisList)
                if (!acs.Contains(kuski))
                    acs.Add(kuski);
            foreach (string kuski in DesignersChListBox.ToStringList())
                if (acs.Contains(kuski))
                    acs.Remove(kuski);
            foreach (string kuski in BlackListChListBox.ToStringList())
                if (acs.Contains(kuski))
                    acs.Remove(kuski);

            UpdateErrorLabel();
        }

        /// <summary>
        /// Restarts battle notifications if notificatiosn are On.
        /// Call when any settings change, to notify the controller instantly.
        /// </summary>
        private void NotificationsSettingsModified()
        {
            if(battleNotifier.IsNotifyingBattle)
                battleNotifier.UpdateNotifying();
        }

        #region IMainPanel implementation
        public bool TimerEnabled
        {
            get { return Timer.Enabled; }
        }

        public BattleNotificationSettings BattleNotificationSettings
        {
            get
            {
                BattleNotificationSettings settings = new BattleNotificationSettings();
                settings.Basic.ShowBattleDialog = ShowBattleCheckBox.Checked;
                settings.Basic.ShowMapDialog = ShowMapCheckBox.Checked;
                if (CloseDialogTimeCheckBox.Checked)
                    settings.Basic.LifeSeconds = Convert.ToInt32(CloseDialogNumericUpDown.Value);
                else
                    settings.Basic.LifeSeconds = 0;
                settings.Basic.PlaySound = PlaySoundCheckBox.Checked;
                settings.Basic.SoundPath = SoundPath;
                settings.Basic.MapSize = MapSizeDomainUpDown.SelectedIndex;

                return settings;
            }
        }
        #endregion

        public void NotificateBattles()
        {
            if (battleNotifier.IsNotifyingBattle)
            {
                Timer.Stop();
                battleNotifier.StopNotifying();
                NotificationDurationTrackBar.Enabled = true;
                UpdateStartNotificationButton();
            }
            else
            {
                if (GetDurationFromTrackBar() != 0)
                {
                    Timer.Interval = Convert.ToInt32(GetDurationFromTrackBar());
                    Timer.Start();
                }

                StartNotificationButton.Text = stopSymbol + " " + "Stop";
                NotificationDurationTrackBar.Enabled = false;
                battleNotifier.StartNotifying();
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            NotificateBattles();
        }

        private void StartNotificationButton_Click(object sender, EventArgs e)
        {
            NotificateBattles();
        }

        private void UpdateStartNotificationButton()
        {
            double hours = Util.MillisecondsToHours(GetDurationFromTrackBar());
            string displayText = playSymbol + " ";
            if (hours == 0)
                displayText += "Start";
            else if (hours < 1)
                displayText += hours * 60 + " minutes";
            else
                displayText += hours + (hours == 1 ? " hour" : " hours");

            StartNotificationButton.Text = displayText;
        }

        private void UpdateErrorLabel()
        {
            if (DesignersChListBox.HasCheckedItems() && BattleTypesChListBox.HasCheckedItems()
                && (ShowBattleCheckBox.Checked || ShowMapCheckBox.Checked || PlaySoundCheckBox.Checked))
                ErrorLabel.Visible = false;
            else
                ErrorLabel.Visible = true;
        }

        private void NotificationDurationTrackBar_ValueChanged(object sender, EventArgs e)
        {
            UpdateStartNotificationButton();
        }

        /// <summary>
        /// Get the duration wanted for program to notificate battles.
        /// </summary>
        /// <returns> Duration in milliseconds. </returns>
        private double GetDurationFromTrackBar()
        {
            int trackValue = this.NotificationDurationTrackBar.Value;
            double[] hours = { 0, 0.5, 1, 2, 3, 4, 5, 10, 15, 20, 24 };

            return hours[trackValue] * 1000 * 60 * 60;
        }

        private void ClearBattleTypesButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < BattleTypesChListBox.Items.Count; i++)
            {
                BattleTypesChListBox.SetItemChecked(i, false);
            }
        }

        private void Simulate1Button_Click(object sender, EventArgs e)
        {
            battleNotifier.SimulateBattleNotification1();
        }

        private void SimulateBattle2Button_Click(object sender, EventArgs e)
        {
            battleNotifier.SimulateBattleNotification2();
        }

        private void SetSoundButton_Click(object sender, EventArgs e)
        {
            SoundOpenFileDialog.ShowDialog();
            SoundPath = SoundOpenFileDialog.FileName;
        }

        private void MainPanel_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        #region Battle types list methods

        public bool HasAllBattleTypesChecked()
        {
            if (BattleTypesChListBox.Contains(allBattleTypes))
                return ChListExtensions.GetItemCheck(BattleTypesChListBox, allBattleTypes);
            else
                return false;
        }

        public List<string> CheckedBattleTypes
        {
            get
            {
                List<string> result = new List<string>();
                for (int i = 0; i < BattleTypesChListBox.Items.Count; i++)
                {
                    if (BattleTypesChListBox.GetItemChecked(i))
                        result.Add(BattleTypesChListBox.GetText(i));
                }

                return result;
            }
        }

        private void BattleTypesChListBox_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < BattleTypesChListBox.Items.Count; i++)
            {
                if (BattleTypesChListBox.GetItemRectangle(i).Contains(BattleTypesChListBox.PointToClient(MousePosition)))
                {
                    switch (BattleTypesChListBox.GetItemCheckState(i))
                    {
                        case CheckState.Checked:
                            BattleTypesChListBox.SetItemCheckState(i, CheckState.Unchecked);
                            break;
                        case CheckState.Indeterminate:
                        case CheckState.Unchecked:
                            BattleTypesChListBox.SetItemCheckState(i, CheckState.Checked);
                            break;
                    }
                }
            }

            UpdateErrorLabel();
            NotificationsSettingsModified();
        }

        #endregion

        #region Search button methods

        private void SearchDesignerTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !String.IsNullOrEmpty(SearchDesignerTextBox.Text.Trim()))
            {
                AddDesignerButton.Focus();
            }
        }

        private void AddDesignerButton_Enter(object sender, EventArgs e)
        {
            if (AddDesignerButton.Text.Equals(MainPanel.smallPlusSymbol))
                AddDesignerButton.Text = MainPanel.bigPlusSymbol;
        }

        private void AddDesignerButton_Leave(object sender, EventArgs e)
        {
            if (AddDesignerButton.Text.Equals(MainPanel.bigPlusSymbol))
                AddDesignerButton.Text = MainPanel.smallPlusSymbol;
        }

        private void AddDesignerButton_Click(object sender, EventArgs e)
        {
            string input = SearchDesignerTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(input))
            {
                input = GetOriginalNickname(input);
                if (!DesignersChListBox.Contains(input) && !BlackListChListBox.Contains(input))
                {
                    DesignersChListBox.AddOrderedFromBottom(input, true);
                    DesignersChListBox_ItemAdded();
                    SearchDesignerTextBox.Text = string.Empty;

                    if (!AutocompleteKuskisList.Contains(input))
                        AutocompleteKuskisList.Add(input);
                    SearchDesignerTextBox.AutoCompleteCustomSource.Remove(input);
                }
            }

            UpdateErrorLabel();
            NotificationsSettingsModified();
            this.ActiveControl = null;
        }

        private string GetOriginalNickname(string input)
        {
            foreach (string kuski in SearchDesignerTextBox.AutoCompleteCustomSource)
            {
                if (input.Equals(kuski, StringComparison.InvariantCultureIgnoreCase))
                    return kuski;
            }

            return input;
        }

        #endregion

        #region Designers lists methods

        public bool HasAllDesignersChecked()
        {
            if (DesignersChListBox.Contains(allDesigners))
                return ChListExtensions.GetItemCheck(DesignersChListBox, allDesigners);
            else
                return false;
        }

        public List<string> CheckedDesigners
        {
            get
            {
                return DesignersChListBox.CheckedStringList();
            }
        }

        public List<string> CheckedBlackList
        {
            get
            {
                return BlackListChListBox.CheckedStringList();
            }
        }

        private void BlackListChListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                for (int i = 0; i < BlackListChListBox.Items.Count; i++)
                {
                    if (BlackListChListBox.GetItemRectangle(i).Contains(BlackListChListBox.PointToClient(MousePosition)))
                        SearchDesignerTextBox.AutoCompleteCustomSource.Add(BlackListChListBox.GetText(i));
                }
            }

            ChListExtensions.DualChListMouseEvent(BlackListChListBox, DesignersChListBox, e, MousePosition);
            DesignersChListBox_ItemAdded();
            NotificationsSettingsModified();
        }

        private void DesignersChListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                for (int i = 0; i < DesignersChListBox.Items.Count; i++)
                {
                    if (DesignersChListBox.GetItemRectangle(i).Contains(DesignersChListBox.PointToClient(MousePosition)))
                        SearchDesignerTextBox.AutoCompleteCustomSource.Add(DesignersChListBox.GetText(i));
                }
            }

            ChListExtensions.DualChListMouseEvent(DesignersChListBox, BlackListChListBox, e, MousePosition, false);
            UpdateErrorLabel();
            NotificationsSettingsModified();
        }

        private void DesignersChListBox_ItemAdded()
        {
            ChListExtensions.MoveToTop(DesignersChListBox, allDesigners);
        }

        #endregion

        private void ShowBattleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            NotificationsSettingsModified();
        }

        private void ShowMapCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            NotificationsSettingsModified();
        }

        private void PlaySoundCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            NotificationsSettingsModified();
        }

        private void CloseDialogTimeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            NotificationsSettingsModified();
            bool test = CloseDialogTimeCheckBox.Checked;
        }
    }
}
