using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    partial class customer 
    {
        public customer(int customerNumber) 
        {
            this.customer_number = customerNumber;
        }
    }

    partial class customers_balance 
    {
        public customers_balance() 
        {
        }

        public customers_balance(decimal balance) 
        {
            this.balance = balance;
            this.date = DateTime.Now;
        }
    }
}
