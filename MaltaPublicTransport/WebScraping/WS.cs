using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebScraping
{
    public abstract class WS
    {
        protected IWebDriver driver;

        public WS()
        {
            this.driver = FetchDriverByBrowser();
        }

        public void Navigate(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public bool CheckElementExistence(By target)
        {
            try
            {
                driver.FindElement(target);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        IWebDriver FetchDriverByBrowser()
        {
            if (this is Chrome)
                driver = new ChromeDriver();

            return driver;
        }
    }
}
