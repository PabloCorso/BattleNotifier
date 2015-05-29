using System;
using System.Windows.Forms;
using BattleNotifier.View;

namespace BattleNotifier
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Main main = new Main();
            Application.Run(main);
            main.DisposeBattleNotification();
        }
    }
}
