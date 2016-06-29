using System;
using System.Windows.Forms;
using BattleNotifier.Controller.ViewInterface;
using BattleNotifier.Controller;
using System.Collections.Generic;
using BattleNotifier.Utils;
using System.Threading.Tasks;

namespace BattleNotifier.View
{
    public partial class MainPanel : UserControl, IMainPanel
    {
        public List<string> AutocompleteKuskisList { get; set; }

        private BattleNotifierController battleNotifier;
        private About about;
        private const string playSymbol = "▶";
        private const string stopSymbol = "■";
        private const string allDesigners = "All designers";
        private const string allBattleTypes = "All battle types";

        public MainPanel()
        {
            InitializeComponent();
            battleNotifier = BattleNotifierController.Instance;
            about = new About();

            AutocompleteKuskisList = new List<string>();
            InitializeHelpDescriptions();
        }

        public void MainPanel_Load(object sender, EventArgs e)
        {
            InitializeSearchDesignerTextBox();

            UpdateErrorLabel();
        }

        private void InitializeSearchDesignerTextBox()
        {
            UserSettings.LoadAutocompleteKuskis();
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
        }

        private void MainPanel_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        #region IMainPanel implementation

        public bool TimerStoppedNotifications
        {
            get { return !Timer.Enabled && NotificationDurationTrackBar.Value != 0; }
        }

        #endregion

        #region Helping descriptions & About

        private void AboutButton_Click(object sender, EventArgs e)
        {
            if (!about.Visible)
                about.ShowDialog();
        }

        private void InitializeHelpDescriptions()
        {
            SearchDesignerTextBox.MouseEnter += ShowHelpDescription;
            SearchDesignerTextBox.MouseLeave += ClearHelpDescription;
            DesignersChListBox.MouseEnter += ShowHelpDescription;
            DesignersChListBox.MouseLeave += ClearHelpDescription;
            StartNotificationButton.MouseEnter += ShowHelpDescription;
            StartNotificationButton.MouseLeave += ClearHelpDescription;
            CloseDialogTimeCheckBox.MouseEnter += ShowHelpDescription;
            CloseDialogTimeCheckBox.MouseLeave += ClearHelpDescription;
            ShowMapCheckBox.MouseEnter += ShowHelpDescription;
            ShowMapCheckBox.MouseLeave += ClearHelpDescription;
            NotificationDurationTrackBar.MouseEnter += ShowHelpDescription;
            NotificationDurationTrackBar.MouseLeave += ClearHelpDescription;
            ShowBattleCheckBox.MouseEnter += ShowHelpDescription;
            ShowBattleCheckBox.MouseLeave += ClearHelpDescription;
            PlaySoundCheckBox.MouseEnter += ShowHelpDescription;
            PlaySoundCheckBox.MouseLeave += ClearHelpDescription;
            BlackListChListBox.MouseEnter += ShowHelpDescription;
            BlackListChListBox.MouseLeave += ClearHelpDescription;
            BattleTypesChListBox.MouseEnter += ShowHelpDescription;
            BattleTypesChListBox.MouseLeave += ClearHelpDescription;
            DisplayScreenLabel.MouseEnter += ShowHelpDescription;
            DisplayScreenLabel.MouseLeave += ClearHelpDescription;
            DisplayScreenButton.MouseEnter += ShowHelpDescription;
            DisplayScreenButton.MouseLeave += ClearHelpDescription;
            ShowCurrentButton.MouseEnter += ShowHelpDescription;
            ShowCurrentButton.MouseLeave += ClearHelpDescription;
            ShowCurrentHotkeyTextBox.MouseEnter += ShowHelpDescription;
            ShowCurrentHotkeyTextBox.MouseLeave += ClearHelpDescription;
        }

        private void ShowHelpDescription(object sender, EventArgs e)
        {
            battleNotifier.MainView.ShowHelpDescription(ToolTip.GetToolTip((Control)sender).ToString());
        }

        private void ClearHelpDescription(object sender, EventArgs e)
        {
            battleNotifier.MainView.ClearHelpDescription();
        }

        #endregion

        #region Notificate

        /// <summary>
        /// Restarts battle notifications if notificatiosn are On.
        /// Call when any settings change, to notify the controller instantly.
        /// </summary>
        private void NotificationsSettingsModified()
        {
            if (battleNotifier.IsNotifyingBattle)
                battleNotifier.UpdateNotifying();
        }

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

        public void ReStartNotifying()
        {
            if (battleNotifier.IsNotifyingBattle)
            {
                battleNotifier.RestartNotifying();
            }
            else
            {
                NotificateBattles();
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

        #endregion

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

        #region Search designer methods

        private void SearchDesignerTextBox_Enter(object sender, EventArgs e)
        {

        }

        private void SearchDesignerTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !String.IsNullOrEmpty(SearchDesignerTextBox.Text.Trim()))
            {
                //AddDesignerButton.Focus();
                AddDesignerButton_Click(sender, e);
            }
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

        #region Notification basic settings

        private void ShowBattleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            NotificationsSettingsModified();
            UpdateErrorLabel();
        }

        private void ShowMapCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            NotificationsSettingsModified();
            UpdateErrorLabel();
        }

        private void PlaySoundCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            NotificationsSettingsModified();
            UpdateErrorLabel();
        }

        private void CloseDialogTimeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            NotificationsSettingsModified();
            bool test = CloseDialogTimeCheckBox.Checked;
        }

        private void DisplayScreenButton_Click(object sender, EventArgs e)
        {
            int currentScreen = Convert.ToInt32(DisplayScreenButton.Text);

            int screensCount = Screen.AllScreens.Length;

            if (currentScreen < screensCount)
                currentScreen++;
            else
                currentScreen = 1;

            DisplayScreenButton.Text = currentScreen.ToString();
        }

        private void ShowCurrentHotkeyTextBox_Enter(object sender, EventArgs e)
        {
            battleNotifier.MainView.UnregisterCurrentBattleHotkey();
        }

        private void ShowCurrentHotkeyTextBox_Leave(object sender, EventArgs e)
        {
            battleNotifier.MainView.RegisterCurrentBattleHotkey(ShowCurrentHotkeyTextBox.Hotkey, ShowCurrentHotkeyTextBox.HotkeyModifiers);
        }

        private void ShowCurrentButton_Click(object sender, EventArgs e)
        {
            NotificationsController.Instance.ShowCurrentBattleNotification(battleNotifier.MainView);
        }

        #endregion
    }
}
