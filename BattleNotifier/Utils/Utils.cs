using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BattleNotifier.Utils
{
    public static class Util
    {
        public static string FirstCharToUpper(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;
            else
                return input.Substring(0, 1).ToUpper() + input.Substring(1);
        }

        public static double MillisecondsToHours(double milliseconds)
        {
            return milliseconds / (1000 * 60 * 60);
        }
    }

    public static class ForegroundWindowHelper
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        private static extern IntPtr GetShellWindow();
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowRect(IntPtr hwnd, out RECT rc);

        private static IntPtr desktopHandle; //Window handle for the desktop
        private static IntPtr shellHandle; //Window handle for the shell

        public static bool IsForegroundWindowFullScreen()
        {
            //Get the handles for the desktop and shell now.
            desktopHandle = GetDesktopWindow();
            shellHandle = GetShellWindow();

            //Detect if the current app is running in full screen
            bool runningFullScreen = false;
            RECT appBounds;
            Rectangle screenBounds;
            IntPtr hWnd;

            //get the dimensions of the active window
            hWnd = GetForegroundWindow();
            if (hWnd != null && !hWnd.Equals(IntPtr.Zero))
            {
                //Check we haven't picked up the desktop or the shell
                if (!(hWnd.Equals(desktopHandle) || hWnd.Equals(shellHandle)))
                {
                    GetWindowRect(hWnd, out appBounds);
                    //determine if window is fullscreen
                    screenBounds = Screen.FromHandle(hWnd).Bounds;
                    if ((appBounds.Bottom - appBounds.Top) == screenBounds.Height && (appBounds.Right - appBounds.Left) == screenBounds.Width)
                    {
                        runningFullScreen = true;
                    }
                }
            }

            return runningFullScreen;
        }

        public static bool IsForegroundWindowOnDisplayScreen(int displayScreen)
        {
            IntPtr handle = GetForegroundWindow();
            if (handle == IntPtr.Zero) return false;

            Screen screen = Screen.PrimaryScreen;
            if (displayScreen <= Screen.AllScreens.Length && displayScreen > 0)
                screen = Screen.AllScreens[displayScreen - 1];

            return Screen.FromHandle(handle).Equals(screen);
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
    }

    public static class ImageExtensions
    {
        public static Image Resize(this Image image, int newWidth, int newHeight) 
        {
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics gr = Graphics.FromImage(newImage))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(image, new Rectangle(0, 0, newWidth, newHeight));
            }

            return newImage;
        }

        public static Image ChangeColor(this Image image, Color from, Color to)
        {
            image = ChangeColor(new Bitmap(image), from, to);
            return image;
        }

        public static Image ChangeColor(this Image image, Color to, List<Color> excluded = null) 
        {
            image = ChangeEveryColor(new Bitmap(image), to, excluded);
            return image;
        }

        private static Bitmap ChangeColor(Bitmap scrBitmap, Color from, Color to)
        {
            Color actualColor = new Color();
            Bitmap newBitmap = new Bitmap(scrBitmap.Width, scrBitmap.Height);
            for (int i = 0; i < scrBitmap.Width; i++)
            {
                for (int j = 0; j < scrBitmap.Height; j++)
                {
                    actualColor = scrBitmap.GetPixel(i, j);
                    if (actualColor.Equals(from))
                        newBitmap.SetPixel(i, j, to);
                    else
                        newBitmap.SetPixel(i, j, actualColor);
                }
            }
            return newBitmap;
        }

        private static Bitmap ChangeEveryColor(Bitmap scrBitmap, Color newColor, List<Color> excluded)
        {
            Color actualColor = new Color();
            Bitmap newBitmap = new Bitmap(scrBitmap.Width, scrBitmap.Height);
            for (int i = 0; i < scrBitmap.Width; i++)
            {
                for (int j = 0; j < scrBitmap.Height; j++)
                {
                    actualColor = scrBitmap.GetPixel(i, j);
                    if (excluded != null && excluded.Exists(actualColor))
                        newBitmap.SetPixel(i, j, actualColor);
                    else
                        newBitmap.SetPixel(i, j, newColor);
                }
            }
            return newBitmap;
        }

        private static bool Exists(this List<Color> colors, Color color)
        {
            foreach (Color item in colors)
            {
                if (item.ToArgb().Equals(color.ToArgb()))
                    return true;
            }

            return false;
        }

        private static Color Copy(this Color color)
        {
            if (color.IsKnownColor)
                return Color.FromKnownColor(color.ToKnownColor());

            if (color.IsNamedColor)
                return Color.FromName(color.Name);

            // this is better, then pass A,r,g,b separately
            return Color.FromArgb(color.ToArgb());
        }
    }

    public static class ChListExtensions
    {
        public static bool HasCheckedItems(this CheckedListBox chList)
        {
            for (int i = 0; i < chList.Items.Count; i++)
            {
                if (chList.GetItemChecked(i))
                    return true;
            }

            return false;
        }

        public static List<string> CheckedStringList(this CheckedListBox chList)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < chList.Items.Count; i++)
            {
                if (chList.GetItemChecked(i))
                    result.Add(chList.GetText(i));
            }

            return result;
        }

        public static List<string> ToStringList(this CheckedListBox chList)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < chList.Items.Count; i++)
                result.Add(chList.GetText(i));

            return result;
        }

        public static void AddOrderedFromBottom(this CheckedListBox chList, string item, bool check = false)
        {
            for (int i = chList.Items.Count - 1; i >= 0; i--)
            {
                if (string.Compare(item.ToLower(), chList.GetText(i).ToLower()) >= 0)
                {
                    chList.InsertAt(i + 1, item, check);
                    return;
                }

                if (i == 0)
                {
                    chList.InsertAt(0, item, check);
                    return;
                }
            }

            if (chList.Items.Count == 0)
                chList.Items.Add(item, check);
        }

        public static void InsertAt(this CheckedListBox chList, int index, string item, bool check)
        {
            CheckedListBox aux = new CheckedListBox();
            bool itemAdded = false;
            for (int i = 0; i < chList.Items.Count; i++)
            {
                if (i == index && !itemAdded)
                {
                    aux.Items.Add(item, check);
                    itemAdded = true;
                    i--;
                }
                else
                {
                    aux.Items.Add(chList.GetText(i), chList.GetItemChecked(i));
                }
            }

            if (!itemAdded)
            {
                chList.Items.Add(item, check);
            }
            else
            {
                chList.Items.Clear();
                for (int i = 0; i < aux.Items.Count; i++)
                    chList.Items.Add(aux.GetText(i), aux.GetItemChecked(i));
            }
        }

        public static bool Contains(this CheckedListBox chList, string input)
        {
            for (int i = 0; i < chList.Items.Count; i++)
            {
                if (input.Equals(chList.GetText(i), StringComparison.InvariantCultureIgnoreCase))
                    return true; ;
            }

            return false;
        }

        public static string GetText(this CheckedListBox chList, int index)
        {
            return chList.GetItemText(chList.Items[index]);
        }

        /// <summary>
        /// Left mouse click: check/uncheck the item.
        /// Middle mouse click: remove item.
        /// Right mouse click: send item from chList1 to chList2.
        /// </summary>
        /// <param name="chList1"> The handled checkedListBox. </param>
        /// <param name="chList2"> The dual checkedListBox. </param>
        /// <param name="e"> The mouse click event. </param>
        public static void DualChListMouseEvent(CheckedListBox chList1, CheckedListBox chList2, MouseEventArgs e, Point mousePosition, bool useDual = true)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                for (int i = 0; i < chList1.Items.Count; i++)
                {
                    if (i != 0 || useDual)
                    {
                        if (chList1.GetItemRectangle(i).Contains(chList1.PointToClient(mousePosition)))
                        {
                            chList2.AddOrderedFromBottom(chList1.GetText(i), chList1.GetItemChecked(i));
                            chList1.Items.RemoveAt(i);
                        }
                    }
                }
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Middle)
            {
                for (int i = 0; i < chList1.Items.Count; i++)
                {
                    if (i != 0 || useDual)
                    {
                        if (chList1.GetItemRectangle(i).Contains(chList1.PointToClient(mousePosition)))
                        {
                            chList1.Items.RemoveAt(i);
                        }
                    }
                }
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                for (int i = 0; i < chList1.Items.Count; i++)
                {
                    if (chList1.GetItemRectangle(i).Contains(chList1.PointToClient(mousePosition)))
                    {
                        switch (chList1.GetItemCheckState(i))
                        {
                            case CheckState.Checked:
                                chList1.SetItemCheckState(i, CheckState.Unchecked);
                                break;
                            case CheckState.Indeterminate:
                            case CheckState.Unchecked:
                                chList1.SetItemCheckState(i, CheckState.Checked);
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Move an existing item to the top of the list, order the rest.
        /// </summary>
        public static void MoveToTop(this CheckedListBox chList, string item)
        {
            int index = chList.GetItemIndex(item);
            bool check = chList.GetItemChecked(index);
            chList.Items.RemoveAt(index);
            chList.InsertAt(0, item, check);
        }

        public static bool GetItemCheck(this CheckedListBox chList, string item)
        {
            return chList.GetItemChecked(ChListExtensions.GetItemIndex(chList, item));
        }

        public static int GetItemIndex(this CheckedListBox chList, string item)
        {
            for (int i = 0; i < chList.Items.Count; i++)
            {
                if (chList.GetText(i).Equals(item))
                {
                    return i;
                }
            }

            throw new ArgumentException();
        }
    }

    public static class EnumExtensions
    {
        public static IEnumerable<Enum> GetFlags(Enum input)
        {
            foreach (Enum value in Enum.GetValues(input.GetType()))
                if (input.HasFlag(value))
                    yield return value;
        }

        public static string GetDescription(object enumValue, string defDesc = "")
        {
            FieldInfo fi = enumValue.GetType().GetField(enumValue.ToString());

            if (null != fi)
            {
                object[] attrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }

            return defDesc;
        }
    }
}
