using BattleNotifier.Model;
using BattleNotifier.Utils;
using BattleNotifier.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;
using Settings = BattleNotifier.Properties.Settings;

namespace BattleNotifier
{
    // Fix this shit, make forms return the settings.
    public class UserSettings
    {
        Main mainView;
        MainPanel mainPanel;
        SettingsPanel settingsPanel;
        private static UserSettings instance;

        public static void InitializeConfigStorageBroker(Main mainView, MainPanel mainPanel, SettingsPanel settingsPanel)
        {
            if (instance == null)
                instance = new UserSettings(mainView, mainPanel, settingsPanel);
        }

        public static UserSettings Instance
        {
            get
            {
                return instance;
            }
        }

        private UserSettings(Main mainView, MainPanel mainPanel, SettingsPanel settingsPanel)
        {
            this.mainView = mainView;
            this.mainPanel = mainPanel;
            this.settingsPanel = settingsPanel;
        }

        public BattleNotificationSettings GetBattleNotificationSettings()
        {
            try
            {
                MainPanel mp = instance.mainPanel;
                SettingsPanel sp = instance.settingsPanel;

                BattleNotificationSettings settings = new BattleNotificationSettings();

                //Main panel settings.
                settings.Basic.ShowBattleDialog = mp.ShowBattleCheckBox.Checked;
                settings.Basic.ShowMapDialog = mp.ShowMapCheckBox.Checked;
                if (mp.CloseDialogTimeCheckBox.Checked)
                    settings.Basic.LifeSeconds = Convert.ToInt32(mp.CloseDialogNumericUpDown.Value);
                else
                    settings.Basic.LifeSeconds = 0;
                settings.Basic.PlaySound = mp.PlaySoundCheckBox.Checked;
                settings.Basic.MapSize = mp.MapSizeDomainUpDown.SelectedIndex;
                settings.Basic.DisplayScreen = Convert.ToInt32(mp.DisplayScreenButton.Text);

                //Settings panel settings.

                settings.Basic.DefaultSound = sp.GetSelecetedDefaultSound();
                settings.Basic.SoundPath = sp.CustomSoundPathTextBox.Text;
                settings.Basic.UseCustomSound = sp.UseCustomSoundCheckBox.Checked;

                settings.General.ShowOnTop = sp.ShowOnTopCheckBox.Checked;
                settings.General.UseFadeEffect = sp.FadeCheckBox.Checked;
                settings.General.HidePrintMap = sp.HidePrintCheckBox.Checked;
                settings.General.TransparentStyle = sp.TransparentCheckBox.Checked;

                settings.Map.TextMapColor = sp.ColorPicker.BackColor;
                settings.Map.ShowLevelName = sp.OnMapLevelCheckBox.Checked;
                settings.Map.ShowDesigner = sp.OnMapDesignerCheckBox.Checked;
                settings.Map.ShowType = sp.OnMapTypeCheckBox.Checked;
                settings.Map.ShowLifeSeconds = sp.OnMapTimeCheckBox.Checked;
                settings.Map.ShowAttributes = sp.OnMapAttsCheckBox.Checked;

                return settings;
            }
            catch (Exception ex)
            {
                Logger.Log(400, ex);
                throw;
            }
        }

        public bool MustNotifyOnStartup()
        {
            Settings settings = Settings.Default;
            return settings.NotifyOnStartup;
        }

        public bool MustHideToTraybar()
        {
            Settings settings = Settings.Default;
            return settings.HideToTraybar;
        }

        public void SetHideToTraybarValue(bool value)
        {
            Settings settings = Settings.Default;
            settings.HideToTraybar = value;
        }

        #region User settings persistance
        public static void Reset()
        {
            Settings.Default.Reset();
            instance.mainPanel.BlackListChListBox.Items.Clear();
            instance.mainPanel.DesignersChListBox.Items.Clear();
            instance.mainPanel.BattleTypesChListBox.Items.Clear();
            instance.mainPanel.AutocompleteKuskisList.Clear();
            Load();
            instance.mainPanel.MainPanel_Load(null, null);
        }

        public static void Load()
        {
            Settings settings = Settings.Default;
            MainPanel mainPanel = instance.mainPanel;
            SettingsPanel settingsPanel = instance.settingsPanel;

            if (settings.NeedsUpdate)
            {
                try
                {
                    if (!settings.HasUpgrade)
                    {
                        settings.Upgrade();
                        settings.HasUpgrade = true;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log(401, ex);
                }
            }

            // Main panel user settings.
            mainPanel.PlaySoundCheckBox.Checked = settings.PlayNotificationSound;
            mainPanel.ShowBattleCheckBox.Checked = settings.ShowBattleDialog;
            mainPanel.ShowMapCheckBox.Checked = settings.ShowMapDialog;
            mainPanel.CloseDialogTimeCheckBox.Checked = settings.CloseDialogTime;
            mainPanel.CloseDialogNumericUpDown.Value = settings.DialogLifeSeconds;
            mainPanel.NotificationDurationTrackBar.Value = settings.NotificationDuration;
            mainPanel.MapSizeDomainUpDown.SelectedIndex = settings.MapSize;
            mainPanel.ShowCurrentHotkeyTextBox.Hotkey = (Keys)settings.CurrentBattleHotkey;
            mainPanel.ShowCurrentHotkeyTextBox.HotkeyModifiers = (Keys)settings.CurrentBattleModifiers;

            if (settings.DisplayScreen == 0)
                settings.DisplayScreen = Screen.AllScreens.ToList().IndexOf(Screen.PrimaryScreen) + 1;
            mainPanel.DisplayScreenButton.Text = settings.DisplayScreen.ToString();

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
            settingsPanel.RunOnWinStartupCheckBox.Checked = settings.RunOnWinStartup;
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

        public static void Save()
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
            settings.DisplayScreen = Convert.ToInt32(mainPanel.DisplayScreenButton.Text);
            settings.CurrentBattleHotkey = (int)mainPanel.ShowCurrentHotkeyTextBox.Hotkey;
            settings.CurrentBattleModifiers = (int)mainPanel.ShowCurrentHotkeyTextBox.HotkeyModifiers;

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
            settings.RunOnWinStartup = settingsPanel.RunOnWinStartupCheckBox.Checked;
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
