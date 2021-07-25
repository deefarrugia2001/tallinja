#pragma warning disable

using Business;
using System;
using System.Threading;

namespace Presentation
{
    class PL
    {
        int customerNumber;

        static BL businessLayer = new BL();
        static Login login = new Login();

        static void Main(string[] args)
        {
            Console.ReadLine();
        }
    }
}