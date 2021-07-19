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
            this.customer_id = Guid.NewGuid();
            this.customer_number = customerNumber;
        }
    }

    partial class CustomersBalance 
    {
        public CustomersBalance() 
        {
        }

        public CustomersBalance(decimal balance) 
        {
            this.balance = balance;
            this.date = DateTime.Now;
        }
    }
}
