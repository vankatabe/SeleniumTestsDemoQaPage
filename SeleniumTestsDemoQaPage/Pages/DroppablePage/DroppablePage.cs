
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumTestsDemoQaPage.Pages.DroppablePage
{

    public partial class DroppablePage : BasePage
    {
        public DroppablePage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return base.url + "droppable/";
            }
        }

        public void DragAndDrop()
        {
            // this.NavigateTo(URL); - just to try if it would work from here. The real NavigateTo() is in the Test
            Actions builder = new Actions(this.Driver);
            var drag = builder.DragAndDrop(this.DroppableElement, this.TargetElement);
            drag.Perform();
        }
    }
}
