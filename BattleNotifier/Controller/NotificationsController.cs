﻿using BattleNotifier.Model;
using BattleNotifier.Utils;
using BattleNotifier.View;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Media;
using System.Windows.Forms;
using System.Timers;
using Settings = BattleNotifier.Properties.Settings;
using BattleNotifier.Controller.ViewInterface;

namespace BattleNotifier.Controller
{
    public class NotificationsController
    {
        private System.Timers.Timer notificationTimer = new System.Timers.Timer();

        private static NotificationsController instance;
        private BattleNotification bn;
        private MapNotification mn;
        private WMPLib.WindowsMediaPlayer player;
        public Image Map { get; set; }

        private NotificationsController() { }

        public static NotificationsController Instance
        {
            get
            {
                if (instance == null)
                    instance = new NotificationsController();

                return instance;
            }
        }

        public void SimulateRandomBattle()
        {
            Random random = new Random();
            int map = Convert.ToInt32(random.NextDouble() * (91323 - 1) + 1);
            int id = Convert.ToInt32(random.NextDouble() * (91323 - 1) + 1);
            int duration = Convert.ToInt32(random.NextDouble() * (60 - 1) + 1);
            Battle battle = new Battle()
            {
                FileName = "LONGNAME.lev",
                MapUrl = Settings.Default.EOLMapsUrl + map,
                Duration = duration,
                Attributes = (BattleAttribute)15,
                Type = 0,
                StartedDateTime = DateTime.Now,
                Desginer = "Long Kuski Nickname",
                Id = id
            };

            this.ShowBattleNotification(BattleNotifierController.Instance.MainView, battle, duration * 60);
        }

        public void SimulateNewBattle()
        {
            Battle battle = new Battle()
            {
                FileName = "Pob0989.lev",
                MapUrl = Settings.Default.EOLMapsUrl + "309883",
                Duration = 20,
                Attributes = (BattleAttribute)15,
                Type = 0,
                StartedDateTime = DateTime.Now,
                Desginer = "Pab",
                Id = 90431
            };

            this.ShowBattleNotification(BattleNotifierController.Instance.MainView, battle, 20 * 60);
        }

        public void ShowBattleNotification(IMain m, Battle battle, double timeLeft)
        {
            ClearBattleNotification();

            BattleNotificationSettings settings = UserSettings.Instance.GetBattleNotificationSettings();

            if (settings.Basic.ShowBattleDialog || settings.Basic.ShowMapDialog)
            {
                try
                {
                    Map = WebRequestHelper.GetImageFromUrl(battle.MapUrl);
                }
                catch (Exception)
                {
                    Map = (Image)Properties.Resources.close_window;
                }

                if (settings.Basic.ShowBattleDialog)
                    if (settings.General.UseFadeEffect)
                        bn = new TransBattleNotification(battle, timeLeft, settings, true);
                    else
                        bn = new BattleNotification(battle, timeLeft, settings);
                if (settings.Basic.ShowMapDialog)
                {
                    int height = bn == null ? 0 : bn.Height;
                    if (settings.General.UseFadeEffect)
                        mn = new TransMapNotification(battle, timeLeft, height, MapSizeIndexToWidth(settings.Basic.MapSize), settings.Map, true);
                    else
                        mn = new MapNotification(battle, timeLeft, height, MapSizeIndexToWidth(settings.Basic.MapSize), settings.Map);
                }
            }

            if (!settings.General.ShowOnTop)
            {
                mn.TopMost = false;
                bn.TopMost = false;
            }

            if (settings.Basic.ShowMapDialog)
                m.ShowMapNotification(mn);
            if (settings.Basic.ShowBattleDialog)
                m.ShowBattleNotification(bn);

            // Play sound.
            if (settings.Basic.PlaySound)
                if (!string.IsNullOrEmpty(settings.Basic.SoundPath) && File.Exists(settings.Basic.SoundPath))
                    PlaySound(settings.Basic.SoundPath, settings.Basic.DefaultSound);
                else
                    PlayDefaultSound(settings.Basic.DefaultSound);

            if (settings.Basic.LifeSeconds > 0)
            {
                notificationTimer.Interval = new TimeSpan(0, 0, settings.Basic.LifeSeconds).TotalMilliseconds;
                notificationTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                notificationTimer.Start();
            }
        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (notificationTimer.Enabled)
            {
                EndBattleNotification();
                notificationTimer.Stop();
            }
        }

        private void PlaySound(string path, int defaultSound = 0)
        {
            try
            {
                player = new WMPLib.WindowsMediaPlayer();
                player.URL = path;
                player.controls.play();
            }
            catch (Exception)
            {
                PlayDefaultSound(defaultSound);
            }
        }

        private void StopSound()
        {
            try
            {
                if (player != null && player.controls != null)
                    player.controls.stop();
            }
            catch (Exception)
            {
                // Nothing happend here, no one saw anything. Get back to work.
            }
        }

        private void PlayDefaultSound(int defaultSound)
        {
            SoundPlayer sound = new SoundPlayer(IndexToDefaultSound(defaultSound));
            sound.Play();
        }

        private void ClearBattleNotification()
        {
            try
            {
                try
                {
                    if (mn != null)
                        mn.CloseForm();
                }
                catch (Exception) { }
                try
                {
                    if (bn != null)
                        bn.CloseForm();
                }
                catch (Exception) { }


                StopSound();
                Map = null;
                if (notificationTimer.Enabled)
                    notificationTimer.Stop();
            }
            catch (Exception)
            {
            }
            finally
            {
                bn = null;
                mn = null;
            }
        }

        public void BattleNotificationMapPressed()
        {
            if (mn.Visible)
                mn.Hide();
            else
                mn.Show();
        }

        private void EndBattleNotification()
        {
            ClearBattleNotification();
        }

        public void BattleNotificationClosed()
        {
            ClearBattleNotification();
        }

        public void MapNotificationClosed()
        {
            if (mn.WindowState == FormWindowState.Minimized)
                ClearBattleNotification();
            else
                if (bn == null)
                    ClearBattleNotification();
                else
                    mn.Hide();
        }

        private int MapSizeIndexToWidth(int mapSize)
        {
            switch (mapSize)
            {
                case 0:
                    return 600;
                case 1:
                    return 480;
                case 2:
                    return 320;
                case 3:
                    return 200;
                case 4:
                    return 160;
                default:
                    return 320;
            }
        }

        private Stream IndexToDefaultSound(int index)
        {
            switch (index)
            {
                case 0:
                    return Properties.Resources.apple;
                case 1:
                    return Properties.Resources.flower;
                case 2:
                    return Properties.Resources.wroom;
                case 3:
                    return Properties.Resources.deaded;
                case 4:
                    Random random = new Random();
                    int randomCase = random.Next(0, 4);
                    return IndexToDefaultSound(randomCase);
                default:
                    return Properties.Resources.smb_1_up;
            }
        }
    }
}
