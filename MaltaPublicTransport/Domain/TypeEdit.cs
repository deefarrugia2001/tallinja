using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Domain
{
    partial class Customer 
    {
        public Customer() 
        {
        }

        public Customer(int customerNumber) 
        {
            this.customer_number = customerNumber;
            this.date = DateTime.Now;
        }
    }

    partial class CustomersBalance 
    {
        public CustomersBalance() 
        {
        }

        public CustomersBalance(int customerID, decimal balance) 
        {
            this.customer_id = customerID;
            this.balance = balance;
            this.date = DateTime.Now;
        }
    }
}
