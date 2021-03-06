﻿using System;
using System.IO;
using System.Reflection;

namespace Utils
{
    public static class Logger
    {
        public static void Log(String lines)
        {
#if DEBUG
            var executingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            StreamWriter file = new System.IO.StreamWriter(executingDirectory + "\\bn-log.txt", true);
            file.WriteLine(lines);

            file.Close();
#endif
        }

        public static void Log(int code, Exception ex)
        {
#if DEBUG
            var executingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            StreamWriter file = new StreamWriter(executingDirectory + "\\bn-log.txt", true);
            file.WriteLine(code.ToString() + " - " + ex.ToString());

            file.Close();
#endif
        }
    }
}
