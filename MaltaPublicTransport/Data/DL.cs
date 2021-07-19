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

        public void AddCustomerNumber(customer customer) 
        {
            mptDB.customers.Add(customer);
            mptDB.SaveChanges();
        }
    }
}
