#pragma warning disable

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace WebScraping
{
    public enum Element
    {
        ID, CLASS, XPATH, TAG_NAME
    }

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

        public bool CheckElementExistence(Element elementType, string elementName)
        {
            try
            {
                switch(elementType) 
                {
                    case Element.CLASS:
                        driver.FindElement(By.ClassName(elementName));
                        break;
                    case Element.ID:
                        driver.FindElement(By.Id(elementName));
                        break;
                    case Element.XPATH:
                        driver.FindElement(By.XPath(elementName));
                        break;
                    case Element.TAG_NAME:
                        driver.FindElement(By.TagName(elementName));
                        break;
                }

                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public IWebElement FindElement(Element elementType, string elementName) 
        {
            IWebElement element = null;
            By elementToFetch = null;

            switch (elementType)
            {
                case Element.CLASS:
                    elementToFetch = By.ClassName(elementName);
                    break;
                case Element.ID:
                    elementToFetch = By.Id(elementName);
                    break;
                case Element.XPATH:
                    elementToFetch = By.XPath(elementName);
                    break;
                case Element.TAG_NAME:
                    elementToFetch = By.TagName(elementName);
                    break;
            }

            element = this.FindElement(elementToFetch);
            return element;
        }

        public IWebElement FindElement(By target)
        {
            IWebElement element = null;
            if (CheckElementExistence(target))
                element = driver.FindElement(target);
            return element;
        }

        private object GetService()
        {
            object service = null;

            if(this is Chrome)
            {
                service = ChromeDriverService.CreateDefaultService();
                ChromeDriverService chromeDriverService = (ChromeDriverService)service;
                chromeDriverService.HideCommandPromptWindow = true;
                chromeDriverService.SuppressInitialDiagnosticInformation = true;
                service = chromeDriverService;
            }
                
            if (this is Firefox) 
            {
                service = FirefoxDriverService.CreateDefaultService();
                FirefoxDriverService firefoxDriverService = (FirefoxDriverService)service;
                firefoxDriverService.HideCommandPromptWindow = true;
                firefoxDriverService.SuppressInitialDiagnosticInformation = true;
                service = firefoxDriverService;
            }
                
            return service;
        }

        private object GetOptions() 
        {
            object options = null;

            if (this is Chrome)
            {
                options = new ChromeOptions();
                ChromeOptions chromeOptions = (ChromeOptions)options;
                chromeOptions.AddArgument("--headless");
                options = chromeOptions;
            }
                
            if (this is Firefox)
            {
                options = new FirefoxOptions();
                FirefoxOptions firefoxOptions = (FirefoxOptions)options;
                firefoxOptions.AddArgument("--headless");
                options = firefoxOptions;
            }

            return options;
        }

        IWebDriver FetchDriverByBrowser()
        {
            object service = GetService();
            object options = GetOptions();

            if (this is Chrome)
            {
                driver = new ChromeDriver((ChromeDriverService)service, (ChromeOptions)options);
            }
            if (this is Firefox)
            {
                driver = new FirefoxDriver((FirefoxDriverService)service, (FirefoxOptions)options);
            }

            return driver;
        }
    }
}