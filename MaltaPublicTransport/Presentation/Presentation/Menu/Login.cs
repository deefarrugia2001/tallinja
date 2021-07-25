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
            List<string> options = new List<string>() { "Login", "Exit" };
            return base.AddOptionsToMenu("Login", options);
        }
    }
}