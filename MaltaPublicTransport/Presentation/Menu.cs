using System;
using System.Collections.Generic;

namespace Presentation
{
    abstract class Menu
    {
        public Menu() 
        {
        }

        public string AddOptionsToMenu(List<string> options) 
        {
            string menu = string.Empty;
            for(int optionIndex = 1; optionIndex < options.Count; optionIndex++)
                menu += $"{optionIndex}. {options[optionIndex]}\n";
            return menu;
        } 
    }
}