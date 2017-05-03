using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumTestsDemoQaPage.Models;

namespace SeleniumTestsDemoQaPage.Pages.SelectablePage
{
    public partial class SelectablePage : BasePage
    {
        public string tabNo;

        public SelectablePage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        {
            get
            {
                return base.url + "selectable/#tabs-" + tabNo;
            }
        }

       public void SelectSelectableElements(IWebDriver driver, IWebElement element1, IWebElement element2)
        {
            Actions builder = new Actions(driver);
            var action = builder.MoveToElement(element1).Click();
            action.Perform();
            builder.KeyDown(Keys.Control);
            var action2 = builder.MoveToElement(element2).Click();
            action2.Perform();
        }

        public void SelectSelectableElementsByDrag(IWebDriver driver, IWebElement firstItem, IWebElement lastItem)
        {
            Actions builder = new Actions(driver);
            var action = builder.ClickAndHold(firstItem).Release(lastItem);
            action.Perform();
        }

        public void SelectSelectableElement(IWebDriver driver, IWebElement element1)
        {
            Actions builder = new Actions(driver);
            var action = builder.MoveToElement(element1).Click();
            action.Perform();
        }
    }
}
