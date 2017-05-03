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

       public void FindAndSelectSelectableElements(IWebDriver driver, IWebElement element1, IWebElement element2)
        {
            Actions builder = new Actions(driver);
            var action = builder.MoveToElement(element1).Click();
            action.Perform();
            builder.KeyDown(Keys.Control);
            var action2 = builder.MoveToElement(element2).Click();
            action2.Perform();
        }

        public string SelectedAttribute(string elementNumber)
        {
            IWebElement element = this.Driver.FindElement(By.XPath(($"//*[contains(text(), '{elementNumber}')]")));
            return element.GetAttribute("class");
        }
    }
}
