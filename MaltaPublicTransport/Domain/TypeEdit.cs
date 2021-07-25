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
            this.date = DateTime.Now;
        }
    }

    partial class CustomersBalance 
    {
        public CustomersBalance() 
        {
        }

        public CustomersBalance(Guid customer_id, decimal balance) 
        {
            this.customer_id = customer_id;
            this.balance = balance;
            this.date = DateTime.Now;
        }
    }
}
