using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestsDemoQaPage.Pages.ToolsQaHomePage
{
    public static class ToolsQaHomePageAsserter
    {
        public static void AssertToolsQaLogoSrcContains(this ToolsQaHomePage page, string text)
        {
            StringAssert.Contains(text, page.Logo.GetAttribute("src"));
        }

        public static void AssertNumberOfWindowsHandled(this IWebDriver driver, int number)
        {
            Assert.AreEqual(number, driver.WindowHandles.Count);
            // Another way of writing it:
            Assert.IsTrue(driver.WindowHandles.Count == number);
        }
    }
}
