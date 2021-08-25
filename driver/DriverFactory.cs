using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


namespace selenium_nunit
{
    public sealed class DriverFactory
    {

        private static ThreadLocal<IWebDriver> dr;
        private DriverFactory(){}

        public static IWebDriver GetDriver()
        {
            return dr.Value;
        }

        public static void SetDriver(string browser)
        {
            if(browser.ToLower().Trim().Equals("edge"))
            {
                dr = new ThreadLocal<IWebDriver>(() => {
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    return new EdgeDriver();
                });
            }else
            {
                dr = new ThreadLocal<IWebDriver>(() => {
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    return new ChromeDriver();
                });
            }
        }

        public static void DisposeDriver()
        {
            dr.Dispose();
        }
    }
}