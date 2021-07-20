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
        
        public Customer FetchCustomerByCN(int customerNumber)
        {
            Customer customerToFetch = (from customer in mptDB.Customers
                                        where customer.customer_number == customerNumber
                                        select customer).SingleOrDefault();
            return customerToFetch;
        }

        public Guid FetchCustomerID(int customerNumber) 
        {
            Customer customerToFetch = mptDB.Customers.SingleOrDefault(customer => customer.customer_number == customerNumber);
            return customerToFetch.customer_id;
        }

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
