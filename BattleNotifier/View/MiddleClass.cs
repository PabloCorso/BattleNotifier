using BattleNotifier.Model;

namespace BattleNotifier.View
{
    public class MiddleClass : BaseNotification
    {
        public MiddleClass() { }

        public MiddleClass(BattleNotificationSettings settings) : base(settings) { }

        protected override void CloseFormParticulars() { }
    }
}
