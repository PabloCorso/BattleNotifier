using System.Drawing;

namespace BattleNotifier.Model
{
    public class BattleNotificationSettings
    {
        public BasicSettings Basic { get; set; }
        public GeneralSettings General { get; set; }
        public MapSettings Map { get; set; }

        public BattleNotificationSettings()
        {
            Basic = new BasicSettings();
            General = new GeneralSettings();
            Map = new MapSettings();
        }
    }

    public class BasicSettings
    {
        public bool PlaySound { get; set; }
        public bool ShowBattleDialog { get; set; }
        public bool ShowMapDialog { get; set; }
        public string SoundPath { get; set; }
        public int LifeSeconds { get; set; }
        public int MapSize { get; set; }
        public int DefaultSound { get; set; }
        public bool UseCustomSound { get; set; }
        public int DisplayScreen { get; set; }
    }

    public class GeneralSettings
    {
        public bool NotifyOnStartup { get; set; }
        public bool HideToTraybar { get; set; }
        public bool UseFadeEffect { get; set; }
        public bool ShowOnTop { get; set; }
        public bool TransparentStyle { get; set; }
        public bool HidePrintMap { get; set; }
    }

    public class MapSettings
    {
        public Color TextMapColor { get; set; }
        public bool ShowLevelName { get; set; }
        public bool ShowDesigner { get; set; }
        public bool ShowType { get; set; }
        public bool ShowLifeSeconds { get; set; }
        public bool ShowAttributes { get; set; }
    }
}
