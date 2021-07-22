using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraping
{
    public class Chrome : WS
    {
        ChromeDriver chromeDriver;

        public Chrome() : base()
        {
            chromeDriver = (ChromeDriver)driver;
        }
    }
}
