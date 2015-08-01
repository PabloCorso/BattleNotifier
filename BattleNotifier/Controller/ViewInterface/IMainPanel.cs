using System.Collections.Generic;

namespace BattleNotifier.Controller.ViewInterface
{
    public interface IMainPanel
    {
        void ReStartNotifying();
        bool TimerStoppedNotifications { get; }
        bool HasAllDesignersChecked();
        List<string> CheckedDesigners { get; }
        List<string> CheckedBlackList { get; }
        bool HasAllBattleTypesChecked();
        List<string> CheckedBattleTypes { get; }
    }
}
