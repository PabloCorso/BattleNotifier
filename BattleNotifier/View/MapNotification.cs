using BattleNotifier.Controller;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BattleNotifier.Model;
using BattleNotifier.Utils;
using System.Text;
using System.Collections.Generic;
using Utils;

namespace BattleNotifier.View
{
#if DEBUG
    public partial class MapNotification : MiddleClass
#else
    public partial class MapNotification : BaseNotification
#endif
    {
        private bool tooSmallMap = false;
        private bool showOnlyTimerAndType = false;
        private bool mapLoaded;
        private Battle battle;

        public MapNotification(Battle battle, double timeLeft, int startHeight, int mapDesiredWidth, bool mapLoaded, BattleNotificationSettings settings)
            : base(settings, battle.Duration)
        {
            InitializeComponent();
            this.battle = battle;

            InitializeBattleTimer(timeLeft);
            InitializePicture(mapDesiredWidth);
            SetupDialogLocation(settings.Basic.DisplayScreen, startHeight);

            this.mapLoaded = mapLoaded;
            SetupTextOverMap(battle, timeLeft, settings.Map);
        }

        #region BaseNotification implementation

        protected override string GetCountdownBattleEndedText()
        {
            return "-";
        }

        protected override void SetCountdownText(string countdownText)
        {
            TimerLabel.Text = countdownText;
        }

        protected override void CloseFormParticulars()
        {
            if (PictureBox != null)
            {
                Image i = PictureBox.Image;
                PictureBox.Image = null;
                if (i != null)
                    i.Dispose();
            }
        }

        #endregion

        #region Initialize, Labels

        private void SetupTextOverMap(Battle battle, double timeLeft, MapSettings settings)
        {
            Color color = settings.TextMapColor;
            Locate locate = new Locate(PictureBox.Width, PictureBox.Height);

            if (settings.ShowLifeSeconds)
            {
                TimerLabel.ForeColor = color;
                TimerLabel.Parent = PictureBox;
                TimerLabel.Visible = true;
                locate.BottomCenter(TimerLabel, 20);
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
                HeaderLabel.MaximumSize = new Size(PictureBox.Width, PictureBox.Height);
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
                List<string> attributes = new List<string>();
                foreach (BattleAttribute att in EnumExtensions.GetFlags(battle.Attributes))
                    attributes.Add(EnumExtensions.GetDescription(att));

                AttributesLabel.Text = Util.FirstCharToUpper(string.Join(", ", attributes).ToLower());
                AttributesLabel.MaximumSize = new Size(PictureBox.Width, PictureBox.Height);
                int margin = AttributesLabel.Height + 2;
                locate.BottomCenter(AttributesLabel, 20);
                locate.MoveUp(TimerLabel, margin);
            }

            // Check for collisions.
            if ((settings.ShowDesigner || settings.ShowLevelName) && settings.ShowType
                && HeaderLabel.Width > PictureBox.Width - TypeLabel.Width - 10)
            {
                locate.ToLeft(HeaderLabel, 5);
                locate.MoveUp(TypeLabel, HeaderLabel.Height + 2);
                locate.MoveUp(TimerLabel, HeaderLabel.Height + 2);
                if (settings.ShowAttributes)
                {
                    locate.BottomRight(AttributesLabel, 5);
                    locate.MoveUp(AttributesLabel, HeaderLabel.Height + 2);
                    locate.BottomRight(TimerLabel, 5);
                    locate.MoveUp(TimerLabel, AttributesLabel.Height + HeaderLabel.Height + TypeLabel.Height + 2 );
                    if (AttributesLabel.Width > PictureBox.Width - TypeLabel.Width - 10)
                    {
                        locate.ToLeft(AttributesLabel, 5);
                        locate.MoveUp(TypeLabel, AttributesLabel.Height + 2);
                    }
                }
                else if (settings.ShowLifeSeconds && TimerLabel.Location.Y + TimerLabel.Height > HeaderLabel.Location.Y)
                {
                    // Timer is over Header, take out designer to fit everything.
                    if (!showOnlyTimerAndType)
                    {
                        showOnlyTimerAndType = true;
                        HeaderLabel.Visible = false;
                        settings.ShowDesigner = false;
                        tooSmallMap = true;
                        SetupTextOverMap(battle, timeLeft, settings);
                    }
                }
            }

            // Check if important information is not shown.
            if (settings.ShowLifeSeconds)
            {
                if (TimerLabel.Location.Y < 0)
                {
                    if (!tooSmallMap)
                    {
                        tooSmallMap = true;
                        AttributesLabel.Visible = false;
                        settings.ShowAttributes = false;
                        SetupTextOverMap(battle, timeLeft, settings);
                    }
                    else
                    {
                        HeaderLabel.Visible = false;
                        locate.BottomRight(TimerLabel, 5);
                        if (settings.ShowType)
                            locate.BottomLeft(TypeLabel, 5);
                    }
                }
            }
        }

        private void InitializePicture(int desiredWidth)
        {
            try
            {
                Image map = NotificationsController.Instance.Map;
                int newWidth = 0;
                int newHeight = 0;

                if (map.Width > map.Height)
                {
                    newWidth = desiredWidth;
                    int aux = (desiredWidth * 100) / map.Width;
                    newHeight = (aux * map.Height) / 100;
                }
                else
                {
                    newHeight = desiredWidth;
                    int aux = (desiredWidth * 100) / map.Height;
                    newWidth = (aux * map.Width) / 100;
                }

                Image newImage = null;
                newImage = map.Resize(newWidth, newHeight);

                this.Width = newImage.Width;
                this.Height = newImage.Height;
                PictureBox.Width = Width;
                PictureBox.Height = Height;

                PictureBox.Image = newImage;
            }
            catch (Exception ex)
            {
                // InvalidOperationException? lock map?
                Logger.Log(301, ex);
            }
        }

        #endregion

        #region Mouse click behaviour

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void MapNotification_MouseDown(object sender, MouseEventArgs e)
        {
            MaintainShown = true;

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
            else if (e.Button == MouseButtons.Right)
            {
                ContextMenu contextMenu = new ContextMenu();
                MenuItem reloadMenuItem = new MenuItem();
                MenuItem closeMenuItem = new MenuItem();
                MenuItem minimizeMenuItem = new MenuItem();

                //if (!mapLoaded)
                //{
                    // Initialize reloadMenuItem
                    reloadMenuItem.Index = 0;
                    reloadMenuItem.Text = "Reload";
                    reloadMenuItem.Click += new EventHandler(ReloadMenuItem_Click);
                    contextMenu.MenuItems.Add(reloadMenuItem);
                //}

                // Initialize closeMenuItem
                closeMenuItem.Index = 1;
                closeMenuItem.Text = "Close";
                closeMenuItem.Click += new EventHandler(CloseMenuItem_Click);

                // Initialize minimizeMenuItem
                minimizeMenuItem.Index = 2;
                minimizeMenuItem.Text = "Minimize";
                minimizeMenuItem.Click += new EventHandler(MinimizeMenuItem_Click);

                // Set Start and Exit as startup options.
                contextMenu.MenuItems.Add(closeMenuItem);
                contextMenu.MenuItems.Add(minimizeMenuItem);
                contextMenu.Show(this, e.Location);
            }
            else if (e.Button == MouseButtons.Middle)
            {
                NotificationsController.Instance.EndBattleNotification();
            }
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            if (!closing)
                NotificationsController.Instance.EndBattleNotification();
        }

        private void ReloadMenuItem_Click(object sender, EventArgs e)
        {
            NotificationsController.Instance.ShowBattleNotification(BattleNotifierController.Instance.MainView, battle);
        }

        private void MinimizeMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            MapNotification_MouseDown(sender, e);
        }

        #endregion
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
        public void ToLeft(Control control, int margin = 0)
        {
            control.Location = new Point(0 + margin, control.Location.Y);
        }
        public void ToRight(Control control, int margin = 0)
        {
            control.Location = new Point(width - control.Width - margin, control.Location.Y);
        }
        public void MoveUp(Control control, int margin)
        {
            control.Location = new Point(control.Location.X, control.Location.Y - margin);
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
