using System;
using System.Windows.Forms;
using System.Reflection;
using BattleNotifier.View;
using System.Threading;
using System.Diagnostics;

namespace BattleNotifier
{
    static class Program
    {
        private static string appGuid = "588f985a-c0f5-4179-8118-5d79381f2c8a";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (Mutex mutex = new Mutex(false, appGuid))
            {
                if (!mutex.WaitOne(0, false))
                    return;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                AppDomain.CurrentDomain.AssemblyResolve += (Object sender, ResolveEventArgs args) =>
                {
                    String thisExe = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                    System.Reflection.AssemblyName embeddedAssembly = new System.Reflection.AssemblyName(args.Name);
                    String resourceName = thisExe + "." + embeddedAssembly.Name + ".dll";

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
