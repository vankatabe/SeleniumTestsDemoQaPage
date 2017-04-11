using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestsDemoQaPage.Pages.ResizablePage
{
    public static class ResizablePageAsserter
    {
        public static void AssertSizeIncreasedWith(this ResizablePage page, int increase)
        {
            Assert.AreEqual(page.Width + increase, page.resizeWindow.Size.Width);
            Assert.AreEqual(page.Height + increase, page.resizeWindow.Size.Height);
        }
    }
}
