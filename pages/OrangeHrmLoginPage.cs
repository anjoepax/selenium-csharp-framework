using OpenQA.Selenium;

namespace selenium_nunit
{
    public sealed class OrangeHrmLoginPage : BasePage
    {

        private By _usernameField = By.Id("txtUsername");
        private By _passwordField = By.Id("txtPassword");
        private By _loginButton = By.Id("btnLogin");

        public OrangeHrmLoginPage EnterCredentials(string username, string password)
        {
            Type(_usernameField, WaitStrategy.VISIBLE, username);
            Type(_passwordField, WaitStrategy.VISIBLE, password);
            return this;
        }

        public OrangeHrmHomePage ClickLoginButton()
        {
            Click(_loginButton, WaitStrategy.VISIBLE);
            return new OrangeHrmHomePage();
        }

        public string GetPageTitle()
        {
            return DriverFactory.GetDriver().Title;
        }
    }
}