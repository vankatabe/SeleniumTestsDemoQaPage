using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestsDemoQaPage.Pages.ResizablePage
{
    public partial class ResizablePage
    {
        public IWebElement resizeButton
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id='resizable']/div[3]"));
            }
        }

        public IWebElement resizeSide
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id='resizable']/div"));
            }
        }

        public IWebElement resizeWindow
        {
            get
            {
                return this.Driver.FindElement(By.Id("resizable"));
            }
        }

        public IWebElement resizableElementTab3
        {
            get
            {
                return this.Driver.FindElement(By.Id("resizableconstrain"));
            }
        }

        public IWebElement containerElementTab3
        {
            get
            {
                return this.Driver.FindElement(By.Id("container1"));
            }
        }

        public IWebElement resizeButtonTab3
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id='resizableconstrain']/div[3]"));
            }
        }

        public IWebElement resizeButtonTab5
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id='resizable_max_min']/div[3]"));
            }
        }

        public IWebElement resizableElementTab5
        {
            get
            {
                return this.Driver.FindElement(By.Id("resizable_max_min"));
            }
        }
    }
}