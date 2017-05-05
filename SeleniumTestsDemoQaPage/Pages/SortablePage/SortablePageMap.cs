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
        public int SortableItemsColumn1CountBefore;
        public int SortableItemsColumn2CountBefore;


        public List<IWebElement> SortableItemsTab1
        {
            get
            {
                return this.Driver.FindElements(By.XPath("//*[contains(text(), 'Item')]")).ToList();
            }
        }

        public IWebElement SortableColumn1
        {
            get
            {
                return this.Driver.FindElement(By.Id("sortable1"));
            }
        }

        public IWebElement SortableColumn2
        {
            get
            {
                return this.Driver.FindElement(By.Id("sortable2"));
            }
        }

        // Get all Items from column 1 in a list
        public List<IWebElement> SortableItemsColumn1
        {
            get
            {
                return this.Driver.FindElements(By.XPath("//*[@id='sortable1']/li")).ToList();
            }
            set
            { SortableItemsColumn1CountBefore = SortableItemsColumn1.Count; }
        }
        //child::text()  //book[title/@lang = 'it']   //ul[@id='sortable1']/li[4] child::text()  /bookstore/book/price[text()] 

        // Get all Items from column 2 in a list
        public List<IWebElement> SortableItemsColumn2
        {
            get
            {
                return this.Driver.FindElements(By.XPath("//*[@id='sortable2']/li")).ToList();
            }
            set
            { SortableItemsColumn2CountBefore = SortableItemsColumn2.Count; }
        }
    }
}
