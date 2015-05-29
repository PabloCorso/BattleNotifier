using System;
using System.Drawing;
using System.Windows.Forms;

namespace BattleNotifier.View
{
    public partial class MapNotification : TransDialog
    {
        // TODO diferentes resolusiones de mapa. small medium big or ress.
        // TODO fix map, bottom is cutted.
        public MapNotification(Image map)
        {
            InitializeComponent();
            this.Width = map.Width;
            this.Height = map.Height;
            PictureBox.Image = map;
        }

        public void EndNotification()
        {
            this.Close();
        }

        private void MapNotificationTimer_Tick(object sender, EventArgs e)
        {
            MapNotificationTimer.Stop();
            EndNotification();
        }

        private void MapNotification_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        public int Interval
        {
            set { this.MapNotificationTimer.Interval = value; }
        }
    }
}
