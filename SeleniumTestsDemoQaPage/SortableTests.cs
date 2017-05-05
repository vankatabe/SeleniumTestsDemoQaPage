using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumTestsDemoQaPage.Models;
using SeleniumTestsDemoQaPage.Pages.SortablePage;
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
    public class SortableTests
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
                string filenameTxt = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", string.Empty) + ConfigurationManager.AppSettings["Logs"] + TestContext.CurrentContext.Test.Name + ".txt";
                // Or, if you srart the project not from Recents but from its .sln file, you can use: Environment.CurrentDirectory - returns project root directory :)

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
        [Property("Sortable", 1), Property("Sortable test tab Number:", 1)] // Default functionality = tab no 1
        [Description("Default functionality: Drag the last sortable element to the top of the list, expected: last item is at the top of the list")]
        [Author("vankatabe")]
        public void DefaultFunctionality_DragLastItemToListTop_LastItemIsAtListTop()
        {
            var sortablePage = new SortablePage(this.driver);
            // Get the current test method name and use it as a Key in the xlsx file
            InteractionPages sort = AccessExcelData.GetInteractionTestsData(TestContext.CurrentContext.Test.Name);
            // Get the tab number (e.g. "Default functionality", Constrain movement") from the Test Property above and give it to the URL
            sortablePage.tabNo = TestContext.CurrentContext.Test.Properties.Get("Sortable test tab Number:").ToString();
            sortablePage.NavigateTo(sortablePage.URL);
            // Scroll page Up so the element is into view. Because when Firefox opens the desired page/tab, somehow the page is scrolled down
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", sortablePage.TopOfPage);

            // Drag Sortable Item 2 to position before Sortable Item 1
            sortablePage.DragSortableElement(this.driver, sortablePage.SortableItemsTab1[int.Parse(sort.Item1)], sortablePage.SortableItemsTab1[int.Parse(sort.Item2)]);
            // Get the elements' positions after sorting - used for the "Another way to assert it"
            sortablePage.RecheckSortableElements(sort.Item1, sort.Item2);

            sortablePage.ElementSortedOrder(sortablePage.Element2Position, sortablePage.Element1Position);
            // Another way to assert it:
            sortablePage.ElementSortedOrderAnotherWayOfAssert(sortablePage.item2PositionAfter, sortablePage.item1PositionAfter);
        }

        [Test]
        [Property("Sortable", 2), Property("Sortable test tab Number:", 2)] // Connect Lists = tab no 2
        [Description("Connect Lists: Drag one sortable element from first list to second list, expected: number of sortable elements in columns changed accordingly")]
        [Author("vankatabe")]
        public void ConnectLists_DragOneSortableItemFromFirstListToSecondList_NumberOfItemsChangedAccordingly()
        {
            var sortablePage = new SortablePage(this.driver);
            // Get the current test method name and use it as a Key in the xlsx file
            InteractionPages sort = AccessExcelData.GetInteractionTestsData(TestContext.CurrentContext.Test.Name);
            // Get the webpage tab number (e.g. "Default functionality", Connect Lists") from the Test Property above and give it to the URL
            sortablePage.tabNo = TestContext.CurrentContext.Test.Properties.Get("Sortable test tab Number:").ToString();
            sortablePage.NavigateTo(sortablePage.URL);
            // Scroll page Up so the element is into view. Because when Firefox opens the desired page/tab, somehow the page is scrolled down
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", sortablePage.TopOfPage);
            // Get the initial number of elements in each column
            var SortableItemsColumn1CountBefore = sortablePage.SortableItemsColumn1.Count;
            var SortableItemsColumn2CountBefore = sortablePage.SortableItemsColumn2.Count;

            // Drag desired (given in xlsx file) Sortable Item from column 1 to column 2
            sortablePage.DragAndDropSortableElement(this.driver, sortablePage.SortableItemsColumn1[int.Parse(sort.Item1)-1], sortablePage.SortableColumn2);

            sortablePage.Column1ElementCountDecreased(this.driver, sortablePage.SortableItemsColumn1, SortableItemsColumn1CountBefore);
            sortablePage.Column2ElementCountIncreased(this.driver, sortablePage.SortableItemsColumn2, SortableItemsColumn2CountBefore);
        }

        [Test]
        [Property("Sortable", 3), Property("Sortable test tab Number:", 3)] // Display as grid = tab no 3
        [Description("Display as grid: Drag one sortable element to a position after another element, expected: order of numbered sortable elements changed accordingly")]
        [Author("vankatabe")]
        public void Grid_DragOneSortableItemAfterAnother_OrderOfNumberedSortableItemsChangedAccordingly()
        {
            var sortablePage = new SortablePage(this.driver);
            // Get the current test method name and use it as a Key in the xlsx file
            InteractionPages sort = AccessExcelData.GetInteractionTestsData(TestContext.CurrentContext.Test.Name);
            // Get the webpage tab number (e.g. "Default functionality", Connect Lists") from the Test Property above and give it to the URL
            sortablePage.tabNo = TestContext.CurrentContext.Test.Properties.Get("Sortable test tab Number:").ToString();
            sortablePage.NavigateTo(sortablePage.URL);
            // Scroll page Up so the element is into view. Because when Firefox opens the desired page/tab, somehow the page is scrolled down
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", sortablePage.TopOfPage);

            // Drag desired (given in xlsx file) Sortable Item 1 after given Sortable Item 2
        //    sortablePage.DragAndDropSortableElement(this.driver, sortablePage.SortableItemsColumn1[int.Parse(sort.Item1) - 1], sortablePage.SortableColumn2);
        //
        //    sortablePage.Column1ElementCountDecreased(this.driver, sortablePage.SortableItemsColumn1, sortablePage.SortableItemsColumn1CountBefore);
        //    sortablePage.Column2ElementCountIncreased(this.driver, sortablePage.SortableItemsColumn2, sortablePage.SortableItemsColumn2CountBefore);
        }
    }
}
