using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
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
