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

        public void FindAndSelectSelectableElement(string elementName) // Find selectable element by containing name string
        {
            IWebElement element = this.Driver.FindElement(By.XPath(($"//*[contains(text(), '{elementName}')]")));
            Actions builder = new Actions(this.Driver);
            builder.KeyDown(Keys.Control).Perform();
            var select = builder.MoveToElement(element).Click();
            select.Perform();
            builder.KeyUp(Keys.Control).Perform();
            //SelectSelectableElement(element);
        }

        public void SelectSelectableElement(IWebElement element)
        {
            Actions builder = new Actions(this.Driver);
            builder.KeyDown(Keys.Control).Perform();
            var select = builder.MoveToElement(element).Click();
            select.Perform();
            builder.KeyUp(Keys.Control).Perform();
        }

        public void FindAndSelectSelectableElement4(InteractionPages select, IWebDriver driver)
        {
            IWebElement element1 = this.Driver.FindElement(By.XPath(($"//*[contains(text(), '{select.ItemCat1}')]")));
            IWebElement element2 = this.Driver.FindElement(By.XPath(($"//*[contains(text(), '{select.ItemCat2}')]")));
            Actions builder = new Actions(driver);
            var action = builder.MoveToElement(element1).Click();
            action.Perform();
            builder.KeyDown(Keys.Control);
            var action2 = builder.MoveToElement(element2).Click();
            action2.Perform();
        }
        public void FindAndSelectSelectableElement3(InteractionPages select)
        {
            IWebElement element1 = this.Driver.FindElement(By.XPath(($"//*[contains(text(), '{select.ItemCat1}')]")));
            IWebElement element2 = this.Driver.FindElement(By.XPath(($"//*[contains(text(), '{select.ItemCat2}')]")));
            Actions builder = new Actions(this.Driver);
            var action1 = builder.KeyDown(Keys.LeftControl);
            action1.Perform();

            var action = builder.MoveToElement(element1).Click();
            action.Perform();

            var action2 = builder.MoveToElement(element2).Click();
            action2.Perform();
        }
        public void FindAndSelectSelectableElement2(InteractionPages select)
        {
            Actions builder = new Actions(this.Driver);
            // builder.KeyDown(Keys.Control).Perform();


            IWebElement element = this.Driver.FindElement(By.XPath(($"//*[contains(text(), '{select.ItemCat1}')]")));
            // element.Click();
            //selector.Perform();

            IWebElement element2 = this.Driver.FindElement(By.XPath(($"//*[contains(text(), '{select.ItemCat2}')]")));
            //builder2.KeyDown(Keys.Control).Perform();
            Actions builder2 = new Actions(this.Driver);
            builder2.MoveToElement(element).Click().MoveToElement(element2).KeyDown(Keys.LeftControl).Click().KeyUp(Keys.LeftControl).Perform();
            //selector2.Perform();
            //builder.KeyUp(Keys.Control).Perform();
            //SelectSelectableElement(element);
        }

        // actionsBuilder.KeyDown(Keys.Control).Click(element).KeyUp(Keys.Control).Perform();
    }
}
