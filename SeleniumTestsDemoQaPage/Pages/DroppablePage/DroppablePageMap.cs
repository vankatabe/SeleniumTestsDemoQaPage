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
        public IWebElement DroppableElement
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id='draggableview']/p"));
            }
        }

        public IWebElement TargetElement
        {
            get
            {
                return this.Driver.FindElement(By.Id("droppableview"));
            }
        }
    }
}
