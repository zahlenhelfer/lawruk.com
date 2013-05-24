using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumTests
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected string baseURL;
        private bool acceptNextAlert = true;

        public BaseTest()
        {
            baseURL = "http://www.lawruk.com";
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
        }

        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(baseURL + url);
        }

        public IWebElement GetByCSS(string selector)
        {
            return driver.FindElement(By.CssSelector(selector));
        }

        public string GetText(string selector)
        {
            return GetByCSS(selector).Text;
        }

        public void AssertText(string selector, string text)
        {
            Assert.IsTrue(GetText(selector) == text);
        }
    }
}
