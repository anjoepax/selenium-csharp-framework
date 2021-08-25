using System;


namespace selenium_nunit
{
    public sealed class Driver
    {
        private Driver(){}

        public static void InitBrowserDriver(string browser)
        {
            try
            {
                if(DriverFactory.GetDriver().ToString() == null)
                {
                    DriverFactory.SetDriver(browser);
                    DriverFactory.GetDriver().Manage().Window.Maximize();
                }

            }catch(NullReferenceException)
            {
                DriverFactory.SetDriver(browser);
                DriverFactory.GetDriver().Manage().Window.Maximize();
            }
        }

        public static void QuitBrowserDriver()
        {
            if(DriverFactory.GetDriver() != null)
            {
                DriverFactory.GetDriver().Quit();
                DriverFactory.DisposeDriver();
            }
        }
    }
}