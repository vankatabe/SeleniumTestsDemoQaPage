using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestsDemoQaPage.Pages.DraggablePage
{
    public static class DraggablePageAsserter
    {
        public static void AssertElementIsMovedCorrectly(this DraggablePage page, int horizontalOffset, int verticalOffset, IWebElement element)
        {
            Assert.AreEqual(page.HorizontalPosition + horizontalOffset, element.Location.X, "X-offset not correct");
            Assert.AreEqual(page.VerticalPosition + verticalOffset, element.Location.Y, "Y-offset not correct");
        }

        public static void AssertElementIsMovedCounter(this DraggablePage page, int expectedCount, IWebElement element)
        {
            Assert.AreEqual(expectedCount, int.Parse(element.Text));
        }

        public static void AssertElementIsMoved(this DraggablePage page, int horizontalOffset, int verticalOffset, IWebElement element)
        {
            Assert.AreNotEqual(page.HorizontalPosition, element.Location.X);
            Assert.AreNotEqual(page.VerticalPosition, element.Location.Y);
        }

        public static void AssertSortableElementIsMovedAtBottom(this DraggablePage page, string text)
        {
            page.Wait.Until(w => text.Contains(page.DraggableSortableElement5.Text));
            StringAssert.Contains(text, page.DraggableSortableElement5.Text);
        }
    }
}
