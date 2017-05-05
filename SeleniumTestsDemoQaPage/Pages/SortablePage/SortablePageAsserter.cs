using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestsDemoQaPage.Pages.SortablePage
{
    public static class SortablePageAsserter
    {

        public static void ElementSortedOrder(this SortablePage page, int higherElementPosition, int lowerElementPosition)
        {
            Assert.IsTrue(higherElementPosition < lowerElementPosition);
        }


        public static void ElementSortedOrderAnotherWayOfAssert(this SortablePage page, int item2PositionAfter, int item1PositionAfter)
        {
            // Assert that position of element 2 is lower count (before) element 1's position
            Assert.IsTrue(item2PositionAfter < item1PositionAfter);
        }
    }
}
