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

        public Customer FetchCustomerStatement(int customerNumber) 
        {
            Customer customer = dataLayer.FetchCustomerByCN(customerNumber);
            Guid customerID = dataLayer.FetchCustomerID(customerNumber);
            return dataLayer.FetchCustomerByCN(customerNumber);
        }

        public Guid FetchCustomerID(int customerNumber) 
        {
            return dataLayer.FetchCustomerID(customerNumber);
        }

        public void AddCustomerNumber(int customerNumber) 
        {
            Customer customer = new Customer(customerNumber);
            dataLayer.AddCustomerNumber(customer);
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
