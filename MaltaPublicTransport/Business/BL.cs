#pragma warning disable

using Data;
using Domain;
using WebScraping;
using System;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Business
{
    public class BL
    {
        static Chrome chrome = null;
        static DL dataLayer = new DL();
        private static void StartWebScraping(int customerNumber)
        {
            chrome = new Chrome();
            chrome.Navigate("https://www.publictransport.com.mt/en/check-card-balance");

            IWebElement customerNumberField = chrome.FindElement(Element.ID, "ctl00_ctl00_ParentPageContent_PageContent_ContentControl_ctl00_txtCustomerId");
            customerNumberField.SendKeys(customerNumber.ToString());

            IWebElement checkBtn = chrome.FindElement(Element.ID, "ctl00_ctl00_ParentPageContent_PageContent_ContentControl_ctl00_btnCheckBalance");
            checkBtn.Submit();
        }

        public decimal FetchBalance(int customerNumber)
        {
            decimal balance = 0.0m;
            StartWebScraping(customerNumber);

            string balanceEuros = chrome.FindElement(Element.ID, "ctl00_ctl00_ParentPageContent_PageContent_ContentControl_ctl00_lblCardBalance2").Text;
            string balanceCents = chrome.FindElement(Element.ID, "ctl00_ctl00_ParentPageContent_PageContent_ContentControl_ctl00_lblBalanceCents").Text;

            balance = Convert.ToDecimal($"{balanceEuros}{balanceCents}");

            return balance;
        }

        public bool CheckCommuterAnomaly(int customerNumber)
        {
            StartWebScraping(customerNumber);
            return chrome.CheckElementVisibility(By.Id("ctl00_ctl00_ParentPageContent_PageContent_ContentControl_ctl00_divError"));
        }

        public void AddBalance(int customerNumber, decimal balance) 
        {
            dataLayer.AddBalance(customerNumber, balance);
        }

        public void CommitToCustomers(Command command, int customerNumber)
        {
            dataLayer.CommitToCustomer(command, customerNumber);
        }

        public string GetBalanceTransactions(int customerNumber) 
        {
            string transactionHistory = string.Empty;
            List<CustomersBalance> transactions = dataLayer.GetBalanceTransactions(customerNumber);
            
            transactionHistory += $"Balance\tDate checked\n=======\t===================\n";

            foreach (CustomersBalance transaction in transactions)
                transactionHistory += GetBalanceTransactions(transaction);

            return transactionHistory;
        }

        private string GetBalanceTransactions(CustomersBalance transaction)
        {
            return $"{transaction.balance}\t{transaction.date}\n";
        }

        public string GetCommuterInformation(int customerNumber) 
        {
            string commuterInformation = string.Empty;

            Customer customer = dataLayer.FetchCustomerByCN(customerNumber);
            int allTransactionCount = GetAllTransactionsCount(customerNumber);

            commuterInformation += $"Customer number: {customer.customer_number}\nDate joined: {customer.date}\n";

            if (allTransactionCount > 0)
            {
                CustomersBalance lastTransaction = dataLayer.GetLastTransaction(customerNumber);
                DateTime dateLastChecked = lastTransaction.date;
                decimal balance = lastTransaction.balance;
                commuterInformation += $"\nTotal balance checks: {allTransactionCount}\nBalance: {balance} as of {dateLastChecked}\n";
            }
            else
                commuterInformation += $"You have no transactions yet!\n";

            return commuterInformation;
        }

        public int GetAdmissionsOnDate(int day, int month, int year)
        {
            DateTime admissionDate = new DateTime(year, month, day);
            //Set dayPostAdmission to the day after the admission date to check for admissions between the provided date and the day after.
            DateTime dayPostAdmission = admissionDate.AddDays(1);
            int admissionsCount = dataLayer.GetAdmissionsOnDate(admissionDate, dayPostAdmission).Count;
            return admissionsCount;
        }

        public int GetAllTransactionsCount(int customerNumber)
        {
            return dataLayer.GetBalanceTransactions(customerNumber).Count;
        }

        public int GetTransactionCountOnDate(int customerNumber, int day, int month, int year)
        {
            DateTime checkDate = new DateTime(year, month, day);
            DateTime postCheckDate = checkDate.AddDays(1);
            int transactionCount = dataLayer.GetAdmissionsOnDate(checkDate, postCheckDate).Count;
            return transactionCount;
        }

        public bool CheckIfFutureDate(int day, int month, int year) 
        {
            try
            {
                DateTime checkDate = new DateTime(year, month, day);
                return checkDate > DateTime.Today;
            }
            catch(ArgumentException) 
            {
                return true;
            }
        }

        public string GetBalanceTransactionsOnDate(int customerNumber, int day, int month, int year) 
        {
            string transactionHistoryOnDate = string.Empty;
            DateTime checkDate = new DateTime(year, month, day);
            DateTime dayPostCheckBalance = checkDate.AddDays(1);

            List<CustomersBalance> transactions = dataLayer.GetBalanceTransactionsOnDate(customerNumber, checkDate, dayPostCheckBalance);
            int transactionCount = transactions.Count;

            transactionHistoryOnDate += $"\nThere are a total of {transactionCount} transactions:\n";
            transactionHistoryOnDate += $"\nBalance\tDate checked\n=======\t===================\n";

            foreach (CustomersBalance transaction in transactions)
                transactionHistoryOnDate += GetBalanceTransactions(transaction);

            return transactionHistoryOnDate;
        }

        public string FetchCustomerStatement(int customerNumber) 
        {
            Customer customer = dataLayer.FetchCustomerByCN(customerNumber);
            return $"Customer ID: {customer.customer_id}\nCustomer number: {customer.customer_number}\nDate created: {customer.date}";
        }

        public int FetchCustomerID(int customerNumber) 
        {
            return dataLayer.FetchCustomerID(customerNumber);
        }

        public bool AddCustomer(int customerNumber) 
        {
            return dataLayer.AddCustomer(customerNumber);
        }

        public bool RemoveCustomer(int customerNumber)
        {
            return dataLayer.RemoveCustomer(customerNumber);
        }

        public bool VerifyCNUniqueness(int customerNumber) 
        {
            return dataLayer.VerifyCustomerNumber(customerNumber).Count == 0;
        }

        public bool ValidateCustomerNumber(int customerNumber) 
        {
            return dataLayer.VerifyCustomerNumber(customerNumber).Count != 0;
        }
    }
}
