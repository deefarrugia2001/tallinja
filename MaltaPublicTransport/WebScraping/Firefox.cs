using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraping
{
    public class Firefox : WS
    {
        FirefoxDriver firefoxDriver;

        public Firefox() : base() 
        {
            firefoxDriver = (FirefoxDriver)driver;
        }
    }
}
