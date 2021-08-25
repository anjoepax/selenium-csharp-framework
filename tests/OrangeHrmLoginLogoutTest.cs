using System;
using NUnit.Framework;

namespace selenium_nunit
{
    public sealed class OrangeHrmLoginLogoutTest : BaseTest
    {
        private OrangeHrmLoginPage loginPage;

        [SetUp]
        public void InitializePages()
        {
            loginPage = new OrangeHrmLoginPage();
        }

        [Test]
        public void LoginUsingValidCredentials()
        {
            string pageTitle = loginPage.EnterCredentials("Admin", "admin123")
                    .ClickLoginButton()
                    .LogoutToApplication()
                    .GetPageTitle();
            Assert.AreEqual("OrangeHRM", pageTitle);
        }
    }
}