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
            List<string> options = new List<string>() { "Login", "Add commuter", "Exit" };
            return base.AddOptionsToMenu(options);
        }
    }
}
