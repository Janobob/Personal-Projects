using System;

namespace CLCompiler.IO
{
    public class ConsoleManager
    {
        public static void Log(string content)
        {
            Console.WriteLine(content);
        }

        public static void Debug(string content)
        {
            System.Diagnostics.Debug.WriteLine(content);
        }

        public static void Info(string content)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Info: {content}");
            Console.ResetColor();
        }

        public static void Warning(string content)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Warning: {content}");
            Console.ResetColor();
        }

        public static void Error(string content)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {content}");
            Console.ResetColor();
        }
    }
}