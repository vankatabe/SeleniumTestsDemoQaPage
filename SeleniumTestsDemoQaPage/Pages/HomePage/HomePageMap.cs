using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestsDemoQaPage.Pages.HomePage
{
    public partial class HomePage
    {
        [FindsBy(How = How.ClassName, Using = "entry-title")]
        public IWebElement Heading { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='menu-item-374']")]
        public IWebElement registrationButton { get; set; }
    }
}
