using NUnit.Framework;

namespace selenium_nunit
{
    public class BaseTest
    {
        protected BaseTest(){}

        [SetUp]
        public void InitializeTestEnvi()
        {
            Driver.InitBrowserDriver("chrome");
            DriverFactory.GetDriver().Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
        }

        [TearDown]
        public void TearDownTestEnvi()
        {
            Driver.QuitBrowserDriver();
        }
    }
}