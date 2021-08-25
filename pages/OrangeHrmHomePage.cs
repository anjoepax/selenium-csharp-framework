using OpenQA.Selenium;

namespace selenium_nunit
{
    public sealed class OrangeHrmHomePage : BasePage
    {
        private By _welcomeLink = By.Id("welcome");
        private By _logoutLink = By.LinkText("Logout");


        public OrangeHrmLoginPage LogoutToApplication()
        {
            Click(_welcomeLink, WaitStrategy.VISIBLE);
            Click(_logoutLink, WaitStrategy.VISIBLE);
            return new OrangeHrmLoginPage();
        }
    }
}