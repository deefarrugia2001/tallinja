﻿#pragma warning disable

using Business;
using System;
using System.Threading;
using Presentation.Presentation.Print;

namespace Presentation
{
    class PL
    {
        int customerNumber;

        static BL businessLayer = new BL();
        static Login login = new Login();

        static void Main(string[] args)
        {
            bool runProgram = true;

            do
            {
                IO.Print(login.AddOptionsToMenu());
                IO.Print("Please select an option from the menu: ", false);

                byte selection;
            }
            while(runProgram);

            Console.ReadLine();
        }
    }
}