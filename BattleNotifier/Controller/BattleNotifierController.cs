﻿using BattleNotifier.Controller.ViewInterface;
using HtmlAgilityPack;
using BattleNotifier.Model;
using System;
using System.Linq;
using System.Xml;
using BattleNotifier.Utils;
using Microsoft.Win32;
using Settings = BattleNotifier.Properties.Settings;
using System.Windows.Forms;
using Utils;

namespace BattleNotifier.Controller
{
    public class BattleNotifierController
    {
        private static BattleNotifierController instance;

        // Battle notification.
        private Timer notificationTimer = new Timer();

        // Helpers.
        private Battle currentBattle = null;
        private bool currentFinishedNormally = false;
        private bool currentNotified = false;
        private bool powerModeSuspended = false;
        private bool timerSuspended = false;
        private DateTime CurrentDateTime { get; set; }

        public IMain MainView { get; private set; }
        private IMainPanel MainPanel { get { return MainView.MainPanel; } }

        /// <summary>
        /// This flag helps to use elmaonline only once per battle and not spam/abuse.
        /// </summary>
        private bool eolDataLoaded = false;

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
            eolDataLoaded = false;
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

            Battle battle = GetOngoingBattleIfAny();

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
                double timePassed = (CurrentDateTime - battle.StartedDateTime).TotalSeconds;
                double timeLeft = (battle.Duration * 60) - timePassed;

                // New battle.
                if (!battle.Equals(currentBattle))
                {
                    currentBattle = battle;
                }

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

                if (timeLeft < 1)
                {
                    nextUpdate = 1;
                    currentFinishedNormally = true;
                }
                else if (timePassed < 60) // Started recently.
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

        /// <summary>
        /// Get the current battle from domi's api, and elmaonline.
        /// </summary>
        /// <returns> Ongoing battle if any, else null.</returns>
        private Battle GetOngoingBattleIfAny()
        {
            try
            {
                XmlDocument xmlDoc = WebRequestHelper.GetXmlFromUrl(Settings.Default.CurrentBattleApiUrl);

                CurrentDateTime = DateTime.Now;
                if (xmlDoc.FirstChild.HasChildNodes)
                {
                    Battle battle = new Battle();

                    battle.Desginer = xmlDoc.DocumentElement.SelectSingleNode("designer").InnerText;
                    battle.FileName = xmlDoc.DocumentElement.SelectSingleNode("file_name").InnerText;

                    int startDelta = 0;
                    string strDelta = xmlDoc.DocumentElement.SelectSingleNode("start_delta").InnerText;
                    if (!Int32.TryParse(strDelta, out startDelta))
                    {
                        double delta = double.Parse(strDelta, System.Globalization.CultureInfo.InvariantCulture);
                        startDelta = Convert.ToInt32(delta);
                    }

                    battle.StartedDateTime = CurrentDateTime.AddSeconds(Convert.ToInt32(startDelta));

                    battle.Type = (BattleType)Convert.ToInt32(xmlDoc.DocumentElement.SelectSingleNode("battle_type").InnerText);
                    battle.Attributes = (BattleAttribute)Convert.ToInt32(xmlDoc.DocumentElement.SelectSingleNode("battle_attrs").InnerText);
                    battle.Duration = Convert.ToInt32(xmlDoc.DocumentElement.SelectSingleNode("duration").InnerText) / 60;

                    battle.Id = Convert.ToInt32(xmlDoc.DocumentElement.SelectSingleNode("id").InnerText);

                    if (!eolDataLoaded)
                    {
                        try
                        {
                            SetBattleUrls(battle);

                            eolDataLoaded = true;
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                SetBattleUrls(battle);
                                Logger.Log(101, ex);
                            }
                            catch (Exception iex)
                            {
                                Logger.Log(103, iex);
                            }
                        }
                    }

                    return battle;
                }
                else
                {
                    eolDataLoaded = false;
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(100, ex);
                return null;
            }
        }

        private void SetBattleUrls(Battle battle)
        {
            HtmlAgilityPack.HtmlDocument document = new HtmlWeb().Load(battle.Url);

            battle.LevelUrl = document.DocumentNode.Descendants("a")
                                                .Select(e => e.GetAttributeValue("href", null))
                                                .Where(s => !String.IsNullOrEmpty(s) && s.StartsWith(Settings.Default.EOLLevelUrl))
                                                .FirstOrDefault();

            battle.MapUrl = document.DocumentNode.Descendants("img")
                                            .Select(e => e.GetAttributeValue("src", null))
                                            .Where(s => !String.IsNullOrEmpty(s) && s.StartsWith(Settings.Default.EOLMapsUrl))
                                            .FirstOrDefault();
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
