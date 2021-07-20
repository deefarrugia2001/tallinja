using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class DL
    {
        static TallinjaEntities mptDB = new TallinjaEntities();
        
        public List<Customer> GetAdmissionsOnDate(DateTime admissionDate) 
        {
            List<Customer> customersOnDate = new List<Customer>(from customer in mptDB.Customers
                                                                where customer.date >= admissionDate
                                                                select customer);
            return customersOnDate;
        }

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

        public bool AddCustomerNumber(Customer customer) 
        {
            try 
            {
                mptDB.Customers.Add(customer);
                mptDB.SaveChanges();
                return true;
            }
            catch(System.Data.Entity.Infrastructure.DbUpdateException)
            {
                return false;
            }
        }
    }
}