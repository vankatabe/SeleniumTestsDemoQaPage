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

        public IWebElement DraggableElementConstraint
        {
            get
            {
                return this.Driver.FindElement(By.Id("draggabl2"));
            }
        }
    }
}
