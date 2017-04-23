
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Drawing;

namespace SeleniumTestsDemoQaPage.Pages.DroppablePage
{

    public partial class DroppablePage : BasePage
    {
        public string tabNo;
        private Point position;

        public Point Position { get { return this.position; } }


        public DroppablePage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return base.url + "droppable/#tabs-" + tabNo;
            }
        }

        public void DragAndDrop() // Used by the exercises from the lecture
        {
            // this.NavigateTo(URL); - just to try if this row would work from here. The real NavigateTo() is in the Test
            Actions builder = new Actions(this.Driver);
            var drag = builder.DragAndDrop(this.DroppableElement, this.TargetElement);
            drag.Perform();
        }

        public void DragAndDrop2(IWebElement droppableElement, IWebElement targetElement)
        {
            // this.NavigateTo(URL); - just to try if this row would work from here. The real NavigateTo() is in the Test
            Actions builder = new Actions(this.Driver);
            var drag = builder.DragAndDrop(droppableElement, targetElement);
            drag.Perform();
        }

        public void ObjectLocation(IWebElement element)
        {
            this.position = element.Location;
        }

        public IWebElement FindDroppableElement(string elementName) // Find droppable element by string input from Data Driven xslx
        {
            IWebElement element = this.Driver.FindElement(By.XPath(($"//*[contains(text(), '{elementName}')]")));
            return element;
        }

        public void OpenCategory(int categoryNumber) // Clicks on the category so the element from it can be selected with mouse and dragged
        {
            IWebElement category = this.Driver.FindElement(By.XPath($"//h2[{categoryNumber}]/a"));
            category.Click();
        }
    }
}
