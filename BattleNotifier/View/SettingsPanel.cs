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
        BattleNotifierController battleNotifier;
        public SettingsPanel()
        {
            InitializeComponent();
            this.battleNotifier = BattleNotifierController.Instance;
            this.ShowOnMapGroup.Click += new EventHandler(SettingsPanel_Click);
            this.GeneralSettingsGroup.Click += new EventHandler(SettingsPanel_Click);
            this.NotificationSoundGroup.Click += new EventHandler(SettingsPanel_Click);
            InitializeColorPicker();
            InitializeHelpDescriptions();

#if DEBUG
            RandomNewBattleCheckBox.Visible = true;
#endif
        }

        private void InitializeHelpDescriptions()
        {
            NotificationSoundGroup.MouseEnter += ShowHelpDescription;
            NotificationSoundGroup.MouseLeave += ClearSoundGroupHelpDescription;
            ShowOnMapGroup.MouseEnter += ShowHelpDescription;
            ShowOnMapGroup.MouseLeave += ClearMapGroupHelpDescription;
            ShowOnTopCheckBox.MouseEnter += ShowHelpDescription;
            ShowOnTopCheckBox.MouseLeave += ClearHelpDescription;
            StartupCheckBox.MouseEnter += ShowHelpDescription;
            StartupCheckBox.MouseLeave += ClearHelpDescription;
            FadeCheckBox.MouseEnter += ShowHelpDescription;
            FadeCheckBox.MouseLeave += ClearHelpDescription;
            HideToTraybarCheckBox.MouseEnter += ShowHelpDescription;
            HideToTraybarCheckBox.MouseLeave += ClearHelpDescription;
            TransparentCheckBox.MouseEnter += ShowHelpDescription;
            TransparentCheckBox.MouseLeave += ClearHelpDescription;
            HidePrintCheckBox.MouseEnter += ShowHelpDescription;
            HidePrintCheckBox.MouseLeave += ClearHelpDescription;
            NewBattleButton.MouseEnter += ShowHelpDescription;
            NewBattleButton.MouseLeave += ClearHelpDescription;
        }

        private void ShowHelpDescription(object sender, EventArgs e)
        {
            battleNotifier.MainView.ShowHelpDescription(ToolTip.GetToolTip((Control)sender).ToString(), 2);
        }

        private void ClearHelpDescription(object sender, EventArgs e)
        {
            battleNotifier.MainView.ClearHelpDescription();
        }

        private void ClearSoundGroupHelpDescription(object sender, EventArgs e)
        {
            Control control = this.GetChildAtPoint(this.PointToClient(MousePosition));
            if (control != NotificationSoundGroup)
            {
                battleNotifier.MainView.ClearHelpDescription();
            }
        }

        private void ClearMapGroupHelpDescription(object sender, EventArgs e)
        {
            Control control = this.GetChildAtPoint(this.PointToClient(MousePosition));
            if (control != ShowOnMapGroup)
            {
                battleNotifier.MainView.ClearHelpDescription();
            }
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

        private void DefaultSoundComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            SettingsPanel_Click(sender, e);
        }
    }
}
