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

        public List<IWebElement> SelectableItemsTab2
        {
            get
            {
                return this.Driver.FindElements(By.XPath("//*[@id='selectable_grid']/li")).ToList();
            }
        }

        public List<IWebElement> SelectableItemsTab3
        {
            get
            {
                return this.Driver.FindElements(By.XPath("//*[@id='selectable-serialize']/li")).ToList();
            }
        }


        public IWebElement SelectedElementDisplay
        {
            get
            {
                return this.Driver.FindElement(By.Id("select-result"));
            }
        }
    }
}