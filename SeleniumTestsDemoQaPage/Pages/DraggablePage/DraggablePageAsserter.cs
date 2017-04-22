using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestsDemoQaPage.Pages.DraggablePage
{
    public static class DraggablePageAsserter
    {
        public static void AssertElementIsMoved(this DraggablePage page, int horizontalOffset, int verticalOffset)
        {
            Assert.AreEqual(page.HorizontalPosition + horizontalOffset, page.DraggableElement.Location.X);
            Assert.AreEqual(page.VerticalPosition + verticalOffset, page.DraggableElement.Location.Y);
        }
    }
}
