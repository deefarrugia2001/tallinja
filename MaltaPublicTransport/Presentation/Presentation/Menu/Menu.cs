using System.Collections.Generic;

namespace Presentation
{
    abstract class Menu
    {
        public Menu() 
        {
        }

        public string AddOptionsToMenu(string menuTitle, List<string> options) 
        {
            string menu = $"{menuTitle}\n";
            foreach (char characters in menuTitle)
                menu += "=";
            menu += "\n";

            for(int optionIndex = 0; optionIndex < options.Count; optionIndex++)
            {
                menu += $"{optionIndex + 1}. {options[optionIndex]}";
                //Do not skip a line after the last menu item.
                if (optionIndex < options.Count - 1)
                    menu += "\n";
            }

            return menu;
        } 
    }
}