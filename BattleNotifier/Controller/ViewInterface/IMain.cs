﻿using BattleNotifier.Model;
using BattleNotifier.View;
namespace BattleNotifier.Controller.ViewInterface
{
    public interface IMain
    {
        IMainPanel MainPanel { get; }
        void ShowBattleNotification(BattleNotification noty);
        void ShowMapNotification(MapNotification noty);
        void ShowHelpDescription(string desc, int type = 1);
        void ClearHelpDescription();
    }
}
