using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleNotifier.View
{
    public partial class SettingsPanel : UserControl
    {
        public SettingsPanel()
        {
            InitializeComponent();
            InitializeColorPicker();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Accept to reset all settings to default configuration.\nAll your settings and designers list will be deleted.\nThe program will be restarted to complete this operation.",
                                     "Reset to default settings",
                                     MessageBoxButtons.OKCancel);
            if (confirmResult == DialogResult.Yes)
            {
                // If 'Yes', do something here.
            }
        }

        #region ColorPicker
        private void InitializeColorPicker()
        {
            foreach(Button button in ColorButtons)
                button.Click += new System.EventHandler(ColorPicked);
        }

        private void ColorPicker_Click(object sender, EventArgs e)
        {
            if (!ColorButtonsVisible())
                ShowColorButtons();
            else
                HideColorButtons();
        }

        private void ColorPicked(object sender, EventArgs e)
        {
            Color pickedColor = (sender as Button).BackColor;
            ColorPicker.BackColor = pickedColor;
            ColorPicker.FlatAppearance.MouseDownBackColor = pickedColor;
            ColorPicker.FlatAppearance.MouseOverBackColor = pickedColor;
            HideColorButtons();
        }

        private List<Button> ColorButtons
        {
            get
            {
                List<Button> buttons = new List<Button>();
                for (int i = 1; i <= 32; i++)
                    buttons.Add(this.Controls.Find("b" + i, true).FirstOrDefault() as Button);

                return buttons;
            }
        }

        private void ShowColorButtons(){ foreach(Button b in ColorButtons) b.Visible = true; }
        private void HideColorButtons() { foreach (Button b in ColorButtons) b.Visible = false; }
        private bool ColorButtonsVisible(){ return b1.Visible; }
#endregion
    }
}
