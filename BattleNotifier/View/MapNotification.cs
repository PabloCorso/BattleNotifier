using BattleNotifier.Controller;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BattleNotifier.View
{
    public partial class MapNotification : Form
    {
        // TODO diferentes resolusiones de mapa. small medium big or ress.
        public MapNotification(int startHeight, int mapDesiredWidth)
        {
            InitializeComponent();
            InitializePicture(mapDesiredWidth);
            SetupDialogLocation(startHeight);
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
}
