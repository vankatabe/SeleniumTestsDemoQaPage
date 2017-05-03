using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestsDemoQaPage.Pages.SelectablePage
{
    public partial class SelectablePage
    {
        public List<IWebElement> SelectableItems
        {
            get
            {
                return this.Driver.FindElements(By.XPath("//*[contains(text(), 'Item')]")).ToList();
            }
        }
    }
}