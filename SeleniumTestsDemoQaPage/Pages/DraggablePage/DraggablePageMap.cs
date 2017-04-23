using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestsDemoQaPage.Pages.DraggablePage
{
    public partial class DraggablePage
    {
        public IWebElement DraggableElement
        {
            get
            {
                return this.Driver.FindElement(By.Id("draggable"));
            }
        }

        /* I thought to use this Container element's size and drag the Draggable in some relation to that size. But maybe next time
        public IWebElement ContainerElement
        {
            get
            {
                return this.Driver.FindElement(By.Id("tabs-1"));
            }
        }
        */

        public IWebElement TopOfPage
        {
            get
            {
                return this.Driver.FindElement(By.TagName("h1"));
            }
        }

        public IWebElement DraggableElementConstraint
        {
            get
            {
                return this.Driver.FindElement(By.Id("draggabl2"));
            }
        }

        public IWebElement DraggableElementCursor1
        {
            get
            {
                return this.Driver.FindElement(By.Id("drag"));
            }
        }

        public IWebElement DraggableElementCursor2
        {
            get
            {
                return this.Driver.FindElement(By.Id("drag2"));
            }
        }

        public IWebElement DraggableElementCursor3
        {
            get
            {
                return this.Driver.FindElement(By.Id("drag3"));
            }
        }

        public IWebElement DraggableElementCounters
        {
            get
            {
                return this.Driver.FindElement(By.Id("dragevent"));
            }
        }

        public IWebElement DraggableElementDragCounterStart
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id='event-start']/span[2]"));
            }
        }

        public IWebElement DraggableElementDragCounterStop
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id='event-stop']/span[2]"));
            }
        }

        public IWebElement DraggableSortableElement2
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id='sortablebox']/li[2]"));
            }
        }

        public IWebElement DraggableSortableElement5
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id='sortablebox']/li[5]"));
            }
        }
    }
}
