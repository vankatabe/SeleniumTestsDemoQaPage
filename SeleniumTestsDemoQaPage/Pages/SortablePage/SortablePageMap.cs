using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestsDemoQaPage.Pages.SortablePage
{
    public partial class SortablePage
    {
        public List<IWebElement> SortableItemsTab1
        {
            get
            {
                return this.Driver.FindElements(By.XPath("//*[contains(text(), 'Item')]")).ToList();
            }
        }
    }
}
