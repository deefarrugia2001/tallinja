using Data;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Presentation
{
    class PL
    {
        enum Type 
        {
            ERROR, SUCCESS
        }

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

        static void Main(string[] args)
        {
            //Console.WriteLine(login.AddOptionsToMenu());
            //Console.Write("Please enter a choice from the menu: ");

            string message = businessLayer.FetchBalance(26636573);
            Console.WriteLine(message);
            Console.ReadLine();
        }
    }
}