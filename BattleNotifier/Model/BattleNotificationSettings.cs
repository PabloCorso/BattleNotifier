using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleNotifier.Model
{
    public class BattleNotificationSettings
    {
        public bool PlaySound { get; set; }
        public bool ShowBattleDialog { get; set; }
        public bool ShowMapDialog { get; set; }
        public string SoundPath { get; set; }
        public int LifeSeconds { get; set; }
        public int MapSize { get; set; }
    }
}
