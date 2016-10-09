using BattleNotifier.Controller.ViewInterface;
using System;
using Microsoft.Win32;
using System.Windows.Forms;
using BattleNotifier.BusinessLogic;

namespace BattleNotifier.Controller
{
    public class BattleNotifierController
    {
        private static BattleNotifierController instance;

        // Battle notification.
        private Timer notificationTimer = new Timer();

        // Helpers.
        NotifyLogic notifyLogic;
        private bool powerModeSuspended = false;
        private bool timerSuspended = false;

        public IMain MainView { get; private set; }
        private IMainPanel MainPanel { get { return MainView.MainPanel; } }

        /// <summary>
        /// True if the controller is notifying new battles, else false.
        /// </summary>
        public bool IsNotifyingBattle { get; private set; }

        public static BattleNotifierController Instance { get { return instance; } }

        private BattleNotifierController(IMain view)
        {
            MainView = view;
            notifyLogic = new NotifyLogic(view);
            notificationTimer.Tick += new EventHandler(OnTimedEvent);
            SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;
        }

        public static void InitializeBattleNotifierController(IMain view)
        {
            if (instance == null)
                instance = new BattleNotifierController(view);
        }

        public void Dispose()
        {
            notificationTimer.Tick -= OnTimedEvent;
            SystemEvents.PowerModeChanged -= SystemEvents_PowerModeChanged;
        }

        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            if (e.Mode == PowerModes.Suspend)
            {
                if (notificationTimer.Enabled)
                {
                    StopNotifying();
                    NotificationsController.Instance.HideBattleNotification();
                    timerSuspended = true;
                }
                powerModeSuspended = true;
            }
            else if (powerModeSuspended)
            {
                if (!MainPanel.TimerStoppedNotifications && timerSuspended)
                    StartNotifying();
                powerModeSuspended = false;
                timerSuspended = false;
            }
        }

        #region Battle notification

        /// <summary>
        /// Start notifying battles.
        /// </summary>
        public void StartNotifying()
        {
            // Start notifying battles.
            IsNotifyingBattle = true;
            SetNextUpdateInterval(notifyLogic.NotifyBattle());
        }

        /// <summary>
        /// Stop notifying battles.
        /// </summary>
        public void StopNotifying()
        {
            // Stop notifying battles.
            notificationTimer.Stop();
            IsNotifyingBattle = false;

            notifyLogic.Clear();
        }

        public void UpdateNotifying()
        {
            if (notifyLogic.UpdateIsNeeded())
            {
                notificationTimer.Stop();
                SetNextUpdateInterval(notifyLogic.NotifyBattle());
            }
        }

        public void RestartNotifying()
        {
            StopNotifying();
            StartNotifying();
        }

        /// <summary>
        /// Take a new interval and set it for the next battle notification.
        /// </summary>
        /// <param name="newInterval"> Next notification in seconds. </param>
        private void SetNextUpdateInterval(double newInterval)
        {
            if (notificationTimer.Enabled)
                notificationTimer.Stop();
            notificationTimer.Interval = Convert.ToInt32(TimeSpan.FromSeconds(newInterval).TotalMilliseconds);
            notificationTimer.Start();
        }

        private void OnTimedEvent(object source, EventArgs e)
        {
            SetNextUpdateInterval(notifyLogic.NotifyBattle());
        }

        #endregion
    }
}
