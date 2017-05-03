using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestsDemoQaPage.Pages.SelectablePage
{
    public static class SelectablePageAsserter
    {
        public static void AssertSelectedAttribute(this SelectablePage page, string text, IWebElement element)
        {
            Assert.AreEqual(text, element.GetAttribute("class"));
        }

        public static void AssertSelectedAttributes(this SelectablePage page, string text, IWebElement element)
        {
            Assert.AreEqual(text, element.GetAttribute("class"));
        }

        public static void AssertSelectedElementNumberIsDisplayed(this SelectablePage page, string text, IWebElement element)
        {
            StringAssert.Contains(text, page.SelectedElementDisplay.Text);
        }
    }
}
