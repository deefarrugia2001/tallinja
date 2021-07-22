using OpenQA.Selenium.Chrome;

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