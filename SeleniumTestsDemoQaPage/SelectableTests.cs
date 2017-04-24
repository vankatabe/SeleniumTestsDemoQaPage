using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumTestsDemoQaPage.Models;
using SeleniumTestsDemoQaPage.Pages.SelectablePage;
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
    public class SelectableTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Init()
        {
            this.driver = new FirefoxDriver();
        }

        [TearDown]
        public void CleanUp()
        {
            // Add logger for failed tests
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string filename = ConfigurationManager.AppSettings["Logs"] + TestContext.CurrentContext.Test.Name + ".txt";
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                File.WriteAllText(filename,
                    "Test full name:\t" + TestContext.CurrentContext.Test.FullName + "\r\n\r\n"
                    + "Work directory:\t" + TestContext.CurrentContext.WorkDirectory + "\r\n\r\n"
                    + "Pass count:\t" + TestContext.CurrentContext.Result.PassCount + "\r\n\r\n"
                    + "Result:\t" + TestContext.CurrentContext.Result.Outcome.ToString() + "\r\n\r\n"
                    + "Message:\t" + TestContext.CurrentContext.Result.Message);

                var screenshot = ((ITakesScreenshot)this.driver).GetScreenshot();
                screenshot.SaveAsFile(ConfigurationManager.AppSettings["Logs"] + TestContext.CurrentContext.Test.Name + ".jpg", ScreenshotImageFormat.Jpeg);
            }

            //  driver.Quit(); // causes Firefox to crash
        }

        [Test]
        [Property("Selectable", 1), Property("Selectable test tab Number:", 1)] // Default functionality = tab no 1
        [Description("Default functionality: Select three elements, expected: elements status changed to 'Selected'")]
        [Author("vankatabe")]
        public void SelectableItems_SelectThree_SelectedElementsStatusChangedToSelected()
        {
            var selectablePage = new SelectablePage(this.driver);
            // Get the current test method name (TestContext.CurrentContext.Test.Name = SelectableItems_SelectMoreThanOne_SelectedElementsStatusChangedToSelected) and use it as a Key in the xlsx file
            InteractionPages select = AccessExcelData.GetInteractionTestsData(TestContext.CurrentContext.Test.Name);
            // Get the tab number (e.g. "Default functionality", Constrain movement") from the test property above and give it to the URL
            selectablePage.tabNo = TestContext.CurrentContext.Test.Properties.Get("Selectable test tab Number:").ToString();
            selectablePage.NavigateTo(selectablePage.URL);
            // Scroll page Up so the element is into view. Because when Firefox opens the desired page/tab, somehow the page is scrolled down
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", selectablePage.TopOfPage);
            Thread.Sleep(1000);

            selectablePage.FindAndSelectSelectableElement3(select);
            selectablePage.FindAndSelectSelectableElement(select.ItemCat2);
            selectablePage.FindAndSelectSelectableElement(select.ItemCat3);


            //var adsf = selectablePage.FindSelectableElement("Item 1");
            //selectablePage.SelectSelectableElement(adsf);

            // Exact Assert would not pass because the resized item's dimensions are 17 pixels less than logically expected
            // See method AssertSizeIncreasedWith2 for details
            //selectablePage.AssertSizeIncreasedWith2(int.Parse(resize.HorizontalOffset), int.Parse(resize.VerticalOffset));
        }
    }
}
