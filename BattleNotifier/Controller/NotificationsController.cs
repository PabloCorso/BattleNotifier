using BattleNotifier.Model;
using BattleNotifier.Utils;
using BattleNotifier.View;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Media;
using System.Windows.Forms;
using System.Timers;

namespace BattleNotifier.Controller
{
    public class NotificationsController
    {
        private System.Timers.Timer notificationTimer = new System.Timers.Timer();

        private static NotificationsController instance;
        private BattleNotification bn;
        private MapNotification mn;
        private WMPLib.WindowsMediaPlayer player;
        public Image Map { get; private set; }
        private NotificationsController()
        {
        }

        public static NotificationsController Instance
        {
            get
            {
                if (instance == null)
                    instance = new NotificationsController();

                return instance;
            }
        }

        public void ShowBattleNotification(Battle battle, int timeLeft, BattleNotificationSettings settings)
        {
            ClearBattleNotification();

            if (settings.ShowBattleDialog || settings.ShowMapDialog)
            {
                Map = WebRequestHelper.GetImageFromUrl(battle.MapUrl);

                if(settings.ShowBattleDialog)
                    bn = new BattleNotification(battle, timeLeft, settings);
                if(settings.ShowMapDialog)
                    mn = new MapNotification(bn.Height, MapSizeIndexToWidth(settings.MapSize));
            }

            if (settings.ShowBattleDialog)
                bn.Show();
            if (settings.ShowMapDialog)
                mn.Show();

            // Play sound.
            if (settings.PlaySound)
                if (!string.IsNullOrEmpty(settings.SoundPath) && File.Exists(settings.SoundPath))
                    PlaySound(settings.SoundPath);
                else
                    PlayDefaultSound();

            if (settings.LifeSeconds > 0)
            {
                notificationTimer.Interval = new TimeSpan(0,0,settings.LifeSeconds).TotalMilliseconds;
                notificationTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                notificationTimer.Start();
            }
        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            EndBattleNotification();
            notificationTimer.Stop();
        }

        private void PlaySound(string path)
        {
            try
            {
                player = new WMPLib.WindowsMediaPlayer();
                player.URL = path;
                player.controls.play();
            }
            catch (Exception)
            {
                PlayDefaultSound();
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

        private void PlayDefaultSound()
        {
            SoundPlayer sound = new SoundPlayer(Properties.Resources.smb_1_up);
            sound.Play();
        }

        private void ClearBattleNotification()
        {
            try
            {
                if (bn != null)
                    bn.CloseForm();
                if (mn != null)
                    mn.CloseForm();
                StopSound();
                Map = null;

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
            
        }

        public void MapNotificationClosed()
        {
            
        }

        private int MapSizeIndexToWidth(int mapSize)
        {
            switch (mapSize) 
            {
                case 0:
                    return 180;
                case 1:
                    return 320;
                case 2:
                    return 480;
                default:
                    return 320;
            }
        }
    }
}
