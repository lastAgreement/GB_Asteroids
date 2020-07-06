using System;
using System.IO;

namespace AsteroidGame.UtilityClasses
{
    static class LogUtils
    {
        static string logFilePath;
        static LogUtils()
        {
            logFilePath = "Log/l_" + DateTime.Now.ToString("d") + ".txt";
            if (!File.Exists(logFilePath))
            {
                using (StreamWriter sw = File.CreateText(logFilePath))
                {
                    sw.WriteLine("=====log " + DateTime.Now.ToString() + "=====");
                }
            }
            else using (StreamWriter sw = File.AppendText(logFilePath))
                {
                    sw.WriteLine("\n=====log " + DateTime.Now.ToString() + "=====");
                }
        }
        public static void WriteToConsole(object sender, string actionName, string info)
        {
            ConsoleColor previous = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(DateTime.Now.ToString() + "\t");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(sender?.ToString() + "\t");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(actionName + "\t");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(info + "\n");

            Console.ForegroundColor = previous;
        }
        public static void WriteToFile(object sender, string actionName, string info)
        {
            using (StreamWriter sw = File.AppendText(logFilePath))
            {
                sw.Write(DateTime.Now.ToString() + "\t");
                sw.Write(sender?.ToString() + "\t");
                sw.Write(actionName + "\t");
                sw.Write(info + "\n");
            }
        }
    }
}
