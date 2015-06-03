﻿using BattleNotifier.Controller.ViewInterface;
using HtmlAgilityPack;
using BattleNotifier.Model;
using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Timers;
using BattleNotifier.Utils;
using AppSettings = System.Configuration.ConfigurationManager;
using Microsoft.Win32;
using BattleNotifier.View;

namespace BattleNotifier.Controller
{
    public class BattleNotifierController
    {
        // Battle notification.
        private Timer notificationTimer = new System.Timers.Timer();
        private object lockSet = new object();

        // Helpers.
        private Battle currentBattle = null;
        private bool currentFinishedNormally = false;
        private bool currentNotified = false;
        private bool powerModeSuspended = false;
        private DateTime CurrentDateTime { get; set; }

        private IMain MainView { get; set; }
        private IMainPanel MainPanel { get { return MainView.MainPanel; } }

        /// <summary>
        /// This flag helps to use elmaonline only once per battle and not spam/abuse.
        /// </summary>
        private bool eolDataLoaded = false;

        /// <summary>
        /// True if the controller is notifying new battles, else false.
        /// </summary>
        public bool IsNotifyingBattle { get; private set; }

        public BattleNotifierController(IMain view)
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
#if DEBUG
                    File.AppendAllText(@"D:\Desktop\Update.txt", "Duration: " + currentBattle.Duration + "\n");
                    File.AppendAllText(@"D:\Desktop\Update.txt", "Started: " + currentBattle.StartedDateTime.ToString() + "\n" + "\n");
#endif
                }

                // Notificate battle.
                if (FilterBattle(currentBattle) && !currentNotified)
                {
                    MainView.ShowBattleNotificationDialog(currentBattle, Convert.ToInt32(timeLeft));
                    currentNotified = true;
                }
#if DEBUG
                File.AppendAllText(@"D:\Desktop\Update.txt", "Time Left: " + timeLeft + " (" + timeLeft / 60 + ")" + "\n");
                File.AppendAllText(@"D:\Desktop\Update.txt", "Time Passed: " + timePassed + " (" + timePassed / 60 + ")" + "\n");
#endif
                if (timeLeft < 1)
                {
#if DEBUG
                    File.AppendAllText(@"D:\Desktop\Update.txt", "1 or less Time Left case happend" + "\n");
#endif
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
#if DEBUG
            File.AppendAllText(@"D:\Desktop\Update.txt", "Next Update: " + nextUpdate + " (" + nextUpdate / 60 + ")\n");
            DateTime now = DateTime.Now;
            File.AppendAllText(@"D:\Desktop\Update.txt", "Time: " + now.TimeOfDay + "\n");
            File.AppendAllText(@"D:\Desktop\Update.txt", "Next Update Expected: " + now.AddSeconds(nextUpdate).TimeOfDay + "\n" + "\n");
#endif
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
                XmlDocument xmlDoc = WebRequestHelper.GetXmlFromUrl(AppSettings.AppSettings["CurrentBattleApiUrl"]);

#if DEBUG
                xmlDoc.Save(@"D:\Desktop\DomiTest.txt");
#endif
                CurrentDateTime = DateTime.Now;
                if (xmlDoc.FirstChild.HasChildNodes)
                {
                    Battle battle = new Battle();

                    battle.Desginer = xmlDoc.DocumentElement.SelectSingleNode("designer").InnerText;
                    battle.FileName = xmlDoc.DocumentElement.SelectSingleNode("file_name").InnerText;

                    int startDelta = Convert.ToInt32(xmlDoc.DocumentElement.SelectSingleNode("start_delta").InnerText);
                    battle.StartedDateTime = CurrentDateTime.AddSeconds(startDelta);

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
                                                                .Where(s => !String.IsNullOrEmpty(s) && s.StartsWith(AppSettings.AppSettings["EOLLevelUrl"]))
                                                                .FirstOrDefault();

                            battle.MapUrl = document.DocumentNode.Descendants("img")
                                                            .Select(e => e.GetAttributeValue("src", null))
                                                            .Where(s => !String.IsNullOrEmpty(s) && s.StartsWith(AppSettings.AppSettings["EOLMapsUrl"]))
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
            if (e.Mode == PowerModes.Suspend && notificationTimer.Enabled)
            {
                if (notificationTimer.Enabled)
                    notificationTimer.Stop();
                powerModeSuspended = true;
            }
            else if (powerModeSuspended)
            {
                if (MainPanel.TimerEnabled && !notificationTimer.Enabled)
                    notificationTimer.Start();
                powerModeSuspended = false;
            }
        }

        public void SimulateBattleNotification1()
        {
            Battle battle = new Battle()
            {
                FileName = "Pob0989.lev",
                MapUrl = AppSettings.AppSettings["EOLMapsUrl"] + "308356",
                Duration = 20,
                Attributes = (BattleAttribute)15,
                Type = 0,
                StartedDateTime = DateTime.Now,
                Desginer = "Pab",
                Id = 90431
            };

            MainView.ShowBattleNotificationDialog(battle, 20 * 60);
        }

        public void SimulateBattleNotification2()
        {
            Battle battle = new Battle()
            {
                FileName = "WWWWWWWW.lev",
                MapUrl = AppSettings.AppSettings["EOLMapsUrl"] + "308342",
                Duration = 10,
                Attributes = (BattleAttribute)1023,
                Type = (BattleType)2,
                StartedDateTime = DateTime.Now.AddSeconds(-20),
                Desginer = "Long Kuski Name",
                Id = 90431
            };

            MainView.ShowBattleNotificationDialog(battle, 605);
        }
    }
}