﻿using System;
using System.Windows.Forms;
using BattleNotifier.Model;
using Utils;

namespace BattleNotifier.View
{
    public abstract partial class BaseNotification : Form
    {
        private Timer fadeTimer;
        private Timer battleTimer;
        private int countdown;
        private int battleDuration;
        private BattleNotificationSettings settings;

        public BaseNotification() { }

        public BaseNotification(BattleNotificationSettings settings, int battleDuration, double timeLeft)
        {
            InitializeComponent();
            this.settings = settings;
            this.battleDuration = battleDuration;

            if (settings.General.UseFadeEffect)
                InitializeFadeEffect();
        }

        #region Fade Effect
        private void InitializeFadeEffect()
        {
            Opacity = 0.0;
            fadeTimer = new Timer();
            fadeTimer.Interval = 100;
            fadeTimer.Tick += new EventHandler(FadeIn);
            fadeTimer.Start();
        }

        private void FadeIn(object sender, EventArgs e)
        {
            if (Opacity < 1)
            {
                Opacity += 0.1;
            }
            else
            {
                fadeTimer.Stop();
            }
        }

        private void FadeOut(object sender, EventArgs e)
        {
            if (Opacity > 0)
            {
                Opacity -= 0.1;
            }
            else
            {
                fadeTimer.Stop();
                fadeTimer.Tick -= new EventHandler(FadeOut);
                Close();
            }
        }
        #endregion

        #region Battle Timer
        protected void InitializeBattleTimer(double timeLeft)
        {
            if (timeLeft > 0)
                StartBattleCountdown(Convert.ToInt32(timeLeft));
            else
                SetCountdownText(GetCountdownDisplayText(Convert.ToInt32(timeLeft)) + " / " + battleDuration + ":00");

        }

        protected void StartBattleCountdown(int startTime)
        {
            countdown = startTime;
            battleTimer = new Timer();
            battleTimer.Interval = 1000;
            battleTimer.Tick += new EventHandler(BattleTimer_Tick);
            BattleTimer_Tick(null, null);
            battleTimer.Start();
        }

        protected abstract void SetCountdownText(string countdownText);

        private void BattleTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate () { BattleTimer_Tick(sender, e); }));
                }
                else
                {
                    if (countdown > battleDuration * 60)
                        SetCountdownText("Starts in " + GetCountdownDisplayText(countdown - battleDuration * 60));
                    else
                    {
                        if (countdown == 0)
                            battleTimer.Stop();
                        TimeSpan time = new TimeSpan(0, 0, countdown);
                        string display = GetCountdownDisplayText(countdown);
                        SetCountdownText(display + " / " + battleDuration + ":00");
                    }

                    countdown--;
                }
            }
            catch (ObjectDisposedException ex)
            {
                // Timer ticked while form being disposed. Fixed using forms timer.
                Logger.Log(300, ex);
            }
        }

        protected abstract string GetCountdownBattleEndedText();

        private string GetCountdownDisplayText(int seconds)
        {
            if (seconds <= 0)
                return GetCountdownBattleEndedText();

            TimeSpan time = new TimeSpan(0, 0, seconds);
            string hours = time.Hours == 0 ? "" : time.Hours + ":";
            string mins = time.Hours > 0 && time.Minutes < 10 ? "0" + time.Minutes : time.Minutes.ToString();
            string secs = time.Seconds < 10 ? "0" + time.Seconds : time.Seconds.ToString();

            return hours + mins + ":" + secs;
        }
        #endregion

        #region Close Form
        protected abstract void CloseFormParticulars();

        private delegate void BlankDelegate();

        internal void CloseForm()
        {
            if (InvokeRequired)
            {
                Invoke(new BlankDelegate(CloseForm));
            }
            else
            {
                CloseFormParticulars();

                if (battleTimer != null)
                {
                    battleTimer.Stop();
                    battleTimer.Tick -= BattleTimer_Tick;
                    battleTimer = null;
                }

                if (settings.General.UseFadeEffect)
                {
                    if (fadeTimer.Enabled)
                        fadeTimer.Stop();
                    fadeTimer.Tick -= new EventHandler(FadeIn);
                    fadeTimer.Tick += new EventHandler(FadeOut);
                    fadeTimer.Start();
                }
                else
                {
                    Close();
                }
            }
        }
        #endregion
    }
}
