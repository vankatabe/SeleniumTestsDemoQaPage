using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestsDemoQaPage.Pages.ToolsQaHomePage
{
    public partial class ToolsQaHomePage
    {
        public IWebElement Logo
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id='page']/div/header/div/a/img"));
            }
        }
    }
}
