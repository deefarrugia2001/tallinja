using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    class Login : Menu
    {
        public Login() 
        {
        }

        public string AddOptionsToMenu()
        {
            List<string> options = new List<string>() { "Login", "Exit" };
            return base.AddOptionsToMenu(options);
        }
    }
}