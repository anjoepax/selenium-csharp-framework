using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace selenium_nunit
{
    public class BasePage
    {
        protected BasePage(){}

        /*** Private method for finding element ***/
        private IWebElement FindElement(By locator)
        {
            return DriverFactory.GetDriver().FindElement(locator);
        }

        /*** Private method for finding elements ***/
        private ReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            return DriverFactory.GetDriver().FindElements(locator);
        }
        

        /*** Clicking of element ***/
        public void Click(By locator) 
        {
            WaitForElementToDisplay(locator);
            FindElement(locator).Click();
        }

        /*** Type text ***/
        public void Type(By locator, string text)
        {
            FindElement(locator).SendKeys(text);
        }

        /*** Type text and enter ***/
        public void TypeAndEnter(By locator, string text)
        {
            FindElement(locator).SendKeys(text);
            FindElement(locator).SendKeys(Keys.Enter);
        }

        /*** Private method for waiting ***/
        private void WaitForElementToDisplay(By locator)
        {
            new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(30))
                .Until(_webDriver => FindElement(locator).Displayed);
        }

        private void WaitForElementToBeDetachedInDom(By locator)
        {
            WebDriverWait wait = new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(30));
            wait.IgnoreExceptionTypes(new[] {typeof(NoSuchElementException)});
            wait.Until(_webDriver => !FindElement(locator).Displayed);
        }

        private void WaitForElementTextToBe(By locator, string text)
        {
            new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(30))
                .Until(_webDriver => FindElement(locator).Text == text);
        }
    }
}