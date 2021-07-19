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
        //static Chrome chrome = new Chrome();
        static DL dataLayer = new DL();

        public void AddCustomerNumber(int customerNumber) 
        {
            customer customer = new customer(customerNumber);
            dataLayer.AddCustomerNumber(customer);
        }
    }
}
