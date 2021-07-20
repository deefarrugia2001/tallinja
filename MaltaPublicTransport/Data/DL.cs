using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class DL
    {
        static TallinjaEntities mptDB = new TallinjaEntities();
        
        public List<Customer> GetAdmissionsOnDate(DateTime admissionDate, DateTime dayPostSubmission) 
        {
            List<Customer> customersOnDate = new List<Customer>(from customer in mptDB.Customers
                                                                where customer.date >= admissionDate && customer.date <= dayPostSubmission
                                                                select customer);
            return customersOnDate;
        }

        public Customer FetchCustomerByCN(int customerNumber)
        {
            Customer customerToFetch = VerifyCustomerNumber(customerNumber).SingleOrDefault();
            return customerToFetch;
        }

        public Guid FetchCustomerID(int customerNumber) 
        {
            Customer customerToFetch = FetchCustomerByCN(customerNumber);
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
            bool commitSuccessful = true;

            try 
            {
                mptDB.Customers.Add(customer);
                mptDB.SaveChanges();
            }
            catch(System.Data.Entity.Infrastructure.DbUpdateException)
            {
                commitSuccessful = false;
            }

            return commitSuccessful;
        }
    }
}