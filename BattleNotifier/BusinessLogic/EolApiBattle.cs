using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleNotifier.BusinessLogic
{
    public class EolApiBattle
    {
        //{"index":"117806","kuski":"yanizzz","type":"Normal","started":1489131386,"finished":"0","inqueue":"0",
        //"duration":"18","aborted":"0","level":"372505","levelname":"YbaQ013"}

        public int Index { get; set; }

        public string Kuski { get; set; }

        public string Type { get; set; }

        public double Started { get; set; }

        public int Finished { get; set; }
        public bool IsFinished { get { return Convert.ToBoolean(Finished); } }

        public int InQueue { get; set; }
        public bool IsInQueue { get { return Convert.ToBoolean(InQueue); } }

        public int Duration { get; set; }

        public int Aborted { get; set; }
        public bool IsAborted { get { return Convert.ToBoolean(Aborted); } }

        public int Level { get; set; }

        public string LevelName { get; set; }
    }
}
