using BattleNotifier.Model;
using BattleNotifier.Utils;
using BattleNotifier.View;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BattleNotifier.Controller.ViewInterface;
using Utils;

namespace BattleNotifier.Controller
{
    public class NotificationsController
    {
        private Timer notificationTimer = new Timer();

        private static NotificationsController instance;
        private BaseNotification bn;
        private BaseNotification mn;
        private SoundHelper player = new SoundHelper();

        // parche asqueroso para que cuando se muestra current battle, dice si hay que bajar el 
        // mapa de nuevo porque el mapa actual fue sobreescrito por una simulación.
        private bool downloadCurrentMap;
        public Image Map { get; set; }
        private string lastLoadedMapId { get; set; }
        public Battle CurrentBattle { get; set; }

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

        public void ShowCurrentBattleNotification(IMain main)
        {
            if (CurrentBattle != null)
                ShowBattleNotification(main, CurrentBattle, true);
        }

        public void HideBattleNotification()
        {
            ClearBattleNotification();
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
                FileName = "Battle Notifier.lev",
                MapUrl = null,
                Duration = duration,
                Attributes = (BattleAttribute)attributes,
                Type = (BattleType)type,
                StartedDateTime = DateTime.Now,
                Desginer = "Pab",
                Id = id
            };

            ShowBattleNotification(BattleNotifierController.Instance.MainView, battle, false, true);
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

                player.StopSound();
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
            if (mn != null)
                if (mn.Visible)
                    mn.Visible = false;
                else
                    mn.Visible = true;
        }

        public void EndBattleNotification()
        {
            ClearBattleNotification();
        }

        #region Show battle notification

        public void ShowBattleNotification(IMain m, Battle battle, bool showCurrent = false, bool simulation = false)
        {
            bool returnAfterClear = showCurrent && (bn != null || mn != null);
            ClearBattleNotification();
            if (returnAfterClear) return;

            BattleNotificationSettings settings = UserSettings.Instance.GetBattleNotificationSettings();

            if (settings.Basic.ShowBattleDialog || settings.Basic.ShowMapDialog)
            {
                bool mapOK = SetMap(battle, showCurrent, simulation);

                double timeLeft = battle.TimeLeft;
                if (settings.Basic.ShowBattleDialog)
                    bn = new BattleNotification(battle, timeLeft, 0, settings);

                int height = bn == null ? 0 : bn.Height + 20;
                mn = new MapNotification(battle, timeLeft, height, MapSizeIndexToWidth(settings.Basic.MapSize), mapOK, settings);
            }

            SetupWindowsDisplayBehaviour(settings);

            if (settings.Basic.ShowMapDialog)
                m.ShowNotification(mn);
            if (settings.Basic.ShowBattleDialog)
                m.ShowNotification(bn);

            SetupSound(settings);
            SetupLifeTime(settings);
        }

        private void SetupLifeTime(BattleNotificationSettings settings)
        {
            if (settings.Basic.LifeSeconds > 0)
            {
                notificationTimer.Interval = Convert.ToInt32(new TimeSpan(0, 0, settings.Basic.LifeSeconds).TotalMilliseconds);
                notificationTimer.Tick += new EventHandler(OnTimedEvent);
                notificationTimer.Start();
            }
        }

        private void SetupWindowsDisplayBehaviour(BattleNotificationSettings settings)
        {
            if (!settings.General.ShowOnTop
                || !settings.General.ShowOverFullScreen
                && ForegroundWindowHelper.IsForegroundWindowOnDisplayScreen(settings.Basic.DisplayScreen)
                && ForegroundWindowHelper.IsForegroundWindowFullScreen())
            {
                if (mn != null)
                    mn.TopMost = false;
                if (bn != null)
                    bn.TopMost = false;
            }
        }

        private void SetupSound(BattleNotificationSettings settings)
        {
            if (settings.Basic.PlaySound)
                if (settings.Basic.UseCustomSound &&
                    !string.IsNullOrEmpty(settings.Basic.SoundPath) && File.Exists(settings.Basic.SoundPath))
                    player.PlaySound(settings.Basic.SoundPath, settings.Basic.DefaultSound);
                else
                    player.PlayDefaultSound(settings.Basic.DefaultSound);
        }

        private bool SetMap(Battle battle, bool showCurrent, bool simulation)
        {
            try
            {
                if (battle.Type.HasFlag(BattleType.OneHourTT) && !simulation)
                    Map = Properties.Resources.OneHourTTMap;
                else if (!showCurrent || downloadCurrentMap || Map == null || !battle.MapId.Equals(lastLoadedMapId))
                {
                    downloadCurrentMap = false;
                    lastLoadedMapId = battle.MapId;
                    Map = WebRequestHelper.GetImageFromUrl(battle.MapUrl + "/600");
                }
            }
            catch (Exception ex)
            {
                if (!simulation)
                {
                    Logger.Log(200, ex);
                    return false;
                }
                else
                    downloadCurrentMap = true;
                Map = Properties.Resources.about;
            }

            return true;
        }

        private void OnTimedEvent(object source, EventArgs e)
        {
            if (notificationTimer.Enabled)
            {
                if (!(bn != null && bn.KeepShown) && !(mn != null && mn.KeepShown))
                {
                    EndBattleNotification();
                }
                notificationTimer.Stop();
            }
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

        #endregion
    }
}
