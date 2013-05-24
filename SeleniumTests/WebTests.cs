using System;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumTests
{
    [TestClass]
    public class WebTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [TestMethod]
        public void TestMethod1()
        {
            var driver = new FirefoxDriver();
            var verificationErrors = new StringBuilder();
            driver.Navigate().GoToUrl("http://www.lawruk.com");
            Assert.AreEqual("", verificationErrors.ToString());
            driver.Quit();

        }
    }
}
