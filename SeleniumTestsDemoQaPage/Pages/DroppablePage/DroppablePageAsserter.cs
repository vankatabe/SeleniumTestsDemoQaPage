using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestsDemoQaPage.Pages.DroppablePage
{
    public static class DroppablePageAsserter
    {
        public static void AssertTargetAttribute(this DroppablePage page, string text) // Used for the exercises from the lecture
        {
            Assert.AreEqual(text, page.TargetElement.GetAttribute("class"));
        }

        public static void AssertTargetAttribute2(this DroppablePage page, string text, IWebElement element)
        {
            Assert.AreEqual(text, element.GetAttribute("class"));
        }

        public static void AssertElementPosition(this DroppablePage page, IWebElement element)
        {
            page.Wait.Until(w => page.Position == element.Location);
            Assert.AreEqual(page.Position, element.Location);
        }

        public static void AssertTargetContains(this DroppablePage page, string text)
        {
            var texts = page.TargetElementContainerTab5.Text;
            StringAssert.Contains(text, page.TargetElementContainerTab5.Text);
        }
    }
}
