using System;
using System.Windows.Forms;
using BattleNotifier.Model;

namespace BattleNotifier.View
{
    public abstract partial class BaseNotification : Form
    {
        private Timer fadeTimer;
        private BattleNotificationSettings settings;

        public BaseNotification() { }

        public BaseNotification(BattleNotificationSettings settings)
        {
            InitializeComponent();
            this.settings = settings;

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
