using System;
using System.Diagnostics;

namespace EventsDelegatesLambdasExtensions {
    public static class Helpers {
        public static void Print(object o) {
            Console.WriteLine(o);
            //Trace.WriteLine(o);
        }

        public static void ReadLine(string text = null) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine((string.IsNullOrEmpty(text) ? string.Empty : text + ", ") + "Press enter to continue...");
            //Trace.WriteLine((string.IsNullOrEmpty(text) ? string.Empty : text + ", ") + "Press enter to continue...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        public static void New(string text = null) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=======" + (string.IsNullOrEmpty(text) ? string.Empty : " " + text));
            //Trace.WriteLine("=======" + (string.IsNullOrEmpty(text) ? string.Empty : " " + text));
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
