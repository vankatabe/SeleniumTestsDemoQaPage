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


        public void DragObject(int horizontalOffset, int verticalOffset)
        {
            this.horizontalPosition = this.DraggableElement.Location.X;
            this.verticalPosition = this.DraggableElement.Location.Y;
            Actions builder = new Actions(this.Driver);
            var drag = builder.DragAndDropToOffset(this.DraggableElement, horizontalOffset, verticalOffset);
            drag.Perform();
        }
    }
}
