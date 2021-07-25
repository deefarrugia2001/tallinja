#pragma warning disable

using OpenQA.Selenium.Firefox;

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