﻿#pragma warning disable

using Business;
using System;
using System.Threading;
using Presentation.Presentation.Print;

namespace Presentation
{
    class PL
    {
        static bool isProgramRunning = true;
        static int customerNumber;

        static BL businessLayer = new BL();
        static Login login = new Login();

        static void Main(string[] args)
        {
            do
            {
                byte selection;

                IO.Print(login.AddOptionsToMenu());
                IO.Print("Please select an option from the menu: ", false);
                bool isByte = byte.TryParse(Console.ReadLine(), out selection);

                if(isByte) 
                {
                    switch(selection) 
                    {
                        case 1:
                            break;
                        case 2:
                            Exit();
                            break;
                        default:
                            WarnOutOfRange();
                            break;
                    }
                }
            }
            while(isProgramRunning);
        }

        static void WarnOutOfRange() 
        {
            IO.Print(IO.Type.ERROR, "You have not selected an option within the specified range.");
            IO.Print("Please press a key to continue...", false);
            Console.ReadKey();
            Console.Clear();
        }

        static void Exit()
        {
            Console.Clear();
            IO.Print("Exiting from application...");
            Thread.Sleep(2000);
            isProgramRunning = false;
        }
    }
}