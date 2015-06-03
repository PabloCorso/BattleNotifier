using BattleNotifier.Utils;
using BattleNotifier.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Settings = BattleNotifier.Properties.Settings;

namespace BattleNotifier
{
    public class ConfigStorageBroker
    {
        Main mainView;
        MainPanel mainPanel;
        SettingsPanel settingsPanel;
        private static ConfigStorageBroker instance;

        public static void InitializeConfigStorageBroker(Main mainView, MainPanel mainPanel, SettingsPanel settingsPanel)
        {
            if (instance == null)
                instance = new ConfigStorageBroker(mainView, mainPanel, settingsPanel);
        }

        public static ConfigStorageBroker Instance
        {
            get
            {
                return instance;
            }
        }

        private ConfigStorageBroker(Main mainView, MainPanel mainPanel, SettingsPanel settingsPanel) 
        {
            this.mainView = mainView;
            this.mainPanel = mainPanel;
            this.settingsPanel = settingsPanel;
        }

        #region User settings
        public static void ResetUserSettings()
        {
            Settings.Default.Reset();
            instance.mainPanel.BlackListChListBox.Items.Clear();
            instance.mainPanel.DesignersChListBox.Items.Clear();
            instance.mainPanel.BattleTypesChListBox.Items.Clear();
            LoadUserSettings();
        }

        public static void LoadUserSettings()
        {
            Settings settings = Settings.Default;
            MainPanel mainPanel = instance.mainPanel;
            SettingsPanel settingsPanel = instance.settingsPanel;

            // Main panel user settings.
            mainPanel.PlaySoundCheckBox.Checked = settings.PlayNotificationSound;
            mainPanel.ShowBattleCheckBox.Checked = settings.ShowBattleDialog;
            mainPanel.ShowMapCheckBox.Checked = settings.ShowMapDialog;
            mainPanel.CloseDialogTimeCheckBox.Checked = settings.CloseDialogTime;
            mainPanel.CloseDialogNumericUpDown.Value = settings.DialogLifeSeconds;
            mainPanel.NotificationDurationTrackBar.Value = settings.NotificationDuration;
            mainPanel.MapSizeDomainUpDown.SelectedIndex = settings.MapSize;

            string[] aux = settings.BattleTypes.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            for (int i = 0; i < aux.Length; i++)
            {
                if (!string.IsNullOrEmpty(aux[i]))
                    mainPanel.BattleTypesChListBox.Items.Add(aux[i].Substring(1), Convert.ToInt32(aux[i].Substring(0, 1)) == 1);
            }

            aux = settings.Designers.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            for (int i = 0; i < aux.Length; i++)
            {
                if (!string.IsNullOrEmpty(aux[i]))
                    mainPanel.DesignersChListBox.Items.Add(aux[i].Substring(1), Convert.ToInt32(aux[i].Substring(0, 1)) == 1);
            }

            aux = settings.BlackList.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            for (int i = 0; i < aux.Length; i++)
            {
                if (!string.IsNullOrEmpty(aux[i]))
                    mainPanel.BlackListChListBox.Items.Add(aux[i].Substring(1), Convert.ToInt32(aux[i].Substring(0, 1)) == 1);
            }

            aux = settings.AutocompleteKuskis.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            for (int i = 0; i < aux.Length; i++)
            {
                if (!string.IsNullOrEmpty(aux[i]))
                    mainPanel.AutocompleteKuskisList.Add(aux[i]);
            }

            // Settings panel user settings.
            settingsPanel.StartupCheckBox.Checked = settings.NotifyOnStartup;
            settingsPanel.HideToTraybarCheckBox.Checked = settings.HideToTraybar;
            settingsPanel.FadeCheckBox.Checked = settings.UseFadeEffect;
            settingsPanel.ShowOnTopCheckBox.Checked = settings.ShowOnTop;
            settingsPanel.TransparentCheckBox.Checked = settings.TransparentStyle;
            settingsPanel.HidePrintCheckBox.Checked = settings.HidePrintMap;

            settingsPanel.DefaultSoundComboBox.SelectedIndex = settings.DefaultSound;
            settingsPanel.UseCustomSoundCheckBox.Checked = settings.UseCustomSound;
            settingsPanel.CustomSoundPathTextBox.Text = settings.SoundPath;

            settingsPanel.ColorPicker.BackColor = settings.OnMapColor;
            settingsPanel.ColorPicker.FlatAppearance.MouseDownBackColor = settings.OnMapColor;
            settingsPanel.ColorPicker.FlatAppearance.MouseOverBackColor = settings.OnMapColor;
            settingsPanel.OnMapLevelCheckBox.Checked = settings.OnMapLevel;
            settingsPanel.OnMapDesignerCheckBox.Checked = settings.OnMapDesigner;
            settingsPanel.OnMapTypeCheckBox.Checked = settings.OnMapType;
            settingsPanel.OnMapTimeCheckBox.Checked = settings.OnMapTimer;
            settingsPanel.OnMapAttsCheckBox.Checked = settings.OnMapAttributes;
        }

        public static void SaveUserSettings()
        {
            Settings settings = Settings.Default;
            MainPanel mainPanel = instance.mainPanel;
            SettingsPanel settingsPanel = instance.settingsPanel;

            // Main panel user settings.
            settings.PlayNotificationSound = mainPanel.PlaySoundCheckBox.Checked;
            settings.ShowBattleDialog = mainPanel.ShowBattleCheckBox.Checked;
            settings.ShowMapDialog = mainPanel.ShowMapCheckBox.Checked;
            settings.CloseDialogTime = mainPanel.CloseDialogTimeCheckBox.Checked;
            settings.DialogLifeSeconds = mainPanel.CloseDialogNumericUpDown.Value;
            settings.NotificationDuration = mainPanel.NotificationDurationTrackBar.Value;
            settings.MapSize = mainPanel.MapSizeDomainUpDown.SelectedIndex;

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < mainPanel.BattleTypesChListBox.Items.Count; i++)
            {
                bool isChecked = mainPanel.BattleTypesChListBox.GetItemChecked(i);
                string value = ChListExtensions.GetText(mainPanel.BattleTypesChListBox, i);
                builder.AppendLine((isChecked ? "1" : "0") + value);
            }
            settings.BattleTypes = builder.ToString();

            builder = new StringBuilder();
            for (int i = 0; i < mainPanel.DesignersChListBox.Items.Count; i++)
            {
                bool isChecked = mainPanel.DesignersChListBox.GetItemChecked(i);
                string value = ChListExtensions.GetText(mainPanel.DesignersChListBox, i);
                builder.AppendLine((isChecked ? "1" : "0") + value);
            }
            settings.Designers = builder.ToString();

            builder = new StringBuilder();
            for (int i = 0; i < mainPanel.BlackListChListBox.Items.Count; i++)
            {
                bool isChecked = mainPanel.BlackListChListBox.GetItemChecked(i);
                string value = ChListExtensions.GetText(mainPanel.BlackListChListBox, i);
                builder.AppendLine((isChecked ? "1" : "0") + value);
            }
            settings.BlackList = builder.ToString();

            builder = new StringBuilder();
            for (int i = 0; i < mainPanel.AutocompleteKuskisList.Count; i++)
                builder.AppendLine(mainPanel.AutocompleteKuskisList[i]);
            settings.AutocompleteKuskis = builder.ToString();

            // Settings panel user settings.
            settings.NotifyOnStartup = settingsPanel.StartupCheckBox.Checked;
            settings.HideToTraybar = settingsPanel.HideToTraybarCheckBox.Checked;
            settings.UseFadeEffect = settingsPanel.FadeCheckBox.Checked;
            settings.ShowOnTop = settingsPanel.ShowOnTopCheckBox.Checked;
            settings.TransparentStyle = settingsPanel.TransparentCheckBox.Checked;
            settings.HidePrintMap = settingsPanel.HidePrintCheckBox.Checked;

            settings.DefaultSound = settingsPanel.DefaultSoundComboBox.SelectedIndex;
            settings.UseCustomSound = settingsPanel.UseCustomSoundCheckBox.Checked;
            settings.SoundPath = settingsPanel.CustomSoundPathTextBox.Text;

            settings.OnMapColor = settingsPanel.ColorPicker.BackColor;
            settings.OnMapLevel = settingsPanel.OnMapLevelCheckBox.Checked;
            settings.OnMapDesigner = settingsPanel.OnMapDesignerCheckBox.Checked;
            settings.OnMapType = settingsPanel.OnMapTypeCheckBox.Checked;
            settings.OnMapTimer = settingsPanel.OnMapTimeCheckBox.Checked;
            settings.OnMapAttributes = settingsPanel.OnMapAttsCheckBox.Checked;

            settings.Save();
        }
        #endregion
    }
}
