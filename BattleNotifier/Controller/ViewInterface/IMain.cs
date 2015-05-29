using BattleNotifier.Model;
namespace BattleNotifier.Controller.ViewInterface
{
    public interface IMain
    {
        IMainPanel MainPanel { get; }
        void ShowBattleNotificationDialog(Battle battle, int timeLeft);
    }
}
