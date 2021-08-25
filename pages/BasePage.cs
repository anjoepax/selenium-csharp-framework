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
        public void Click(By locator, WaitStrategy strategy) 
        {
            ExplicitWaitFactory.PerformExplicitWait(locator, strategy);
            FindElement(locator).Click();
        }

        /*** Type text ***/
        public void Type(By locator, WaitStrategy waitStrategy, string text)
        {
            ExplicitWaitFactory.PerformExplicitWait(locator, waitStrategy);
            FindElement(locator).SendKeys(text);
        }

        /*** Type text and enter ***/
        public void TypeAndEnter(By locator, WaitStrategy waitStrategy, string text)
        {   
            ExplicitWaitFactory.PerformExplicitWait(locator, waitStrategy);
            FindElement(locator).SendKeys(text);
            FindElement(locator).SendKeys(Keys.Enter);
        }
    }
}