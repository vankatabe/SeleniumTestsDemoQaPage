using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumTestsDemoQaPage.Pages.ResizablePage
{
    public partial class ResizablePage : BasePage
    {
        private int width;
        private int height;

        public ResizablePage(IWebDriver driver) : base(driver)
        {
        }

        public int Width { get { return this.width; } }
        public int Height { get { return this.height; } }

        public string URL
        {
            get
            {
                return base.url + "resizable/";
            }
        }

        public void IncreaseWidthAndHeightBy(int increase)
        {
            this.width = this.resizeWindow.Size.Width;
            this.height = this.resizeWindow.Size.Height;
            Actions builder = new Actions(this.Driver);
            var resize = builder.DragAndDropToOffset(this.resizeButton, increase, increase);
            resize.Perform();
        }

    }
}
