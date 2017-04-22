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
        public static void AssertElementIsMoved(this DraggablePage page, int horizontalOffset, int verticalOffset, IWebElement element)
        {
            Assert.AreEqual(page.HorizontalPosition + horizontalOffset, element.Location.X, "X-offset not correct");
            Assert.AreEqual(page.VerticalPosition + verticalOffset, element.Location.Y, "Y-offset not correct");
        }
    }
}
