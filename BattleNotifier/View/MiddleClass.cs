using System;
using BattleNotifier.Model;

namespace BattleNotifier.View
{
    /// <summary>
    /// This class implements the abstract BaseNotification to be later inherited 
    /// by concrete notification forms, this is the only way to make visual studio 
    /// designer work with concrete forms that must inherit from the abstract class.
    /// </summary>
    public class MiddleClass : BaseNotification
    {
        public MiddleClass() { }

        public MiddleClass(BattleNotificationSettings settings, int battleDuration)
            : base(settings, battleDuration) { }

        protected override void CloseFormParticulars()
        {
            throw new NotImplementedException();
        }

        protected override string GetCountdownBattleEndedText()
        {
            throw new NotImplementedException();
        }

        protected override void SetCountdownText(string countdownText)
        {
            throw new NotImplementedException();
        }
    }
}
