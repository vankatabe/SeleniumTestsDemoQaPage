using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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

        public static void Column1ElementCountDecreased(this SortablePage page, IWebDriver driver, List<IWebElement> SortableItemsColumn1, int oldCount)
        {
            Assert.IsTrue(SortableItemsColumn1.Count == oldCount - 1);
        }

        public static void Column2ElementCountIncreased(this SortablePage page, IWebDriver driver, List<IWebElement> SortableItemsColumn2, int oldCount)
        {
            Assert.IsTrue(SortableItemsColumn2.Count == oldCount + 1);
        }

        public static void AssertElement1MovedToElement2Position(this SortablePage page, IWebDriver driver, Point expectedElement1PositionAfter, IWebElement element1)
        {
            Assert.AreEqual(expectedElement1PositionAfter, element1.Location);
        }
    }
}
