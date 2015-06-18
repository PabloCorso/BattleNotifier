using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BattleNotifier.Controller;
using BattleNotifier.Model;

namespace BattleNotifier.View
{
    public partial class SettingsPanel : UserControl
    {
        public SettingsPanel()
        {
            InitializeComponent();
            this.ShowOnMapGroup.Click += new EventHandler(SettingsPanel_Click);
            this.GeneralSettingsGroup.Click += new EventHandler(SettingsPanel_Click);
            this.NotificationSoundGroup.Click += new EventHandler(SettingsPanel_Click);
            InitializeColorPicker();

#if DEBUG
            Simulate1Button.Visible = true;
            Simulate2Button.Visible = true;
            Simulate3Button.Visible = true;
            Simulate4Button.Visible = true;
            RandomNewBattleCheckBox.Visible = true;
#endif
        }

        public int GetSelecetedDefaultSound()
        {
            if (DefaultSoundComboBox.InvokeRequired)
                return (int)DefaultSoundComboBox.Invoke(new Func<int>(GetSelecetedDefaultSound));
            else
                return DefaultSoundComboBox.SelectedIndex;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Accept to reset all settings to default configuration.\nAll your settings and filters will be deleted.",
                                     "Reset to default settings",
                                     MessageBoxButtons.OKCancel);
            if (confirmResult == DialogResult.OK)
            {
                UserSettings.Reset();
            }
        }

        #region ColorPicker
        private void InitializeColorPicker()
        {
            foreach (Button button in ColorButtons)
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

        private void ShowColorButtons() { foreach (Button b in ColorButtons) b.Visible = true; }
        private void HideColorButtons() { foreach (Button b in ColorButtons) b.Visible = false; }
        private bool ColorButtonsVisible() { return b1.Visible; }
        #endregion

        private void SetSoundButton_Click(object sender, EventArgs e)
        {
            SoundOpenFileDialog.ShowDialog();
            CustomSoundPathTextBox.Text = SoundOpenFileDialog.FileName;
        }

        private void SettingsPanel_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void NewBattleButton_Click(object sender, EventArgs e)
        {
#if DEBUG
            if (RandomNewBattleCheckBox.Checked)
            {
                NotificationsController.Instance.SimulateRandomBattle();
                return;
            }
#endif
            NotificationsController.Instance.SimulateNewBattle();
        }

        private void HideToTraybarCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.Instance.SetHideToTraybarValue(HideToTraybarCheckBox.Checked);
        }

        private void Simulate1Button_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int duration = Convert.ToInt32(random.NextDouble() * (60 - 1) + 1);
            Battle battle = new Battle()
            {
                FileName = "Pob0989.lev",
                MapUrl = null,
                Duration = duration,
                Attributes = (BattleAttribute)15,
                Type = 0,
                StartedDateTime = DateTime.Now,
                Desginer = "Pab",
                Id = 90431
            };

            NotificationsController.Instance.ShowBattleNotification(BattleNotifierController.Instance.MainView, battle, (duration * 60) + 20, true, Properties.Resources.longmap1280);
        
        }

        private void Simulate2Button_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int duration = Convert.ToInt32(random.NextDouble() * (60 - 1) + 1);
            Battle battle = new Battle()
            {
                FileName = "Pob0989.lev",
                MapUrl = null,
                Duration = duration,
                Attributes = (BattleAttribute)15,
                Type = 0,
                StartedDateTime = DateTime.Now,
                Desginer = "Pab",
                Id = 90431
            };

            NotificationsController.Instance.ShowBattleNotification(BattleNotifierController.Instance.MainView, battle, (duration * 60) + 20, true, Properties.Resources.tallmap1280);
        }

        private void Simulate3Button_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int duration = Convert.ToInt32(random.NextDouble() * (60 - 1) + 1);
            Battle battle = new Battle()
            {
                FileName = "Pob0989.lev",
                MapUrl = null,
                Duration = duration,
                Attributes = (BattleAttribute)15,
                Type = 0,
                StartedDateTime = DateTime.Now,
                Desginer = "Pab",
                Id = 90431
            };

            NotificationsController.Instance.ShowBattleNotification(BattleNotifierController.Instance.MainView, battle, (duration * 60) + 20, true, Properties.Resources.tallsmallmap);
        }
    }
}
