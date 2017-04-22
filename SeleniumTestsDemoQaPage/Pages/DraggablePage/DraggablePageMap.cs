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

        public IWebElement ContainerElement
        {
            get
            {
                return this.Driver.FindElement(By.Id("tabs-1"));
            }
        }
    }
}
