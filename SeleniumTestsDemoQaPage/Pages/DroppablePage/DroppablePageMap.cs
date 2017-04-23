using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestsDemoQaPage.Pages.DroppablePage
{
    public partial class DroppablePage
    {
        /* Sent to Base page:
        public IWebElement TopOfPage
        {
            get
            {
                return this.Driver.FindElement(By.TagName("h1"));
            }
        }
        */

        public IWebElement DroppableElement
        {
            get
            {
                return this.Driver.FindElement(By.Id("draggableview"));
            }
        }

        public IWebElement TargetElement
        {
            get
            {
                return this.Driver.FindElement(By.Id("droppableview"));
            }
        }

        public IWebElement NonDroppableElementTab2
        {
            get
            {
                return this.Driver.FindElement(By.Id("draggable-nonvalid"));
            }
        }

        public IWebElement TargetElementTab2
        {
            get
            {
                return this.Driver.FindElement(By.Id("droppableaccept"));
            }
        }

        public IWebElement DroppableElementTab3
        {
            get
            {
                return this.Driver.FindElement(By.Id("draggableprop"));
            }
        }

        public IWebElement TargetElementInnerNonGreedyTab3
        {
            get
            {
                return this.Driver.FindElement(By.Id("droppable-inner"));
            }
        }

        public IWebElement TargetElementOuterNonGreedyTab3
        {
            get
            {
                return this.Driver.FindElement(By.Id("droppableprop"));
            }
        }

        public IWebElement DroppableRevertableElementTab4
        {
            get
            {
                return this.Driver.FindElement(By.Id("draggablerevert"));
            }
        }

        public IWebElement TargetElementTab4
        {
            get
            {
                return this.Driver.FindElement(By.Id("droppablerevert"));
            }
        }

        // Where to drop elements. If we leave the path only to 'ol' without 'li', then the element are being dropped too much to the left of the screen and they don't get dropped into the target
        public IWebElement TargetElementTab5
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id='cart']/div/ol/li"));
            }
        }

        // Where to search for dropped elements
        public IWebElement TargetElementContainerTab5
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id='cart']/div/ol"));
            }
        }
    }
}
