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
        static TallinjaEntities mptDB = new TallinjaEntities();

        public List<Customer> VerifyCustomerNumber(int customerNumber) 
        {
            List<Customer> customerNumbers = new List<Customer>(from customer in mptDB.Customers
                                                                where customer.customer_number == customerNumber
                                                                select customer);
            return customerNumbers;
        }

        public void AddCustomerNumber(Customer customer) 
        {
            mptDB.Customers.Add(customer);
            mptDB.SaveChanges();
        }
    }
}
