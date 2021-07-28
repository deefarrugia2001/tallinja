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
                    ViewAllChecks();
                    break;
                case 4:
                    ViewAccountInformation();
                    break;
                case 5:
                    Deactivate();
                    break;
                case 6:
                    Logout();
                    break;
                default:
                    Warn("You have not selected an option within the specified range.");
                    break;
            }
        }

        private static void ViewAccountInformation()
        {
            Console.Clear();
            string commuterInformation = businessLayer.GetCommuterInformation(customerNumber);
            IO.Print(commuterInformation);
            PromptForKeyPress();
        }

        static void ViewAllChecks()
        {
            Console.Clear();

            int transactionOnDateCount = businessLayer.GetAllTransactionsCount(customerNumber);

            if (transactionOnDateCount > 0)
            {
                string balanceHistory = businessLayer.GetBalanceTransactions(customerNumber);
                IO.Print(balanceHistory);
            }
            else 
                IO.Print(IO.Type.ERROR, "Sorry, no transactions were found!");

            PromptForKeyPress();
        }

        static void Deactivate()
        {
            bool deletionNotYetConfirmed = true;
            string deactivateChoice = string.Empty;

            do
            {
                Console.Clear();

                IO.Print(IO.Type.ERROR, "WARNING: All data will be erased!");
                IO.Print("Are you sure you want to proceed?: ", false);
                deactivateChoice = Console.ReadLine();

                if (deactivateChoice.ToUpper() == "Y" || deactivateChoice.ToLower() == "y")
                {
                    bool isDeletionSuccessful = businessLayer.RemoveCustomer(customerNumber);

                    if (isDeletionSuccessful)
                    {
                        IO.Print(IO.Type.SUCCESS, "Commuter has been deactivated successfully!");
                        isCommuterLoggedIn = false;
                    }
                    else
                        IO.Print(IO.Type.ERROR, "Unable to deactivate commuter!");
                }
                else if (deactivateChoice.ToUpper() == "N" || deactivateChoice.ToLower() == "n")
                {
                    IO.Print("Returning to Commuter's menu...");
                    PromptForKeyPress();
                }
                else
                {
                    IO.Print("\nInput not in correct format, please try again!");
                    PromptForKeyPress();
                }
            }
            while ((deactivateChoice.ToUpper() != "Y" || deactivateChoice.ToLower() != "y") && (deactivateChoice.ToUpper() != "N" || deactivateChoice.ToLower() != "n"));
        }

        static void ViewChecksOnParticularDay()
        {
            Console.Clear();

            int day, month, year;

            try
            {
                IO.Print("Day: ", false);
                day = Convert.ToInt32(Console.ReadLine());
                IO.Print("Month: ", false);
                month = Convert.ToInt32(Console.ReadLine());
                IO.Print("Year: ", false);
                year = Convert.ToInt32(Console.ReadLine());

                if(businessLayer.CheckIfFutureDate(day, month, year))
                {
                    IO.Print(IO.Type.ERROR, "Date cannot be in the future!");
                    ViewChecksOnParticularDay();
                }
                else
                {
                    int transactionCount = businessLayer.GetTransactionCountOnDate(customerNumber, day, month, year);
                    if (transactionCount > 0)
                    {
                        string transactionOnDay = businessLayer.GetBalanceTransactionsOnDate(customerNumber, day, month, year);
                        IO.Print(transactionOnDay);
                        PromptForKeyPress();
                    }
                    else
                        IO.Print(IO.Type.ERROR, "Sorry, no transactions found!");
                }
            }
            catch(FormatException)
            {
                IO.Print(IO.Type.ERROR, "Textual input is not allowed!");
                ViewChecksOnParticularDay();
            }
        }

        static void CheckBalance()
        {
            Console.Clear();

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
                bool notRegisteredWithTallinja = businessLayer.CheckCommuterAnomaly(customerNumber);

                if (notRegisteredWithTallinja)
                    IO.Print(IO.Type.ERROR, "This customer number is not registered with Malta Public Transport!");
                else
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