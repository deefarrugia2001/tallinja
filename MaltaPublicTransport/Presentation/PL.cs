using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    class PL
    {
        static BL businessLayer = new BL();

        static void Main(string[] args)
        {
            businessLayer.AddCustomerNumber(14007122);
            int count = businessLayer.GetAdmissionsOnDate(20, 7, 2021);
            Console.WriteLine($"Number of admissions: ${count}");

            //string statement = businessLayer.FetchCustomerStatement(14161828);
            //Console.WriteLine(statement);

            //Guid customerId = businessLayer.FetchCustomerID(14161828);
            //Console.WriteLine(customerId);

            Console.ReadLine();
        }
    }
}