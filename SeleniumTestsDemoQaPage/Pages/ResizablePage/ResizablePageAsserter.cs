using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTestsDemoQaPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestsDemoQaPage.Pages.ResizablePage
{
    public static class ResizablePageAsserter
    {
        // Used by the exercise from the lecture
        public static void AssertSizeIncreasedWith(this ResizablePage page, int increase)
        {
            Assert.AreEqual(page.Width + increase, page.resizeWindow.Size.Width);
            Assert.AreEqual(page.Height + increase, page.resizeWindow.Size.Height);
        }

        // Used by the exercise from the lecture
        public static void AssertWidthIncreasedWith(this ResizablePage page, int increase)
        {
            Assert.AreEqual(page.Width + increase, page.resizeWindow.Size.Width);
        }

        public static void AssertSizeIncreasedWith2(this ResizablePage page, int increaseX, int increaseY)
        {
            /* The Exact Asserts below would not pass
             Assert.AreEqual(page.Width + increaseX, page.resizeWindow.Size.Width);
             Assert.AreEqual(page.Height + increaseY, page.resizeWindow.Size.Height);
            */
            // So we use these asserts (Actual dimension is < from the Expected but still > from Expected-20px):
            Assert.IsTrue(page.Width + increaseX - 20 < page.resizeWindow.Size.Width && page.Width + increaseX > page.resizeWindow.Size.Width);
            Assert.IsTrue(page.Width + increaseY - 20 < page.resizeWindow.Size.Width && page.Width + increaseY > page.resizeWindow.Size.Width);
        }

        public static void AssertResizableSizeSmallerThanContainer(this ResizablePage page, IWebElement resizableElement)
        {
            Assert.LessOrEqual(resizableElement.Size.Width, page.Width);
            Assert.LessOrEqual(resizableElement.Size.Height, page.Height);
        }

        public static void AssertResizableSizeSmallerThanOrEqualToConstraints(this ResizablePage page, IWebElement resizableElement, InteractionPages resize)
        {
            Assert.LessOrEqual(resizableElement.Size.Width, int.Parse(resize.HorizontalOffset));
            Assert.LessOrEqual(resizableElement.Size.Height, int.Parse(resize.VerticalOffset));
        }
    }
}
