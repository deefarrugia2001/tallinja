using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    class Commuter : Menu
    {
        public Commuter()
        {
        }

        public string AddOptionsToMenu()
        {
            List<string> options = new List<string>() { "Check balance", "View balance on a particular day", "View all balance transactions", "View account information", "Deactivate", "Log out" };
            return base.AddOptionsToMenu(options);
        }
    }
}
