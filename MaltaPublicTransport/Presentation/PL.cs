#pragma warning disable

using Business;
using System;
using System.Threading;

namespace Presentation
{
    class PL
    {
        enum Type 
        {
            ERROR, SUCCESS
        }

        int customerNumber;

        static BL businessLayer = new BL();
        static Login login = new Login();

        static ConsoleColor ChangeForegound(Type type) 
        {
            //Set the initial value to the current foreground colour.
            ConsoleColor foregroundColour = Console.ForegroundColor;

            switch(type) 
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

        static void Print(Type type, string message) 
        {
            Console.ForegroundColor = ChangeForegound(type);
            Console.WriteLine(message);
            Thread.Sleep(2000);
            Console.ResetColor();
        }

        static void Print(string message)
        {
            Console.WriteLine(message);
        }

        static void Print(string message, bool skipLine) 
        {
            if (skipLine)
                Console.Write($"{message}\n");
            else
                Console.Write(message);
        }

        static void Main(string[] args)
        {
            Console.ReadLine();
        }
    }
}