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
            businessLayer.AddCustomerNumber(14161828);
        }
    }
}