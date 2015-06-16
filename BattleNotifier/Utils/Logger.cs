using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class Logger
    {
        public static void Log(String lines)
        {
            var executingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            System.IO.StreamWriter file = new System.IO.StreamWriter(executingDirectory + "\bn-log.txt", true);
            file.WriteLine(lines);

            file.Close();
        }

        public static void Log(int code, Exception ex)
        {
            var executingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            System.IO.StreamWriter file = new System.IO.StreamWriter(executingDirectory + "\\bn-log.txt", true);
            file.WriteLine(code.ToString() + " - " + ex.ToString());

            file.Close();
        }
    }
}
