using BattleNotifier.Controller;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Reflection;
using BattleNotifier.Model;
using BattleNotifier.Utils;
using System.Text;

namespace BattleNotifier.View
{
    public partial class MapNotification : Form
    {
        private int countdown;
        private int battleDuration;

        public MapNotification() { }

        public MapNotification(Battle battle, double timeLeft, int startHeight, int mapDesiredWidth, MapSettings settings)
        {
            InitializeComponent();
            InitializePicture(mapDesiredWidth);
            SetupDialogLocation(startHeight);

            battleDuration = battle.Duration;
            SetupTextOverMap(battle, timeLeft, settings);
        }

        private void SetupTextOverMap(Battle battle, double timeLeft, MapSettings settings)
        {
            Color color = settings.TextMapColor;
            Locate locate = new Locate(PictureBox.Width, PictureBox.Height);

            if (timeLeft > 0)
                if (settings.ShowLifeSeconds)
                {
                    TimerLabel.ForeColor = color;
                    TimerLabel.Parent = PictureBox;
                    TimerLabel.Visible = true;
                    StartBattleCountdown(Convert.ToInt32(timeLeft));
                    locate.BottomCenter(TimerLabel, 5);
                }

            if (settings.ShowLevelName || settings.ShowDesigner)
            {
                HeaderLabel.ForeColor = color;
                HeaderLabel.Parent = PictureBox;
                HeaderLabel.Visible = true;
                StringBuilder text = new StringBuilder();
                if (settings.ShowLevelName)
                    text.Append(battle.Name);
                if (settings.ShowDesigner)
                    text.Append(" by " + battle.Desginer);
                HeaderLabel.Text = text.ToString();
                locate.BottomRight(HeaderLabel, 5);
            }

            if (settings.ShowType)
            {
                TypeLabel.ForeColor = color;
                TypeLabel.Parent = PictureBox;
                TypeLabel.Visible = true;
                TypeLabel.Text = EnumExtensions.GetDescription(battle.Type);
                locate.BottomLeft(TypeLabel, 5);
            }
            if (settings.ShowAttributes)
            {
                AttributesLabel.ForeColor = color;
                AttributesLabel.Parent = PictureBox;
                AttributesLabel.Visible = true;
                AttributesLabel.Text = "battle.Attributes";
            }
        }

        private void StartBattleCountdown(int startTime)
        {
            countdown = startTime;
            BattleCountdownTimer_Tick(null, null);
            BattleCountdownTimer.Start();
        }

        private void BattleCountdownTimer_Tick(object sender, EventArgs e)
        {
            if (countdown > battleDuration * 60)
                TimerLabel.Text = "Starts in " + GetCountdownDisplayText(countdown - battleDuration * 60);
            else
            {
                if (countdown == 0)
                    BattleCountdownTimer.Stop();
                TimeSpan time = new TimeSpan(0, 0, countdown);
                TimerLabel.Text = GetCountdownDisplayText(countdown);
            }

            countdown--;
        }

        private string GetCountdownDisplayText(int seconds)
        {
            if (seconds <= 0)
                return "Battle finished";

            TimeSpan time = new TimeSpan(0, 0, seconds);
            string hours = time.Hours == 0 ? "" : time.Hours + ":";
            string mins = time.Hours > 0 && time.Minutes < 10 ? "0" + time.Minutes : time.Minutes.ToString();
            string secs = time.Seconds < 10 ? "0" + time.Seconds : time.Seconds.ToString();

            return hours + mins + ":" + secs;
        }

        private void InitializePicture(int desiredWidth)
        {
            Image map = NotificationsController.Instance.Map;
            int newWidth = desiredWidth;
            int aux = (desiredWidth * 100) / map.Width;
            int newHeight = (aux * map.Height) / 100;
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics gr = Graphics.FromImage(newImage))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(map, new Rectangle(0, 0, newWidth, newHeight));
            }

            this.Width = newImage.Width;
            this.Height = newImage.Height;
            PictureBox.Width = Width;
            PictureBox.Height = Height;

            PictureBox.Image = newImage;
        }

        private void SetupDialogLocation(int startHeight)
        {
            StartPosition = FormStartPosition.Manual;
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            Left = screenWidth - Width;
            Top = screenHeight - Height - startHeight - 20; ;
        }

        private void MapNotification_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private delegate void BlankDelegate();
        public void CloseForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new BlankDelegate(this.CloseForm));
            }
            else
            {
                this.Close();
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void MapNotification_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            MapNotification_MouseDown(sender, e);
        }
    }

    /// <summary>
    /// Helper class to locate controls on a parent control.
    /// </summary>
    public class Locate
    {
        private int width, height;

        /// <summary>
        /// Create a locate instance with the parent's width a height.
        /// </summary>
        public Locate(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public void TopLeft(Control control, int margin = 0)
        {
            control.Location = new Point(0 + margin, 0 + margin);
        }
        public void TopRight(Control control, int margin = 0)
        {
            control.Location = new Point(width - control.Width - margin, 0 + margin);
        }
        public void TopCenter(Control control, int margin = 0)
        {
            control.Location = new Point(XCenter(control), 0 + margin);
        }
        public void Center(Control control, int margin = 0)
        {
            control.Location = new Point(XCenter(control), YCenter(control));
        }
        public void BottomLeft(Control control, int margin = 0)
        {
            control.Location = new Point(0 + margin, height - control.Height - margin);
        }
        public void BottomRight(Control control, int margin = 0)
        {
            control.Location = new Point(width - control.Width - margin, height - control.Height - margin);
        }
        public void BottomCenter(Control control, int margin = 0)
        {
            control.Location = new Point(XCenter(control), height - control.Height - margin);
        }
        private int XCenter(Control control)
        {
            return ((width / 2) - control.Width / 2);
        }
        private int YCenter(Control control)
        {
            return ((width / 2) - control.Width / 2);
        }
    }
}
