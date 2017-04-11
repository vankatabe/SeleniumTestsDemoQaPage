using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestsDemoQaPage.Pages.DroppablePage
{
    public static class DroppablePageAsserter
    {
        public static void AssertElementIsDroppedAttribute(this DroppablePage page, string text)
        {
            Assert.AreEqual(text, page.TargetElement.GetAttribute("class"));
        }
    }
}
