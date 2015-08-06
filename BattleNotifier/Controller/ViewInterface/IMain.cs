using BattleNotifier.View;
using System.Windows.Forms;
namespace BattleNotifier.Controller.ViewInterface
{
    public interface IMain
    {
        IMainPanel MainPanel { get; }
        void ShowNotification(BaseNotification n);
        void ShowHelpDescription(string desc, int type = 1);
        void ClearHelpDescription();
        void RegisterCurrentBattleHotkey(Keys hotkey, Keys modifiers);
        void UnregisterCurrentBattleHotkey();
    }
}
