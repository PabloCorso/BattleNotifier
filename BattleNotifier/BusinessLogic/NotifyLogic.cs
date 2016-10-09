using BattleNotifier.Controller;
using BattleNotifier.Controller.ViewInterface;
using BattleNotifier.Model;
using BattleNotifier.Utils;
using System;

namespace BattleNotifier.BusinessLogic
{
    public class NotifyLogic
    {
        private Battle currentBattle = null;
        private CurrentBattleApi CurrentBattleApi = new CurrentBattleApi();
        private bool currentFinishedNormally = false;
        private bool currentNotified = false;
        private DateTime CurrentDateTime { get; set; }

        private IMain MainView { get; set; }
        private IMainPanel MainPanel { get { return MainView.MainPanel; } }
        public NotifyLogic(IMain view)
        {
            MainView = view;
        }

        /// <summary>
        /// Notificate current battle if any, and return a new interval for the next notification.
        /// </summary>
        /// <returns> Next notification interval in seconds. </returns>
        public double NotifyBattle()
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

        public bool UpdateIsNeeded()
        {
            return !currentNotified && (currentBattle != null && FilterBattle(currentBattle));
        }

        public void Clear()
        {
            currentNotified = false;
            currentFinishedNormally = false;
            currentBattle = null;
            CurrentBattleApi.Clear();
        }

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
