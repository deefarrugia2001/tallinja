#pragma warning disable

using System;
using System.Threading;

namespace Presentation.Presentation.Print
{
    static class IO
    {
        public enum Type
        {
            ERROR, SUCCESS
        }

        public static ConsoleColor ChangeForegound(Type type)
        {
            //Set the initial value to the current foreground colour.
            ConsoleColor foregroundColour = Console.ForegroundColor;

            switch (type)
            {
                case Type.ERROR:
                    foregroundColour = ConsoleColor.Red;
                    break;
                case Type.SUCCESS:
                    foregroundColour = ConsoleColor.Green;
                    break;
            }

            return foregroundColour;
        }

        public static void Print(Type type, string message)
        {
            Console.ForegroundColor = ChangeForegound(type);
            Console.WriteLine(message);
            Thread.Sleep(2000);
            Console.ResetColor();
        }

        public static void Print(string message)
        {
            Console.WriteLine(message);
        }

        public static void Print(string message, bool skipLine)
        {
            if (skipLine)
                Console.Write($"{message}\n");
            else
                Console.Write(message);
        }
    }
}
