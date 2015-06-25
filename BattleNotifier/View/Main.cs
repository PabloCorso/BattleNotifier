using BattleNotifier.Controller;
using BattleNotifier.Controller.ViewInterface;
using BattleNotifier.Model;
using BattleNotifier.Utils;
using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Reflection;
using System.Text;
using System.Timers;
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
        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.R))
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
                    ShowInTaskbar = false;
                    NotifyIcon.Visible = true;
                    NotifyIcon.ShowBalloonTip(1000);
                    UpdateTrayNotifyIcon();
                }
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            UserSettings.Save();
            ShutDownNotifyIcon();
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
            if (battleNotifier.IsNotifyingBattle)
                battleNotifier.RestartNotifying();
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
            catch (Exception ex)
            {
#if DEBUG
                Logger.Log(600, ex);
#endif
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
}
