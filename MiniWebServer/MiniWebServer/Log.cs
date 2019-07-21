using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MiniWebServer
{
    internal static class Log
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [Flags]
        public enum LogLevel
        {
            Debugging,
            Errors,
            Warnings,
            Info
        }

#if DEBUG
        public static LogLevel level = LogLevel.Debugging | LogLevel.Errors | LogLevel.Warnings | LogLevel.Info;
#else
		public static LogLevel level = LogLevel.Errors | LogLevel.Warnings | LogLevel.Info;
#endif

        private static string logName
        {
            get
            {
                return typeof(Log).Namespace;
            }
        }

        private static bool ValidConsole
        {
            get
            {
                return (GetConsoleWindow() != IntPtr.Zero);
            }
        }

        public static void Info(string info)
        {
            if (level.HasFlag(LogLevel.Info))
                LogOutput($"{TimeStamp()} [Info] [{logName}] {info}", ConsoleColor.Green);
        }

        public static void Error(string error)
        {
            if (level.HasFlag(LogLevel.Errors))
                LogOutput($"{TimeStamp()} [Error] [{logName}] {error}", ConsoleColor.Red);
        }

        public static void Warning(string warning)
        {
            if (level.HasFlag(LogLevel.Warnings))
                LogOutput($"{TimeStamp()} [Warning] [{logName}] {warning}", ConsoleColor.Yellow);
        }

        public static void Debug(string debug)
        {
            if (level.HasFlag(LogLevel.Debugging))
                LogOutput($"{TimeStamp()} [Debug] [{logName}] {debug}", ConsoleColor.Magenta);
        }

        public static void LogOutput(string output, ConsoleColor colour)
        {

            if (ValidConsole)
                Console.CursorLeft = 0;

            Console.WriteLine();

            if (ValidConsole)
                Console.CursorTop -= 1;

            if (ValidConsole)
                Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(output);

            if (ValidConsole)
                Console.ForegroundColor = ConsoleColor.Gray;

            WriteToFile(output);
        }

        private static string TimeStamp()
        {
            DateTime now = DateTime.Now;
            return $"[{now.ToShortDateString()} {now.ToLongTimeString()}]";
        }

        private static void WriteToFile(string data)
        {
            try
            {
                File.AppendAllText($"{Environment.CurrentDirectory}{Path.DirectorySeparatorChar}{logName}.log", data + Environment.NewLine);
            }
            catch (IOException)
            {
                if (ValidConsole)
                    Console.CursorLeft = 0;

                Console.WriteLine();

                if (ValidConsole)
                    Console.CursorTop -= 1;

                if (ValidConsole)
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("[Error] [System Log] Cannot access log file!");

                if (ValidConsole)
                    Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}