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
        // private IWebElement draggableElement;

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
        //   public IWebElement DraggableElement { get { return this.draggableElement; } }


        public void DragObject(int horizontalOffset, int verticalOffset, IWebElement draggableElement)
        {
            /* This doesn't do the job to scroll to top of the page:
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
    }
}
