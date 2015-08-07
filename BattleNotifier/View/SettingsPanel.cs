using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BattleNotifier.Controller;
using Microsoft.Win32;
using Utils;

namespace BattleNotifier.View
{
    public partial class SettingsPanel : UserControl
    {
        private BattleNotifierController battleNotifier;
        // The path to the key where Windows looks for startup applications
        private RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        private string thisExe = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

        public SettingsPanel()
        {
            InitializeComponent();
            battleNotifier = BattleNotifierController.Instance;
            ShowOnMapGroup.Click += new EventHandler(SettingsPanel_Click);
            GeneralSettingsGroup.Click += new EventHandler(SettingsPanel_Click);
            NotificationSoundGroup.Click += new EventHandler(SettingsPanel_Click);
            InitializeColorPicker();
            InitializeHelpDescriptions();

            if (ShowOverFullScreenCheckBox.Checked)
                ShowOnTopCheckBox.Checked = true;
        }

        public void UpdateRunOnWinStartupRegistryKey()
        {
            RunOnWinStartupCheckBox_MouseUp(null, null);
        }

        #region Helping descriptions

        private void InitializeHelpDescriptions()
        {
            NotificationSoundGroup.MouseEnter += ShowHelpDescription;
            NotificationSoundGroup.MouseLeave += ClearSoundGroupHelpDescription;
            ShowOnMapGroup.MouseEnter += ShowHelpDescription;
            ShowOnMapGroup.MouseLeave += ClearMapGroupHelpDescription;
            ShowOnTopCheckBox.MouseEnter += ShowHelpDescription;
            ShowOnTopCheckBox.MouseLeave += ClearHelpDescription;
            ShowOverFullScreenCheckBox.MouseEnter += ShowHelpDescription;
            ShowOverFullScreenCheckBox.MouseLeave += ClearHelpDescription;
            StartupCheckBox.MouseEnter += ShowHelpDescription;
            StartupCheckBox.MouseLeave += ClearHelpDescription;
            RunOnWinStartupCheckBox.MouseEnter += ShowHelpDescription;
            RunOnWinStartupCheckBox.MouseLeave += ClearHelpDescription;
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

        #endregion

        #region Sound settings

        private void SetSoundButton_Click(object sender, EventArgs e)
        {
            SoundOpenFileDialog.ShowDialog();
            CustomSoundPathTextBox.Text = SoundOpenFileDialog.FileName;
        }

        public int GetSelecetedDefaultSound()
        {
            if (DefaultSoundComboBox.InvokeRequired)
                return (int)DefaultSoundComboBox.Invoke(new Func<int>(GetSelecetedDefaultSound));
            else
                return DefaultSoundComboBox.SelectedIndex;
        }

        private void DefaultSoundComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            SettingsPanel_Click(sender, e);
        }

        #endregion

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

        #region General settings

        private void HideToTraybarCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UserSettings.Instance.SetHideToTraybarValue(HideToTraybarCheckBox.Checked);
        }

        private void RunOnWinStartupCheckBox_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                bool registered = rk.GetValue(thisExe) == null ? false : true;

                if (registered)
                    UnregisterFromWinStartup();

                if (RunOnWinStartupCheckBox.Checked)
                    RegisterToWinStartup();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry, failed to get access to the registry. The operation could not be done.", "Ban Pab!", MessageBoxButtons.OK);
                RunOnWinStartupCheckBox.Checked = false;
                Logger.Log(700, ex);
            }
        }

        private void RegisterToWinStartup()
        {
            rk.SetValue(thisExe, "\"" + Application.ExecutablePath.ToString() + "\" /startminimized");
        }

        private void UnregisterFromWinStartup()
        {
            rk.DeleteValue(thisExe, false);
        }

        private void ShowOnTopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!ShowOnTopCheckBox.Checked)
                ShowOverFullScreenCheckBox.Checked = false;
        }

        private void ShowOverFullScreenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowOverFullScreenCheckBox.Checked)
                ShowOnTopCheckBox.Checked = true;
        }

        #endregion

        private void SettingsPanel_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
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

        private void NewBattleButton_Click(object sender, EventArgs e)
        {
            NotificationsController.Instance.SimulateNewBattle();
        }
    }
}
