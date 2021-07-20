using Data;
using Domain;
using WebScraping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Business
{
    public class BL
    {
        static Chrome chrome = new Chrome();
        static DL dataLayer = new DL();

        public int GetAdmissionsOnDate(int day, int month, int year)
        {
            DateTime admissionDate = new DateTime(year, month, day);
            DateTime dayPostAdmission = admissionDate.AddDays(1);
            List<Customer> customerAdmissions = dataLayer.GetAdmissionsOnDate(admissionDate, dayPostAdmission);
            int count = customerAdmissions.Count;
            return count;
        }

        public string FetchCustomerStatement(int customerNumber) 
        {
            string statement = string.Empty;
            Customer customer = dataLayer.FetchCustomerByCN(customerNumber);
            statement = $"Customer ID: {customer.customer_id}\nCustomer number: {customer.customer_number}\nDate created: {customer.date}";
            return statement;
        }

        public bool RemoveCustomer(int customerNumber)
        {
            return dataLayer.RemoveCustomer(customerNumber);
        }

        public Guid FetchCustomerID(int customerNumber) 
        {
            return dataLayer.FetchCustomerID(customerNumber);
        }

        public bool AddCustomer(int customerNumber) 
        {
            return dataLayer.AddCustomer(customerNumber);
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
