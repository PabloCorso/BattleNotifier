using BattleNotifier.Model;
using System.Collections.Generic;

namespace BattleNotifier.Controller.ViewInterface
{
    public interface IMainPanel
    {
        bool TimerEnabled { get; }
        bool HasAllDesignersChecked();
        List<string> CheckedDesigners { get; }
        List<string> CheckedBlackList { get; }
        bool HasAllBattleTypesChecked();
        List<string> CheckedBattleTypes { get; }
        BattleNotificationSettings BattleNotificationSettings { get; }
    }
}
