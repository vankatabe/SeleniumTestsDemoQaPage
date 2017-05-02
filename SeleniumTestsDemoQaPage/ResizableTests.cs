using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SeleniumTestsDemoQaPage.Models;
using SeleniumTestsDemoQaPage.Pages.AutomationPracticePage;
using SeleniumTestsDemoQaPage.Pages.DraggablePage;
using SeleniumTestsDemoQaPage.Pages.DroppablePage;
using SeleniumTestsDemoQaPage.Pages.ResizablePage;
using SeleniumTestsDemoQaPage.Pages.ToolsQaHomePage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTestsDemoQaPage
{
    [TestFixture]
    public class ResizableTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = new ChromeDriver();
        }

        [TearDown]
        public void CleanUp()
        {
            // Add logger for failed tests
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string filenameTxt = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", string.Empty) + ConfigurationManager.AppSettings["Logs"] + TestContext.CurrentContext.Test.Name + ".txt";
                if (File.Exists(filenameTxt))
                {
                    File.Delete(filenameTxt);
                }
                File.WriteAllText(filenameTxt,
                    "Test full name:\t" + TestContext.CurrentContext.Test.FullName + "\r\n\r\n"
                    + "Work directory:\t" + TestContext.CurrentContext.WorkDirectory + "\r\n\r\n"
                    + "Pass count:\t" + TestContext.CurrentContext.Result.PassCount + "\r\n\r\n"
                    + "Result:\t" + TestContext.CurrentContext.Result.Outcome.ToString() + "\r\n\r\n"
                    + "Message:\t" + TestContext.CurrentContext.Result.Message);

                var screenshot = ((ITakesScreenshot)this.driver).GetScreenshot();
                var filenameJpg = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", string.Empty) + ConfigurationManager.AppSettings["Logs"] + TestContext.CurrentContext.Test.Name + ".jpg";
                screenshot.SaveAsFile(filenameJpg, ScreenshotImageFormat.Jpeg);
            }

            driver.Quit(); // causes Firefox to crash
        }

        [Test]
        [Property("Resizable", 1), Property("Resizable test tab Number:", 1)] // Default functionality = tab no 1
        [Description("Default functionality: Resize resizable item with H and W with some positive pixels each, expected: item is resized properly")]
        [Author("vankatabe")]
        public void ResizableItem_ResizeSides_ItemSidesResizedProperly()
        {
            var resizablePage = new ResizablePage(this.driver);
            // Get the current test method name (TestContext.CurrentContext.Test.Name = ResizableItem_ResizeSides_ItemSidesResizedProperly) and use it as a Key in the xlsx file
            InteractionPages resize = AccessExcelData.GetInteractionTestsData(TestContext.CurrentContext.Test.Name);
            // Get the tab number (e.g. "Default functionality", Constrain movement") from the test property above and give it to the URL
            resizablePage.tabNo = TestContext.CurrentContext.Test.Properties.Get("Resizable test tab Number:").ToString();
            resizablePage.NavigateTo(resizablePage.URL);
            // Scroll page Up so the element is into view. Because when Firefox opens the desired page/tab, somehow the page is scrolled down
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", resizablePage.TopOfPage);

            resizablePage.IncreaseWidthAndHeightBy2(int.Parse(resize.HorizontalOffset), int.Parse(resize.VerticalOffset));

            // Exact Assert would not pass because the resized item's dimensions are 17 pixels less than logically expected
            // See method AssertSizeIncreasedWith2 for details
            resizablePage.AssertSizeIncreasedWith2(int.Parse(resize.HorizontalOffset), int.Parse(resize.VerticalOffset));
        }

        [Test]
        [Property("Resizable", 2), Property("Resizable test tab Number:", 3)] // Constrain resize area = tab no 3
        [Description("Constrain resize area: Resize resizable item with some positive pixels (more than the dimensions of the Constraint element) each, expected: item resize is constrained by the Constrain Element's dimensions")]
        [Author("vankatabe")]
        public void ResizableConstrainedItem_ResizeSides_ItemResizeConstrainedByContainer()
        {
            var resizablePage = new ResizablePage(this.driver);
            // Get the tab number (e.g. "Default functionality", Constrain movement") from the test property above and give it to the URL
            resizablePage.tabNo = TestContext.CurrentContext.Test.Properties.Get("Resizable test tab Number:").ToString();
            resizablePage.NavigateTo(resizablePage.URL);
            // Scroll page Up so the element is into view. Because when Firefox opens the desired page/tab, somehow the page is scrolled down
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", resizablePage.TopOfPage);

            resizablePage.IncreaseWidthAndHeight();

            resizablePage.AssertResizableSizeSmallerThanContainer(resizablePage.resizableElementTab3);
        }

        [Test]
        [Property("Resizable", 3), Property("Resizable test tab Number:", 5)] // Max/Min size = tab no 5
        [Description("Max/Min size: Resize each side of the resizable element with big positive value (more than the value of the resize constraint), expected: item resize cannot be more than the constraints values")]
        [Author("vankatabe")]
        public void ResizableConstrainedItem_ResizeSidesMoreThanConstraints_ItemResizeConstrainedByConstraints()
        {
            var resizablePage = new ResizablePage(this.driver);
            // Get the current test method name and use it as a Key in the xlsx file
            InteractionPages resize = AccessExcelData.GetInteractionTestsData(TestContext.CurrentContext.Test.Name);
            // Get the tab number (e.g. "Default functionality", Constrain movement") from the test property above and give it to the URL
            resizablePage.tabNo = TestContext.CurrentContext.Test.Properties.Get("Resizable test tab Number:").ToString();
            resizablePage.NavigateTo(resizablePage.URL);
            // Scroll page Up so the element is into view. Because when Firefox opens the desired page/tab, somehow the page is scrolled down
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", resizablePage.TopOfPage);

            resizablePage.IncreaseWidthAndHeightBy3(int.Parse(resize.HorizontalOffset), int.Parse(resize.VerticalOffset));

            resizablePage.AssertResizableSizeSmallerThanOrEqualToConstraints(resizablePage.resizableElementTab5, resize);
        }
    }
}
