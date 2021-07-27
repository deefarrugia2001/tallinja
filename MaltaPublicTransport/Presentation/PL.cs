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
        static bool isCommuterLoggedIn = true;
        static bool isInputFormatCorrect = false;

        static byte selection;
        static int customerNumber;
        
        static BL businessLayer = new BL();

        static void Main(string[] args)
        {
            Login login = new Login();

            do
            {
                selection = 0;

                Console.Clear();

                IO.Print(login.DisplayMenu());
                IO.Print("Please select an option from the menu: ", false);
                isInputFormatCorrect = byte.TryParse(Console.ReadLine(), out selection);

                if (isInputFormatCorrect)
                    ProceedLoginMenu(selection);
                else
                    Warn("Input not in correct format, please try again!");
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
                    AddCustomer();
                    break;
                case 3:
                    Exit();
                    break;
                default:
                    Warn("You have not selected an option within the specified range.");
                    break;
            }
        }

        static void ProceedCommuterMenu(byte selection) 
        {
            switch (selection)
            {
                case 1:
                    CheckBalance();
                    break;
                case 2:
                    ViewChecksOnParticularDay();
                    break;
                case 3:
                    Deactivate();
                    break;
                case 4:
                    Logout();
                    break;
                default:
                    Warn("You have not selected an option within the specified range.");
                    break;
            }
        }

        static void Deactivate()
        {
            throw new NotImplementedException();
        }

        static void ViewChecksOnParticularDay()
        {
            throw new NotImplementedException();
        }

        //TODO: Try to solve businessLayer.AddBalance as exceptions are being thrown.
        static void CheckBalance()
        {
            decimal balance = businessLayer.FetchBalance(customerNumber);
            IO.Print(IO.Type.SUCCESS, $"Dear commuter, you have EUR {balance} left.");
            businessLayer.AddBalance(customerNumber, balance);
            Wait(2000);
            PromptForKeyPress();
        }

        static void Login() 
        {
            Console.Clear();
            IO.Print("Customer Number: ", false);
            isInputFormatCorrect = int.TryParse(Console.ReadLine(), out customerNumber);

            if(isInputFormatCorrect) 
            {
                if (businessLayer.ValidateCustomerNumber(customerNumber))
                {
                    IO.Print(IO.Type.SUCCESS, "The customer number entered matches the records in our database.");
                    Commuter commuter = new Commuter();

                    do
                    {
                        Console.Clear();

                        IO.Print(commuter.DisplayMenu());
                        IO.Print("Please select an option from the menu: ", false);
                        isInputFormatCorrect = byte.TryParse(Console.ReadLine(), out selection);

                        if(isInputFormatCorrect) 
                            ProceedCommuterMenu(selection);
                        else 
                            Warn("You have not selected an option within the specified range.");
                    }
                    while (isCommuterLoggedIn);
                }
                else
                    IO.Print(IO.Type.ERROR, "Sorry, the customer number entered does not match the records in our database.");
            }
            else
                Warn("Input not in correct format, please try again!");
        }

        static void AddCustomer() 
        {
            Console.Clear();
            IO.Print("Customer Number: ", false);
            isInputFormatCorrect = int.TryParse(Console.ReadLine(), out customerNumber);

            if (isInputFormatCorrect)
            {
                if (businessLayer.VerifyCNUniqueness(customerNumber))
                {
                    bool isInsertionSuccessful = businessLayer.AddCustomer(customerNumber);
                    if (isInsertionSuccessful)
                        IO.Print(IO.Type.SUCCESS, "Commuter has been added successfully!");
                    else
                        IO.Print(IO.Type.ERROR, "Unable to add commuter!");
                }
                else
                    IO.Print(IO.Type.ERROR, "Customer number is not unique.");
            }
            else
                Warn("Input not in correct format, please try again!");
        }

        static void Exit()
        {
            Console.Clear();
            IO.Print("Exiting from application...");
            Wait(1000);
            isProgramRunning = false;
        }

        static void Logout()
        {
            Console.Clear();
            IO.Print("Logging you out...");
            Wait(1000);
            isCommuterLoggedIn = false;
        }

        static void Warn(string message)
        {
            IO.Print(IO.Type.ERROR, $"\n{message}");
            PromptForKeyPress();
            Console.Clear();
        }

        static void PromptForKeyPress()
        {
            IO.Print("Please press a key to continue...", false);
            Console.ReadKey();
        }

        static void Wait(int delay) 
        {
            Thread.Sleep(delay);
        }
    }
}