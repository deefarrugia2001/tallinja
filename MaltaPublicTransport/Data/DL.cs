using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DL
    {
        static tallinjaEntities mptDB = new tallinjaEntities();

        public List<customer> VerifyCustomerNumber(int customerNumber) 
        {
            List<customer> customerNumbers = new List<customer>(from customer in mptDB.customers
                                                                where customer.customer_number == customerNumber
                                                                select customer);
            return customerNumbers;
        }

        public void AddCustomerNumber(customer customer) 
        {
            mptDB.customers.Add(customer);
            mptDB.SaveChanges();
        }
    }
}
