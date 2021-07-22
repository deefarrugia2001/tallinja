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
        static Chrome chrome = new Chrome();
        static DL dataLayer = new DL();

        public void NavigateToCheckBalance() 
        {
            chrome.Navigate("https://www.publictransport.com.mt/en/check-card-balance");
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
