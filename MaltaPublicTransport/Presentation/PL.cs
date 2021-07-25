#pragma warning disable

using Business;
using System;
using System.Threading;

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
                login.AddOptionsToMenu();

                byte selection;
            }
            while(runProgram);

            Console.ReadLine();
        }
    }
}