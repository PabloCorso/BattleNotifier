using BattleNotifier.Controller;
using BattleNotifier.Controller.ViewInterface;
using System;
using System.Windows.Forms;
using Utils;

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
        private MenuItem restartMenuItem;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public Main()
        {
            InitializeComponent();
            InitializeNotifyIcon();
            CenterToScreen();

            // Initialize battle controller.
            BattleNotifierController.InitializeBattleNotifierController(this);
            battleNotifier = BattleNotifierController.Instance;

            // Initialize Main Panel.
            mainPanel = new MainPanel();
            BackgroundPanel.Controls.Add(mainPanel);

            settingsPanel = new SettingsPanel();
            NavigateHomeButton.Visible = false;

            UserSettings.InitializeConfigStorageBroker(this, mainPanel, settingsPanel);

            UserSettings.Load();

            if (UserSettings.Instance.MustNotifyOnStartup())
                mainPanel.NotificateBattles();

            RegisterCurrentBattleHotkeyFromPanel();
        }

        private void RegisterCurrentBattleHotkeyFromPanel()
        {
            if (mainPanel.ShowCurrentHotkeyTextBox.Hotkey != Keys.None)
                RegisterCurrentBattleHotkey(mainPanel.ShowCurrentHotkeyTextBox.Hotkey, mainPanel.ShowCurrentHotkeyTextBox.HotkeyModifiers);
        }

        protected override void WndProc(ref Message msg)
        {
            base.WndProc(ref msg);

            if (msg.Msg == 0x0312)
            {
                NotificationsController.Instance.ShowCurrentBattleNotification(this);
            }
        }

        #region IMain implementation
        public IMainPanel MainPanel
        {
            get { return this.mainPanel; }
        }

        public void ShowBattleNotification(BattleNotification bn)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate() { ShowBattleNotification(bn); }));
            }
            else
            {
                bn.Show();
            }
        }

        public void ShowMapNotification(MapNotification mn)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate() { ShowMapNotification(mn); }));
            }
            else
            {
                mn.Show();
            }
        }

        public void ShowHelpDescription(string desc, int type = 1)
        {
            if (type == 1)
                HelpLabel1.Text = desc;
            else
                HelpLabel2.Text = desc;
        }

        public void ClearHelpDescription()
        {
            HelpLabel1.Text = string.Empty;
            HelpLabel2.Text = string.Empty;

        }

        public void RegisterCurrentBattleHotkey(Keys hotkey, Keys modifiers)
        {
            if (this.InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate() { RegisterCurrentBattleHotkey(hotkey, modifiers); }));
            }
            else
            {
                int modifiersValue = 0;
                if (modifiers.HasFlag(Keys.Control))
                    modifiersValue += (int)KeyModifier.Control;
                if (modifiers.HasFlag(Keys.Shift))
                    modifiersValue += (int)KeyModifier.Shift;
                if (modifiers.HasFlag(Keys.Alt))
                    modifiersValue += (int)KeyModifier.Alt;
                if (modifiers.HasFlag(Keys.LWin) || modifiers.HasFlag(Keys.RWin))
                    modifiersValue += (int)KeyModifier.WinKey;
                if (hotkey != Keys.None && modifiers != Keys.None)
                    RegisterHotKey(this.Handle, 0, (int)modifiersValue, hotkey.GetHashCode());
            }
        }

        public void UnregisterCurrentBattleHotkey()
        {
            UnregisterHotKey(this.Handle, 0);
        }
        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!mainPanel.ShowCurrentHotkeyTextBox.Focused && keyData == (Keys.Control | Keys.R))
            {
                mainPanel.ReStartNotifying();
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
            // When minimized hide from task bar and show NotifyIcon if must hide.
            if (WindowState == FormWindowState.Minimized)
            {
                if (UserSettings.Instance.MustHideToTraybar())
                {
                    UnregisterCurrentBattleHotkey();
                    ShowInTaskbar = false;
                    NotifyIcon.Visible = true;
                    NotifyIcon.ShowBalloonTip(1000);
                    UpdateTrayNotifyIcon();
                    RegisterCurrentBattleHotkeyFromPanel();
                }
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            UserSettings.Save();
            ShutDownNotifyIcon();
            UnregisterCurrentBattleHotkey();
            battleNotifier.Dispose();
            base.OnClosed(e);
        }

        #region NotifyIcon
        private void InitializeNotifyIcon()
        {
            contextMenu = new ContextMenu();
            exitMenuItem = new MenuItem();
            stopMenuItem = new MenuItem();
            startMenuItem = new MenuItem();
            restartMenuItem = new MenuItem();

            // Initialize StopMenuItem
            stopMenuItem.Index = 1;
            stopMenuItem.Text = "Stop";
            stopMenuItem.Click += new EventHandler(StopMenuItem_Click);

            // Initialize StartMenuItem
            startMenuItem.Index = 1;
            startMenuItem.Text = "Start";
            startMenuItem.Click += new EventHandler(StartMenuItem_Click);

            // Initialize ExitMenuItem
            restartMenuItem.Index = 2;
            restartMenuItem.Text = "Restart";
            restartMenuItem.Click += new System.EventHandler(RestartMenuItem_Click);

            // Initialize ExitMenuItem
            exitMenuItem.Index = 0;
            exitMenuItem.Text = "Exit";
            exitMenuItem.Click += new EventHandler(ExitMenuItem_Click);

            // Set Start and Exit as startup options.
            contextMenu.MenuItems.Add(startMenuItem);
            contextMenu.MenuItems.Add(exitMenuItem);

            // The ContextMenu property sets the menu that will 
            // appear when the systray icon is right clicked.
            NotifyIcon.ContextMenu = contextMenu;
        }

        private void RestartMenuItem_Click(object sender, EventArgs e)
        {
            mainPanel.ReStartNotifying();
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
            UnregisterCurrentBattleHotkey();

            // Show the form when the user double clicks on the notify icon. 
            // Set the WindowState to normal if the form is minimized. 
            if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;

            ShowInTaskbar = true;
            NotifyIcon.Visible = false;

            // Activate the form. 
            this.Activate();

            RegisterCurrentBattleHotkeyFromPanel();
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
            catch (Exception ex)
            {
                Logger.Log(600, ex);
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
                contextMenu.MenuItems.Add(1, restartMenuItem);
                contextMenu.MenuItems.Add(1, stopMenuItem);
                if (contextMenu.MenuItems.Contains(startMenuItem))
                    contextMenu.MenuItems.Remove(startMenuItem);
            }
            else
            {
                contextMenu.MenuItems.Add(1, startMenuItem);
                if (contextMenu.MenuItems.Contains(stopMenuItem))
                    contextMenu.MenuItems.Remove(stopMenuItem);
                if (contextMenu.MenuItems.Contains(restartMenuItem))
                    contextMenu.MenuItems.Remove(restartMenuItem);
            }
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
    enum KeyModifier
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        WinKey = 8
    }
}
