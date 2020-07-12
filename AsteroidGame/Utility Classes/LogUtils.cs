using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AsteroidGame.UtilityClasses
{
    static class LogUtils
    {
        static string logFilePath;
        static string scoreFilePath;
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
            scoreFilePath = "Info/Score.txt";
            if (!File.Exists(scoreFilePath))
            {
                using (StreamWriter sw = File.CreateText(scoreFilePath))
                {
                    sw.Write("");
                }
            }
        }
        public static void WriteLogToConsole(object sender, string actionName, string info)
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
        public static void WriteLogToFile(object sender, string actionName, string info)
        {
            using (StreamWriter sw = File.AppendText(logFilePath))
            {
                sw.Write(DateTime.Now.ToString() + "\t");
                sw.Write(sender?.ToString() + "\t");
                sw.Write(actionName + "\t");
                sw.Write(info + "\n");
            }
        }
        public static void WriteScoreToFile(int Score)
        {
            bool needRewrite = false;
            Dictionary<string, int> ScoreTable = ReadScoreFromFile();

            if (ScoreTable.Count < 5)
            {
                string PlayerName = AskPlayerName();
                if (ScoreTable.ContainsKey(PlayerName) && Score > ScoreTable[PlayerName])
                {
                    ScoreTable[PlayerName] = Score;
                    needRewrite = true;
                }
                else if (!ScoreTable.ContainsKey(PlayerName))
                {
                    ScoreTable.Add(PlayerName, Score);
                    needRewrite = true;
                }
            }
            else if (ScoreTable.Values.Min() < Score)
            {
                string PlayerName = AskPlayerName();
                if (ScoreTable.ContainsKey(PlayerName))
                {
                    ScoreTable[PlayerName] = Score;
                    needRewrite = true;
                }
                else 
                {
                    string key = ScoreTable.Aggregate((x, y) => x.Value < y.Value ? x : y).Key;
                    ScoreTable.Remove(key);
                    ScoreTable.Add(PlayerName, Score);
                    needRewrite = true;
                }
            }
            if (needRewrite) using (StreamWriter sw = File.CreateText(scoreFilePath))
            {
                foreach(KeyValuePair<string, int> score in ScoreTable)
                {
                    sw.Write(score.Value.ToString() + "\t");
                    sw.Write(score.Key + "\n");
                }
            }
        }
        public static Dictionary<string,int> ReadScoreFromFile()
        {
            Dictionary<string, int> ScoreTable = new Dictionary<string, int>();
            using (StreamReader sr = new StreamReader(scoreFilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split('\t');
                    ScoreTable.Add(parts[1], int.Parse(parts[0]));
                }
            }
            return ScoreTable;
        }
        private static string AskPlayerName()
        {
            string result = "";
            DialogForm dialogForm = new DialogForm();
            DialogResult res = dialogForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                result = dialogForm.Text;
            }
            dialogForm.Dispose();
            if (!String.IsNullOrEmpty(result)) result = "unknown player";
            return result;
        }
    }
}
