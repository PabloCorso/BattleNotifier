using System;
using System.ComponentModel;

namespace BattleNotifier.Model
{
    public class Battle
    {
        private const string battleUrl = "http://elmaonline.net/battles/";
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Name { get { return FileName.Substring(0, FileName.Length - 4); } }
        public string Title { get; set; }
        public string Desginer { get; set; }
        public DateTime StartedDateTime { get; set; }
        public BattleType Type { get; set; }
        public BattleAttribute Attributes { get; set; }
        public int Duration { get; set; }
        public string Url { get { return battleUrl + Id; } }
        public string MapUrl { get; set; }
        public string LevelUrl { get; set; }

        public string MapId
        {
            get
            {
                char[] delimiterChars = { '\\' };
                string[] parse = this.MapUrl.Split(delimiterChars);
                int lastIndex = parse.Length - 1;
                return parse[lastIndex];
            }
        }

        public bool IsSpecialBattle
        {
            get
            {
                if (this.Type.HasFlag(BattleType.FirstFinish) ||
                    this.Type.HasFlag(BattleType.FlagTag) ||
                    this.Type.HasFlag(BattleType.OneLife) ||
                    this.Type.HasFlag(BattleType.FinishCount))
                    return true;
                else
                    return false;
            }
        }

        public override bool Equals(object obj)
        {
            if ((object)obj == null || GetType() != obj.GetType())
                return false;
            Battle battle = (Battle)obj;

            return Name.Equals(battle.Name);
        }

        public double TimeLeft
        {
            get
            {
                double timePassed = (DateTime.Now - this.StartedDateTime).TotalSeconds;
                return (this.Duration * 60) - timePassed;
            }
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + StartedDateTime.GetHashCode();
        }

        public override string ToString()
        {
            return FileName + "(" + StartedDateTime + ")";
        }
    }

    [Flags]
    public enum BattleAttribute
    {
        [Description("See others")]
        SeeOthers = 1 << 0,
        [Description("See times")]
        SeeTimes = 1 << 1,
        [Description("Allow starter")]
        AllowStarter = 1 << 2,
        [Description("Apple bugs")]
        AppleBugs = 1 << 3,
        [Description("No volt")]
        NoVolt = 1 << 4,
        [Description("No turn")]
        NoTurn = 1 << 5,
        [Description("One turn")]
        OneTurn = 1 << 6,
        [Description("No brake")]
        NoBrake = 1 << 7,
        [Description("No throttle")]
        NoThrottle = 1 << 8,
        [Description("Always throttle")]
        AlwaysThrottle = 1 << 9,
        [Description("Drunk")]
        Drunk = 1 << 10
    }
    public enum BattleType
    {
        [Description("Normal")]
        Normal = 0,
        [Description("One-life")]
        OneLife = 1,
        [Description("First finish")]
        FirstFinish = 2,
        [Description("Slowness")]
        Slowness = 3,
        [Description("Survivor")]
        Survivor = 4,
        [Description("Last counts")]
        LastCounts = 5,
        [Description("Finish-count")]
        FinishCount = 6,
        [Description("1 hour tt")]
        OneHourTT = 7,
        [Description("Flag tag")]
        FlagTag = 8,
        [Description("Apple")]
        Apple = 9,
        [Description("Speed")]
        Speed = 10
    }
}
