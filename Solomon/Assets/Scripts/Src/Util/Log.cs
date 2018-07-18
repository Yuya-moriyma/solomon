using System;
using System.IO;

namespace Util {

    public static class Log {

        static readonly string[] Levels = {
            "INFO",
            "WARN",
            "DUMP"
        };

        public static void info (string txt) {
            StreamWriter sw = new StreamWriter ("Logs/Application.log", true);
            string _message = "[";
            _message += System.DateTime.Now;
            _message += "][" + Levels[0] +"]" + txt;
            sw.WriteLine (_message);
            sw.Flush ();
            sw.Close ();
        }
    }
}