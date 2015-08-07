using System;
using System.Windows.Forms;
using BattleNotifier.View;
using System.Threading;
using System.Linq;

namespace BattleNotifier
{
    static class Program
    {
        private static string appGuid = "588f985a-c0f5-4179-8118-5d79381f2c8a";

        public static bool LaunchedViaStartup { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            using (Mutex mutex = new Mutex(false, appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("An instance of Battle Notifier is already running.", "Calm your horses", MessageBoxButtons.OK);
                    return;
                }

                LaunchedViaStartup = args != null && args.Any(arg => arg.Equals("/startminimized", StringComparison.CurrentCultureIgnoreCase));

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                AppDomain.CurrentDomain.AssemblyResolve += (Object sender, ResolveEventArgs reargs) =>
                {
                    string thisExe = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                    System.Reflection.AssemblyName embeddedAssembly = new System.Reflection.AssemblyName(reargs.Name);
                    string resourceName = thisExe + "." + embeddedAssembly.Name + ".dll";

                    using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                    {
                        Byte[] assemblyData = new Byte[stream.Length];
                        stream.Read(assemblyData, 0, assemblyData.Length);
                        return System.Reflection.Assembly.Load(assemblyData);
                    }
                };

                Main main = new Main();
                Application.Run(main);
                main.DisposeBattleNotification();
            }
        }
    }
}
