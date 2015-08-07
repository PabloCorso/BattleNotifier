using System.Collections.Generic;

namespace BattleNotifier.Controller.ViewInterface
{
    public interface IMainPanel
    {
        void ReStartNotifying();
        bool TimerStoppedNotifications { get; }
        bool HasAllDesignersChecked();
        bool HasAllBattleTypesChecked();
        List<string> CheckedDesigners { get; }
        List<string> CheckedBlackList { get; }
        List<string> CheckedBattleTypes { get; }
    }
}
