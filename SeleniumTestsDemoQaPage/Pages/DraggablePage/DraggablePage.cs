using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumTestsDemoQaPage.Pages.DraggablePage
{
    public partial class DraggablePage : BasePage
    {
        public string tabNo;
        private int horizontalPosition;
        private int verticalPosition;
        private int dragCounterStart;
        private int dragCounterStop;

        public DraggablePage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return base.url + "draggable/#tabs-" + tabNo;
            }
        }

        public int HorizontalPosition { get { return this.horizontalPosition; } }
        public int VerticalPosition { get { return this.verticalPosition; } }

        public void DragObject(int horizontalOffset, int verticalOffset, IWebElement draggableElement)
        {
            /* This doesn't do the job to scroll to top of the page, at least in Firefox:
              Actions actions = new Actions(this.Driver);
              actions.MoveToElement(draggableElement);
              actions.Perform();
              */
            this.horizontalPosition = draggableElement.Location.X;
            this.verticalPosition = draggableElement.Location.Y;
            Actions builder = new Actions(this.Driver);
            var drag = builder.DragAndDropToOffset(draggableElement, horizontalOffset, verticalOffset);
            drag.Perform();
        }

        public int DragCounterStart { get { return this.dragCounterStart; } }
        public int DragCounterStop { get { return this.dragCounterStop; } }

        public void DragCounter()
        {
            this.dragCounterStart = int.Parse(DraggableElementDragCounterStart.Text);
            this.dragCounterStop = int.Parse(DraggableElementDragCounterStop.Text);
        }
    }
}
