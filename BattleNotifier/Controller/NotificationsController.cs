using BattleNotifier.Model;
using BattleNotifier.Utils;
using BattleNotifier.View;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Media;
using System.Windows.Forms;
using Settings = BattleNotifier.Properties.Settings;
using BattleNotifier.Controller.ViewInterface;
using Utils;

namespace BattleNotifier.Controller
{
    public class NotificationsController
    {
        private Timer notificationTimer = new Timer();

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

            this.ShowBattleNotification(BattleNotifierController.Instance.MainView, battle, true);
        }

        public void SimulateNewBattle()
        {
            Random random = new Random();
            int id = random.Next(0, 92350);
            int duration = random.Next(1, 61);
            int attributes = random.Next(1, 2048);
            int type = random.Next(0, 11);
            Battle battle = new Battle()
            {
                FileName = "Battle Notifier!.lev",
                MapUrl = null,
                Duration = duration,
                Attributes = (BattleAttribute)attributes,
                Type = (BattleType)type,
                StartedDateTime = DateTime.Now,
                Desginer = "Pab",
                Id = id
            };

            this.ShowBattleNotification(BattleNotifierController.Instance.MainView, battle, true);
        }

        public void HideBattleNotification()
        {
            ClearBattleNotification();
        }

        public void ShowBattleNotification(IMain m, Battle battle, bool simulation = false)
        {
            ClearBattleNotification();

            BattleNotificationSettings settings = UserSettings.Instance.GetBattleNotificationSettings();

            if (settings.Basic.ShowBattleDialog || settings.Basic.ShowMapDialog)
            {
                SetMap(battle.MapUrl, simulation);

                double timeLeft = battle.TimeLeft;
                if (settings.Basic.ShowBattleDialog)
                    if (settings.General.UseFadeEffect)
                        bn = new TransBattleNotification(battle, timeLeft, settings, true);
                    else
                        bn = new BattleNotification(battle, timeLeft, settings);

                int height = bn == null ? 0 : bn.Height;
                if (settings.General.UseFadeEffect)
                    mn = new TransMapNotification(battle, timeLeft, height, MapSizeIndexToWidth(settings.Basic.MapSize), settings, true);
                else
                    mn = new MapNotification(battle, timeLeft, height, MapSizeIndexToWidth(settings.Basic.MapSize), settings);
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
                notificationTimer.Interval = Convert.ToInt32(new TimeSpan(0, 0, settings.Basic.LifeSeconds).TotalMilliseconds);
                notificationTimer.Tick += new EventHandler(OnTimedEvent);
                notificationTimer.Start();
            }
        }

        private void SetMap(string mapUrl, bool simulation)
        {
            try
            {
                Map = WebRequestHelper.GetImageFromUrl(mapUrl + "/600");
            }
            catch (Exception ex)
            {
                if (!simulation)
                {
                    Logger.Log(200, ex);
                }
                Map = (Image)Properties.Resources.about;
            }
        }

        private void OnTimedEvent(object source, EventArgs e)
        {
            if (notificationTimer.Enabled)
            {
                if (!(bn != null && bn.IsPrinting))
                {
                    EndBattleNotification();
                }
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
            catch (Exception ex)
            {
                Logger.Log(201, ex);
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
                catch (Exception ex)
                {
                    Logger.Log(202, ex);
                }
                try
                {
                    if (bn != null)
                        bn.CloseForm();
                }
                catch (Exception ex)
                {
                    Logger.Log(203, ex);
                }

                StopSound();
                Map = null;
                if (notificationTimer.Enabled)
                    notificationTimer.Stop();
            }
            catch (Exception ex)
            {
                Logger.Log(204, ex);
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
                mn.Visible = false;
            else
                mn.Visible = true;
        }

        public void EndBattleNotification()
        {
            ClearBattleNotification();
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
                    return Properties.Resources.apple;
            }
        }
    }
}
