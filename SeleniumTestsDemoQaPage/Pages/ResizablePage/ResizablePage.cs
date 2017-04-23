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
        public string tabNo;
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
                return base.url + "resizable/#tabs-" + tabNo;
            }
        }

        // Used by the exercise from the lecture
        public void IncreaseWidthAndHeightBy(int increase)
        {
            this.width = this.resizeWindow.Size.Width;
            this.height = this.resizeWindow.Size.Height;
            Actions builder = new Actions(this.Driver);
            var resize = builder.DragAndDropToOffset(this.resizeButton, increase, increase);
            resize.Perform();
        }

        // Used by the exercise from the lecture
        public void IncreaseWidthBy(int increase)
        {
            this.width = this.resizeWindow.Size.Width;
            Actions builder = new Actions(this.Driver);
            var resize = builder.DragAndDropToOffset(this.resizeSide, increase, 0);
            resize.Perform();
        }

        public void IncreaseWidthAndHeightBy2(int increaseX, int increaseY)
        {
            this.width = this.resizeWindow.Size.Width;
            this.height = this.resizeWindow.Size.Height;
            Actions builder = new Actions(this.Driver);
            var resize = builder.DragAndDropToOffset(this.resizeButton, increaseX, increaseY);
            resize.Perform();
        }

        public void IncreaseWidthAndHeight()
        {
            this.width = this.containerElementTab3.Size.Width;
            this.height = this.containerElementTab3.Size.Height;
            Actions builder = new Actions(this.Driver);
            var resize = builder.DragAndDropToOffset(this.resizeButtonTab3, width, height);
            resize.Perform();
        }

        public void IncreaseWidthAndHeightBy3(int increaseX, int increaseY)
        {
            this.width = this.resizeWindow.Size.Width;
            this.height = this.resizeWindow.Size.Height;
            Actions builder = new Actions(this.Driver);
            var resize = builder.DragAndDropToOffset(this.resizeButtonTab5, increaseX, increaseY);
            resize.Perform();
        }
    }
}
