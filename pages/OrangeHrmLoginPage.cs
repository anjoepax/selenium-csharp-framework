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
            Type(_usernameField, username);
            Type(_passwordField, password);
            return this;
        }

        public OrangeHrmHomePage ClickLoginButton()
        {
            Click(_loginButton);
            return new OrangeHrmHomePage();
        }

        public string GetPageTitle()
        {
            return DriverFactory.GetDriver().Title;
        }
    }
}