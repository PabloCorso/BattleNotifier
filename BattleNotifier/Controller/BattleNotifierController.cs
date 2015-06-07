using BattleNotifier.Controller.ViewInterface;
using HtmlAgilityPack;
using BattleNotifier.Model;
using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Timers;
using BattleNotifier.Utils;
using Microsoft.Win32;
using BattleNotifier.View;
using Settings = BattleNotifier.Properties.Settings;

namespace BattleNotifier.Controller
{
    public class BattleNotifierController
    {
        private static BattleNotifierController instance;

        // Battle notification.
        private Timer notificationTimer = new System.Timers.Timer();

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

        public static void InitializeBattleNotifierController(IMain view)
        {
            if (instance == null)
                instance = new BattleNotifierController(view);
        }

        public void Dispose()
        {
            this.notificationTimer.Elapsed -= OnTimedEvent;
            SystemEvents.PowerModeChanged -= SystemEvents_PowerModeChanged;
        }

        //TODO delete
        public void Test()
        {
            currentNotified = false;
            currentBattle = null;
            currentFinishedNormally = false;
            currentNotified = false;
            eolDataLoaded = false;
            SetNextUpdateInterval(1);
        }

        private BattleNotifierController(IMain view)
        {
            this.MainView = view;
            notificationTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;
        }

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
            notificationTimer.Interval = TimeSpan.FromSeconds(newInterval).TotalMilliseconds;
            notificationTimer.Start();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            SetNextUpdateInterval(NotifyBattle());
        }

        #region Battle notification
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
                    nextUpdate = 121;
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
                if (FilterBattle(currentBattle) && !currentNotified)
                {
                    currentNotified = true;
                    NotificationsController.Instance.ShowBattleNotification(MainView, currentBattle, timeLeft);
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
                            HtmlDocument document = new HtmlWeb().Load(battle.Url);

                            battle.LevelUrl = document.DocumentNode.Descendants("a")
                                                                .Select(e => e.GetAttributeValue("href", null))
                                                                .Where(s => !String.IsNullOrEmpty(s) && s.StartsWith(Settings.Default.EOLLevelUrl))
                                                                .FirstOrDefault();

                            battle.MapUrl = document.DocumentNode.Descendants("img")
                                                            .Select(e => e.GetAttributeValue("src", null))
                                                            .Where(s => !String.IsNullOrEmpty(s) && s.StartsWith(Settings.Default.EOLMapsUrl))
                                                            .FirstOrDefault();
                            eolDataLoaded = true;
                        }
                        catch (Exception) { }
                    }

                    return battle;
                }
                else
                {
                    eolDataLoaded = false;
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
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

        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            if (e.Mode == PowerModes.Suspend)
            {
                if (notificationTimer.Enabled)
                {
                    notificationTimer.Stop();
                    timerSuspended = true;
                }
                powerModeSuspended = true;
            }
            else if (powerModeSuspended)
            {
                if (!MainPanel.TimerStoppedNotifications && timerSuspended)
                    if (!notificationTimer.Enabled)
                        notificationTimer.Start();
                powerModeSuspended = false;
                timerSuspended = false;
            }
        }

        public void SimulateBattleNotification1()
        {
            Battle battle = new Battle()
            {
                FileName = "Pob0989.lev",
                MapUrl = Settings.Default.EOLMapsUrl + "308356",
                Duration = 20,
                Attributes = (BattleAttribute)15,
                Type = 0,
                StartedDateTime = DateTime.Now,
                Desginer = "Pab",
                Id = 90431
            };

            NotificationsController.Instance.ShowBattleNotification(MainView, battle, 20 * 60);
        }

        public void SimulateBattleNotification2()
        {
            Battle battle = new Battle()
            {
                FileName = "WWWWWWWW.lev",
                MapUrl = Settings.Default.EOLMapsUrl + "308342",
                Duration = 10,
                Attributes = (BattleAttribute)1023,
                Type = (BattleType)2,
                StartedDateTime = DateTime.Now.AddSeconds(-20),
                Desginer = "Long Kuski Name",
                Id = 90431
            };

            NotificationsController.Instance.ShowBattleNotification(MainView, battle, 605);
        }
    }
}
