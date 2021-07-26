#pragma warning disable

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
        static bool isInputFormatCorrect = false;

        static BL businessLayer = new BL();
        static Login login = new Login();

        static void Main(string[] args)
        {
            do
            {
                byte selection;

                IO.Print(login.AddOptionsToMenu());
                IO.Print("Please select an option from the menu: ", false);
                isInputFormatCorrect = byte.TryParse(Console.ReadLine(), out selection);

                if(isInputFormatCorrect) 
                    ProceedLoginMenu(selection);
            }
            while(isProgramRunning);
        }

        static void ProceedLoginMenu(byte selection) 
        {
            switch(selection) 
            {
                case 1:
                    Login();
                    break;
                case 2:
                    Exit();
                    break;
                default:
                    WarnOutOfRange();
                    break;
            }
        }

        static void Login() 
        {
            Console.Clear();
            IO.Print("Customer Number: ", false);
            isInputFormatCorrect = int.TryParse(Console.ReadLine(), out customerNumber);

            if(isInputFormatCorrect) 
            {
                if (businessLayer.ValidateCustomerNumber(customerNumber))
                    IO.Print(IO.Type.SUCCESS, "The customer number entered matches the records in our database.");
                else
                    IO.Print(IO.Type.ERROR, "Sorry, the customer number entered does not match the records in our database.");
            }
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
            Thread.Sleep(1000);
            isProgramRunning = false;
        }
    }
}