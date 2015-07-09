using BattleNotifier.Model;
using BattleNotifier.View;
using System.Windows.Forms;
namespace BattleNotifier.Controller.ViewInterface
{
    public interface IMain
    {
        IMainPanel MainPanel { get; }
        void ShowBattleNotification(BattleNotification noty);
        void ShowMapNotification(MapNotification noty);
        void ShowHelpDescription(string desc, int type = 1);
        void ClearHelpDescription();
        void RegisterCurrentBattleHotkey(Keys hotkey, Keys modifiers);
        void UnregisterCurrentBattleHotkey();
    }
}
