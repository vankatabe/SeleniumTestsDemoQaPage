using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestsDemoQaPage.Pages.HomePage
{
    public partial class HomePage : BasePage///
    {
        private String url = "http://demoqa.com/";
       /// private IWebDriver driver;

        public HomePage (IWebDriver driver)
            : base(driver)
        {
         ///   this.driver = driver;
        }

        

        public int Asserter { get; set; }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.url);
        }
    }
}
