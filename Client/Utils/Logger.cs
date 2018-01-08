using System;

namespace Client.Utils
{
    internal class Logger
    {
        private static void Log(ConsoleColor color, string message)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }

        public static void LogInfo(string message)
        {
            Log(ConsoleColor.White, message);
        }

        public static void LogError(string message)
        {
            Log(ConsoleColor.Red, message);
        }

        public static void LogSuccess(string message)
        {
            Log(ConsoleColor.Green, message);
        }
        public static void LogNewInfo(string message)
        {
            Log(ConsoleColor.Cyan, message);
        }
    }
}