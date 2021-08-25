using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace selenium_nunit
{
    public sealed class ExplicitWaitFactory
    {

        private ExplicitWaitFactory(){}
        
        public static void PerformExplicitWait(By locator, WaitStrategy waitStrategy, string text="")
        {
            if(waitStrategy == WaitStrategy.VISIBLE)
            {
                new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(30))
                    .Until(_webDriver => DriverFactory.GetDriver().FindElement(locator).Displayed);

            }else if(waitStrategy == WaitStrategy.INVISIBLE)
            {
                WebDriverWait wait = new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(30));
                wait.IgnoreExceptionTypes(new[] {typeof(NoSuchElementException)});
                wait.Until(_webDriver => !DriverFactory.GetDriver().FindElement(locator).Displayed);

            }else if(waitStrategy == WaitStrategy.TEXT)
            {
                new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(30))
                    .Until(_webDriver => DriverFactory.GetDriver().FindElement(locator).Text == text);

            }else if(waitStrategy == WaitStrategy.CLICKABLE)
            {
                new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(30))
                    .Until(_webDriver => DriverFactory.GetDriver().FindElement(locator).Enabled);
            }
        }
    }
}