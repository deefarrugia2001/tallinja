using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public enum Command
    {
        ADD, DELETE
    }

    public class DL
    {
        static TallinjaEntities mptDB = new TallinjaEntities();
        
        public List<Customer> GetAdmissionsOnDate(DateTime admissionDate, DateTime dayPostSubmission) 
        {
            List<Customer> customersOnDate = new List<Customer>(from customer in mptDB.Customers
                                                                where customer.date >= admissionDate && customer.date < dayPostSubmission
                                                                select customer);
            return customersOnDate;
        }

        public void CommitToCustomer(Command command, int customerNumber) 
        {
            if (command == Command.ADD)
                this.AddCustomer(customerNumber);
            else if (command == Command.DELETE)
                this.RemoveCustomer(customerNumber);
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

        public bool RemoveCustomer(int customerNumber) 
        {
            bool commitSuccessful = true;

            try
            {
                Customer customerToRemove = FetchCustomerByCN(customerNumber);
                mptDB.Customers.Remove(customerToRemove);
                mptDB.SaveChanges();
            }
            //ex may be of type ArgumentNullException due to the result returned by FetchCustomerByCN (due to SingleOrDefault()).
            catch (Exception ex) when (ex is ArgumentNullException || ex is System.Data.Entity.Infrastructure.DbUpdateException) 
            {
                commitSuccessful = false;
            }

            return commitSuccessful;
        }

        public bool AddCustomer(int customerNumber) 
        {
            bool commitSuccessful = true;

            try 
            {
                Customer customer = new Customer(customerNumber);
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