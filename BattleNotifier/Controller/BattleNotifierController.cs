using BattleNotifier.Controller.ViewInterface;
using BattleNotifier.Model;
using System;
using BattleNotifier.Utils;
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
        private Battle currentBattle = null;
        private CurrentBattleApi CurrentBattleApi = new CurrentBattleApi();
        private bool currentFinishedNormally = false;
        private bool currentNotified = false;
        private bool powerModeSuspended = false;
        private bool timerSuspended = false;
        private DateTime CurrentDateTime { get; set; }

        public IMain MainView { get; private set; }
        private IMainPanel MainPanel { get { return MainView.MainPanel; } }

        /// <summary>
        /// True if the controller is notifying new battles, else false.
        /// </summary>
        public bool IsNotifyingBattle { get; private set; }

        public static BattleNotifierController Instance { get { return instance; } }

        private BattleNotifierController(IMain view)
        {
            this.MainView = view;
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
            this.notificationTimer.Tick -= OnTimedEvent;
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
            SetNextUpdateInterval(NotifyBattle());
        }

        /// <summary>
        /// Stop notifying battles.
        /// </summary>
        public void StopNotifying()
        {
            // Stop notifying battles.
            notificationTimer.Stop();
            IsNotifyingBattle = false;

            // Reset all helpers.
            currentNotified = false;
            currentFinishedNormally = false;
            currentBattle = null;
            CurrentBattleApi.Clear();
        }

        public void UpdateNotifying()
        {
            if (!currentNotified && (currentBattle != null && FilterBattle(currentBattle)))
            {
                notificationTimer.Stop();
                SetNextUpdateInterval(NotifyBattle());
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
            SetNextUpdateInterval(NotifyBattle());
        }

        #endregion

        #region Notification methods

        /// <summary>
        /// Notificate current battle if any, and return a new interval for the next notification.
        /// </summary>
        /// <returns> Next notification interval in seconds. </returns>
        private double NotifyBattle()
        {
            double nextUpdate = 5; // Seconds.

            Battle battle = CurrentBattleApi.GetOngoingBattleIfAny(CurrentDateTime);

            if (battle == null || currentFinishedNormally)
            {
                if (currentFinishedNormally)
                    nextUpdate = 115;
                else
                    nextUpdate = 5;
                currentBattle = null;
                currentFinishedNormally = false;
                currentNotified = false;
            }
            else // Ongoing battle.
            {
                // New battle.
                if (!battle.Equals(currentBattle))
                    currentBattle = battle;

                // Notificate battle.
                if (!currentNotified)
                {
                    NotificationsController.Instance.CurrentBattle = currentBattle;
                    if (FilterBattle(currentBattle))
                    {
                        currentNotified = true;
                        NotificationsController.Instance.ShowBattleNotification(MainView, currentBattle);
                    }
                }

                double timePassed = (CurrentDateTime - battle.StartedDateTime).TotalSeconds;
                double timeLeft = (battle.Duration * 60) - timePassed;

                if (timeLeft < 1)
                {
                    nextUpdate = 1;
                    currentFinishedNormally = true;
                }
                else if (timePassed < 60 || battle.Type.HasFlag(BattleType.OneLife)) // Started recently or OneLife.
                    nextUpdate = 20;
                else if (currentBattle.Duration < 10)
                {
                    // Short battle.
                    nextUpdate = timeLeft;
                    currentFinishedNormally = true;
                }
                else
                {
                    if (timeLeft <= currentBattle.Duration * 60 * 0.20)
                    {
                        // Short time left proportional to duration.
                        nextUpdate = timeLeft;
                        currentFinishedNormally = true;
                    }
                    else
                        nextUpdate = currentBattle.Duration * 60 * 0.20;
                }
            }

            return nextUpdate;
        }

        #endregion

        #region Filter battle

        /// <summary>
        /// Use user preferences to filter wanted battles.
        /// </summary>
        /// <param name="battle"> Battle to filter. </param>
        /// <returns> True if the battle fullfils the user preferences, else false.</returns>
        private bool FilterBattle(Battle battle)
        {
            return FilterBattleTypes(battle) && FilterDesigners(battle);
        }

        private bool FilterDesigners(Battle battle)
        {
            foreach (string designer in MainPanel.CheckedBlackList)
                if (designer.Equals(battle.Desginer, StringComparison.InvariantCultureIgnoreCase))
                    return false;

            if (MainPanel.HasAllDesignersChecked())
                return true;

            foreach (string designer in MainPanel.CheckedDesigners)
                if (designer.Equals(battle.Desginer, StringComparison.InvariantCultureIgnoreCase))
                    return true;

            return false;
        }

        private bool FilterBattleTypes(Battle battle)
        {
            if (MainPanel.HasAllBattleTypesChecked())
                return true;

            foreach (string type in MainPanel.CheckedBattleTypes)
            {
                if (type.Equals(EnumExtensions.GetDescription(battle.Type)))
                    return true;
            }

            return false;
        }

        #endregion
    }
}
