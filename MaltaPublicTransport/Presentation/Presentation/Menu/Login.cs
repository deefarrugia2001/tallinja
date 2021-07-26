using System.Collections.Generic;

namespace Presentation
{
    class Login : Menu
    {
        public Login() 
        {
        }

        public string AddOptionsToMenu()
        {
            List<string> options = new List<string>() { "Login", "Add commuter", "Exit" };
            return base.AddOptionsToMenu(options);
        }
    }
}