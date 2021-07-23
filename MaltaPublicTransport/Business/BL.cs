using Data;
using Domain;
using WebScraping;
using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Business
{
    public class BL
    {
        static Chrome chrome = null;
        static DL dataLayer = new DL();

        public decimal FetchBalance(int customerNumber)
        {
            decimal balance = 0.0m;

            chrome = new Chrome();
            chrome.Navigate("https://www.publictransport.com.mt/en/check-card-balance");

            IWebElement customerNumberField = chrome.FindElement(Element.ID, "ctl00_ctl00_ParentPageContent_PageContent_ContentControl_ctl00_txtCustomerId");
            customerNumberField.SendKeys(customerNumber.ToString());

            IWebElement checkBtn = chrome.FindElement(Element.ID, "ctl00_ctl00_ParentPageContent_PageContent_ContentControl_ctl00_btnCheckBalance");
            checkBtn.Submit();

            string balanceEuros = chrome.FindElement(Element.ID, "ctl00_ctl00_ParentPageContent_PageContent_ContentControl_ctl00_lblCardBalance2").Text;
            Console.WriteLine(balanceEuros);
            string balanceCents = chrome.FindElement(Element.ID, "ctl00_ctl00_ParentPageContent_PageContent_ContentControl_ctl00_lblBalanceCents").Text;

            balance = Convert.ToDecimal($"{balanceEuros}{balanceCents}");

            return balance;
        }

        public void CommitToCustomers(Command command, int customerNumber)
        {
            dataLayer.CommitToCustomer(command, customerNumber);
        }

        public int GetAdmissionsOnDate(int day, int month, int year)
        {
            DateTime admissionDate = new DateTime(year, month, day);
            //Set dayPostAdmission to the day after the admission date to check for admissions between the provided date and the day after.
            DateTime dayPostAdmission = admissionDate.AddDays(1);
            int admissionsCount = dataLayer.GetAdmissionsOnDate(admissionDate, dayPostAdmission).Count;
            return admissionsCount;
        }

        public string FetchCustomerStatement(int customerNumber) 
        {
            Customer customer = dataLayer.FetchCustomerByCN(customerNumber);
            return $"Customer ID: {customer.customer_id}\nCustomer number: {customer.customer_number}\nDate created: {customer.date}";
        }

        public Guid FetchCustomerID(int customerNumber) 
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
            return dataLayer.VerifyCustomerNumber(customerNumber).Count > 0;
        }

        public bool ValidateCustomerNumber(int customerNumber) 
        {
            return dataLayer.VerifyCustomerNumber(customerNumber).Count != 0;
        }
    }
}
