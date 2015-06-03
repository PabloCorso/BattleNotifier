using BattleNotifier.Controller;
using BattleNotifier.Controller.ViewInterface;
using BattleNotifier.Model;
using BattleNotifier.Utils;
using System;
using System.Text;
using System.Windows.Forms;
using Settings = BattleNotifier.Properties.Settings;

namespace BattleNotifier.View
{
    public partial class Main : Form, IMain
    {
        private BattleNotifierController battleNotifier;
        private MainPanel mainPanel;
        private SettingsPanel settingsPanel;

        private ContextMenu contextMenu;
        private MenuItem exitMenuItem;
        private MenuItem stopMenuItem;
        private MenuItem startMenuItem;

        public Main()
        {
            InitializeComponent();
            InitializeNotifyIcon();
            CenterToScreen();

            // Initialize battle controller.
            battleNotifier = new BattleNotifierController(this);

            // Initialize Main Panel.
            mainPanel = new MainPanel(battleNotifier);
            BackgroundPanel.Controls.Add(mainPanel);

            settingsPanel = new SettingsPanel();
            NavigateHomeButton.Visible = false;

            LoadUserSettings();
        }

        private void NavigateToCurrentBattleButton_MouseEnter(object sender, EventArgs e)
        {
            NavigateToCurrentBattleButton.Text = "⋀ Current Battle ⋀";
        }

        private void NavigateToCurrentBattleButton_MouseLeave(object sender, EventArgs e)
        {
            NavigateToCurrentBattleButton.Text = "∧ Current Battle ∧";
        }

        #region IMain implementation
        public IMainPanel MainPanel
        {
            get { return this.mainPanel; }
        }

        public BattleNotificationSettings GetNotificationSettings() 
        {
            return MainPanel.BattleNotificationSettings;
        }
        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.R))
            {
                battleNotifier.RestartNotifying();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void DisposeBattleNotification()
        {
            if (battleNotifier.IsNotifyingBattle)
                battleNotifier.StopNotifying();
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            // When minimized hide from task bar and show NotifyIcon.
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                NotifyIcon.Visible = true;
                NotifyIcon.ShowBalloonTip(1000);
                UpdateTrayNotifyIcon();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            SaveUserSettings();
            ShutDownNotifyIcon();
            base.OnClosed(e);
        }

        #region NotifyIcon
        private void InitializeNotifyIcon()
        {
            NotifyIcon.Visible = false;

            contextMenu = new System.Windows.Forms.ContextMenu();
            exitMenuItem = new System.Windows.Forms.MenuItem();
            stopMenuItem = new System.Windows.Forms.MenuItem();
            startMenuItem = new System.Windows.Forms.MenuItem();

            // Initialize StopMenuItem
            stopMenuItem.Index = 0;
            stopMenuItem.Text = "Stop";
            stopMenuItem.Click += new System.EventHandler(StopMenuItem_Click);

            // Initialize StartMenuItem
            startMenuItem.Index = 0;
            startMenuItem.Text = "Start";
            startMenuItem.Click += new System.EventHandler(StartMenuItem_Click);

            // Initialize ExitMenuItem
            exitMenuItem.Index = 1;
            exitMenuItem.Text = "Exit";
            exitMenuItem.Click += new System.EventHandler(ExitMenuItem_Click);

            // Set Start and Exit as startup options.
            contextMenu.MenuItems.Add(startMenuItem);
            contextMenu.MenuItems.Add(exitMenuItem);

            // The ContextMenu property sets the menu that will 
            // appear when the systray icon is right clicked.
            NotifyIcon.ContextMenu = contextMenu;
        }

        private void StopMenuItem_Click(object sender, EventArgs e)
        {
            if (battleNotifier.IsNotifyingBattle)
                mainPanel.NotificateBattles();
        }
        private void StartMenuItem_Click(object sender, EventArgs e)
        {
            if (!battleNotifier.IsNotifyingBattle)
                mainPanel.NotificateBattles();
        }
        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            // Show the form when the user double clicks on the notify icon. 
            // Set the WindowState to normal if the form is minimized. 
            if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;

            ShowInTaskbar = true;
            NotifyIcon.Visible = false;

            // Activate the form. 
            this.Activate();
        }

        private void ShutDownNotifyIcon()
        {
            try
            {
                if (NotifyIcon != null)
                {
                    NotifyIcon.ContextMenu = null;
                    NotifyIcon.Visible = false;
                    NotifyIcon.Icon = null; // required to make icon disappear
                    NotifyIcon.Dispose();
                    NotifyIcon = null;
                }
            }
            catch (Exception)
            {
                // You cant handle the truth.
            }
        }
        private void NotifyIcon_MouseDown(object sender, MouseEventArgs e)
        {
            UpdateTrayNotifyIcon();
        }

        private void UpdateTrayNotifyIcon()
        {
            if (battleNotifier.IsNotifyingBattle)
            {
                contextMenu.MenuItems.Add(1, stopMenuItem);
                if (contextMenu.MenuItems.Contains(startMenuItem))
                    contextMenu.MenuItems.Remove(startMenuItem);
            }
            else
            {
                contextMenu.MenuItems.Add(1, startMenuItem);
                if (contextMenu.MenuItems.Contains(stopMenuItem))
                    contextMenu.MenuItems.Remove(stopMenuItem);
            }
        }

        #endregion

        #region User settings
        public void ResetUserSettings()
        {
            Settings.Default.Reset();
        }

        private void LoadUserSettings()
        {
            Settings settings = Settings.Default;
            mainPanel.PlaySoundCheckBox.Checked = settings.PlayNotificationSound;
            mainPanel.ShowBattleCheckBox.Checked = settings.ShowBattleDialog;
            mainPanel.ShowMapCheckBox.Checked = settings.ShowMapDialog;
            mainPanel.CloseDialogTimeCheckBox.Checked = settings.CloseDialogTime;
            mainPanel.CloseDialogNumericUpDown.Value = settings.DialogLifeSeconds;
            mainPanel.NotificationDurationTrackBar.Value = settings.NotificationDuration;
            mainPanel.SoundPath = settings.SoundPath;
            mainPanel.MapSizeDomainUpDown.SelectedIndex = settings.MapSize;

            string[] aux = settings.BattleTypes.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            for (int i = 0; i < aux.Length; i++)
            {
                if (!string.IsNullOrEmpty(aux[i]))
                    mainPanel.BattleTypesChListBox.Items.Add(aux[i].Substring(1), Convert.ToInt32(aux[i].Substring(0, 1)) == 1);
            }

            aux = settings.Designers.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            for (int i = 0; i < aux.Length; i++)
            {
                if (!string.IsNullOrEmpty(aux[i]))
                    mainPanel.DesignersChListBox.Items.Add(aux[i].Substring(1), Convert.ToInt32(aux[i].Substring(0, 1)) == 1);
            }

            aux = settings.BlackList.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            for (int i = 0; i < aux.Length; i++)
            {
                if (!string.IsNullOrEmpty(aux[i]))
                    mainPanel.BlackListChListBox.Items.Add(aux[i].Substring(1), Convert.ToInt32(aux[i].Substring(0, 1)) == 1);
            }

            aux = settings.AutocompleteKuskis.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            for (int i = 0; i < aux.Length; i++)
            {
                if (!string.IsNullOrEmpty(aux[i]))
                    mainPanel.AutocompleteKuskisList.Add(aux[i]);
            }
        }

        private void SaveUserSettings()
        {
            //Main panel user settings.
            Settings settings = Settings.Default;
            settings.PlayNotificationSound = mainPanel.PlaySoundCheckBox.Checked;
            settings.ShowBattleDialog = mainPanel.ShowBattleCheckBox.Checked;
            settings.ShowMapDialog = mainPanel.ShowMapCheckBox.Checked;
            settings.CloseDialogTime = mainPanel.CloseDialogTimeCheckBox.Checked;
            settings.DialogLifeSeconds = mainPanel.CloseDialogNumericUpDown.Value;
            settings.NotificationDuration = mainPanel.NotificationDurationTrackBar.Value;
            settings.SoundPath = mainPanel.SoundPath;
            settings.MapSize = mainPanel.MapSizeDomainUpDown.SelectedIndex;

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < mainPanel.BattleTypesChListBox.Items.Count; i++)
            {
                bool isChecked = mainPanel.BattleTypesChListBox.GetItemChecked(i);
                string value = ChListExtensions.GetText(mainPanel.BattleTypesChListBox, i);
                builder.AppendLine((isChecked ? "1" : "0") + value);
            }
            settings.BattleTypes = builder.ToString();

            builder = new StringBuilder();
            for (int i = 0; i < mainPanel.DesignersChListBox.Items.Count; i++)
            {
                bool isChecked = mainPanel.DesignersChListBox.GetItemChecked(i);
                string value = ChListExtensions.GetText(mainPanel.DesignersChListBox, i);
                builder.AppendLine((isChecked ? "1" : "0") + value);
            }
            settings.Designers = builder.ToString();

            builder = new StringBuilder();
            for (int i = 0; i < mainPanel.BlackListChListBox.Items.Count; i++)
            {
                bool isChecked = mainPanel.BlackListChListBox.GetItemChecked(i);
                string value = ChListExtensions.GetText(mainPanel.BlackListChListBox, i);
                builder.AppendLine((isChecked ? "1" : "0") + value);
            }
            settings.BlackList = builder.ToString();

            builder = new StringBuilder();
            for (int i = 0; i < mainPanel.AutocompleteKuskisList.Count; i++)
                builder.AppendLine(mainPanel.AutocompleteKuskisList[i]);
            settings.AutocompleteKuskis = builder.ToString();

            settings.Save();
        }
        #endregion

        private void NavigateToSettingsButton_Click(object sender, EventArgs e)
        {
            BackgroundPanel.Controls.Clear();
            BackgroundPanel.Controls.Add(settingsPanel);
            NavigateToSettingsButton.Visible = false;
            NavigateHomeButton.Visible = true;
        }

        private void NavigateHomeButton_Click(object sender, EventArgs e)
        {
            BackgroundPanel.Controls.Clear();
            BackgroundPanel.Controls.Add(mainPanel);
            NavigateToSettingsButton.Visible = true;
            NavigateHomeButton.Visible = false;
        }
    }
}
