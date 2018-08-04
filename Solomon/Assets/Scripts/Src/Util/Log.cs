using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Util {

    public static class Log {

        public static readonly string ERR_MISMATCH_COLUMNS_LENGTH = "mismatch columns length";
        public static readonly string ERR_MISMATCH_COLUMNS_DETAIL = "mismatch columns detail";
        
        static readonly string[] Levels = {
            "INFO",
            "ERR",
            "DB_DUMP"
        };

        public static void info (string txt) {
            StreamWriter sw = new StreamWriter ("Logs/Application.log", true);
            string _message = getTimeStamp(0) + txt;
            sw.WriteLine (_message);
            sw.Flush ();
            sw.Close ();
        }

        public static void err (string txt) {
            StreamWriter sw = new StreamWriter ("Logs/Application.log", true);
            string _message = getTimeStamp(1) + txt;
            sw.WriteLine (_message);
            sw.Flush ();
            sw.Close ();
        }

        public static void dbDump (List<Dictionary<string, string>> rows) {
            StreamWriter _sw = new StreamWriter ("Logs/Application.log", true);
            string _message = getTimeStamp(2);
            _sw.Write(_message);
            int i =0;
            _sw.WriteLine("(" + rows.Count + ") =>");
            _sw.WriteLine("{");
            foreach (Dictionary<string, string> row in rows)
            {
                _sw.WriteLine();
                _sw.WriteLine("  ["+ i +"] => {");
                foreach (KeyValuePair<string, string> kvp in row) {
                    _sw.WriteLine("    [" + kvp.Key + "] => " + kvp.Value);
                }
                _sw.WriteLine("  }");
                _sw.WriteLine();
                i++;
            }
            _sw.WriteLine("}");
            _sw.Flush ();
            _sw.Close ();
        }

        static string getTimeStamp(int level){
            string _message = "[";
            _message += System.DateTime.Now;
            _message += "][" + Levels[level] + "]";
            return _message;
        }
    }
}