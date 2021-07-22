﻿using Data;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Presentation
{
    class PL
    {
        static BL businessLayer = new BL();
        static Login login = new Login();

        static void Main(string[] args)
        {
            Console.WriteLine(login.AddOptionsToMenu());
            Console.Write("Please enter a choice from the menu: ");
            Console.ReadLine();
        }
    }
}