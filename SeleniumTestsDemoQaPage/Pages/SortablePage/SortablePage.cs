using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumTestsDemoQaPage.Models;

namespace SeleniumTestsDemoQaPage.Pages.SortablePage
{
    public partial class SortablePage : BasePage
    {
        public string tabNo;
        private int element1VerticalPosition;
        private int element2VerticalPosition;
        private object sortablePage;
        public int item1PositionAfter;
        public int item2PositionAfter;

        public SortablePage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return base.url + "sortable/#tabs-" + tabNo;
            }
        }

        public int Element1Position { get { return this.element1VerticalPosition; } }
        public int Element2Position { get { return this.element2VerticalPosition; } }

        public void DragSortableElement(IWebDriver driver, IWebElement element1, IWebElement element2)
        {
            /* This doesn't do the job to scroll to top of the page, at least in Firefox:
              Actions actions = new Actions(this.Driver);
              actions.MoveToElement(draggableElement);
              actions.Perform();
              */
            Actions builder = new Actions(this.Driver);
            var dragUp = builder.DragAndDropToOffset(element2, 0, -((element2.Location.Y - element1.Location.Y) + 1));
            dragUp.Perform();
            this.element1VerticalPosition = element1.Location.Y;
            this.element2VerticalPosition = element2.Location.Y;
        }

        // Take position number of both element 1 and element 2 after sorting
        public void RecheckSortableElements(string item1, string item2)
        {

            for (int i = 0; i < SortableItemsTab1.Count; i++)
            {
                if (SortableItemsTab1[i].Text.Contains(item1))
                {
                    item1PositionAfter = i;
                }
            }

            for (int i = 0; i < SortableItemsTab1.Count; i++)
            {
                if (SortableItemsTab1[i].Text.Contains(item2))
                {
                    item2PositionAfter = i;
                }
            }
        }

        /* Useful tries to find which element form the list contains specified text
         * public void RecheckSortableElements(IWebDriver driver, IWebElement element1, IWebElement element2)
         {
         var itemNowOnTop = SortableItemsTab1.FirstOrDefault(stringToCheck => stringToCheck.Text.Contains(element1.Text));
         // SortableItemsTab1.Contains
         }

        var itemNowOnTop = SortableItemsTab1.FirstOrDefault(stringToCheck => stringToCheck.Text.Contains(item1));
        //SortableItemsTab1.Contains
        var listItemNowOnTop = SortableItemsTab1.Where(stringToCheck => stringToCheck.Text.Contains(item1));
        var listItemNowOnBottom = SortableItemsTab1.Where(stringToCheck => stringToCheck.Text.Contains(item2));
        */

        public void DragAndDropSortableElement(IWebDriver driver, IWebElement element, IWebElement target)
        {
            Actions builder = new Actions(this.Driver);
            var dragAndDrop = builder.DragAndDrop(element, target);
            dragAndDrop.Perform();
        }

        public void DragAndDropSortableAfterElement(IWebDriver driver, IWebElement element1, IWebElement element2)
        {
            int offsetX = (element2.Location.X - element1.Location.X) + 5;
            int offsetY = (element2.Location.Y - element1.Location.Y) + 5;
            Actions builder = new Actions(this.Driver);
            var dragAndDrop = builder.DragAndDropToOffset(element1, offsetX, offsetY);
            dragAndDrop.Perform();
        }
    }
}

