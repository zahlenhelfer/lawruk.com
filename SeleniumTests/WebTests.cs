using System;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumTests
{
    [TestClass]
    public class WebTests : BaseTest
    {       

        [TestMethod]
        public void TestMethod1()
        {
            GoToUrl("/");            
            AssertText(".brand", "Lawruk.com");
            AssertText(".personaName", "About");
            driver.Quit();
        }
    }
}
