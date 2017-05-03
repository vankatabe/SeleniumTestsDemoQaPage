using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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

            //  driver.Quit(); // causes Firefox to crash
        }

        [Test]
        [Property("Selectable", 1), Property("Selectable test tab Number:", 1)] // Default functionality = tab no 1
        [Description("Default functionality: Select two non-adjacent elements, expected: elements status changed to 'Selected'")]
        [Author("vankatabe")]
        public void SelectableItems_SelectTwoNonAdjacent_SelectedElementsStatusChangedToSelected()
        {
            var selectablePage = new SelectablePage(this.driver);
            // Get the current test method name (TestContext.CurrentContext.Test.Name = SelectableItems_SelectTwoNonAdjacent_SelectedElementsStatusChangedToSelected) and use it as a Key in the xlsx file
            InteractionPages select = AccessExcelData.GetInteractionTestsData(TestContext.CurrentContext.Test.Name);
            // Get the tab number (e.g. "Default functionality", Constrain movement") from the test property above and give it to the URL
            selectablePage.tabNo = TestContext.CurrentContext.Test.Properties.Get("Selectable test tab Number:").ToString();
            selectablePage.NavigateTo(selectablePage.URL);
            // Scroll page Up so the element is into view. Because when Firefox opens the desired page/tab, somehow the page is scrolled down
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", selectablePage.TopOfPage);

            selectablePage.SelectSelectableElements(this.driver, selectablePage.SelectableItems[int.Parse(select.Item1)], selectablePage.SelectableItems[int.Parse(select.Item2)]);

            selectablePage.AssertSelectedAttribute("ui-widget-content ui-corner-left ui-selectee ui-selected", selectablePage.SelectableItems[int.Parse(select.Item1)]);
            selectablePage.AssertSelectedAttribute("ui-widget-content ui-corner-left ui-selectee ui-selected", selectablePage.SelectableItems[int.Parse(select.Item2)]);
        }

        [Test]
        [Property("Selectable", 2), Property("Selectable test tab Number:", 2)] // Display as grid = tab no 2
        [Description("Display as grid: Select all elements by muose click and drag, expected: elements status changed to 'Selected'")]
        [Author("vankatabe")]
        public void SelectableItems_SelectAllByMouseDrag_SelectedElementsStatusChangedToSelected()
        {
            var selectablePage = new SelectablePage(this.driver);
            // Get the tab number (e.g. "Default functionality", Constrain movement") from the test property above and give it to the URL
            selectablePage.tabNo = TestContext.CurrentContext.Test.Properties.Get("Selectable test tab Number:").ToString();
            selectablePage.NavigateTo(selectablePage.URL);
            // Scroll page Up so the element is into view. Because when Firefox opens the desired page/tab, somehow the page is scrolled down
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", selectablePage.TopOfPage);

            selectablePage.SelectSelectableElementsByDrag(this.driver, selectablePage.SelectableItemsTab2[0], selectablePage.SelectableItemsTab2[selectablePage.SelectableItemsTab2.Count - 1]);

            for (int i = 0; i < selectablePage.SelectableItemsTab2.Count; i++)
            {
                selectablePage.AssertSelectedAttributes("ui-state-default ui-corner-left ui-selectee ui-selected", selectablePage.SelectableItemsTab2[i]);
            }
        }

        [Test]
        [Property("Selectable", 3), Property("Selectable test tab Number:", 3)] // Serialize = tab no 3
        [Description("Serialize: Select selectable item, expected: item number is displayed correctly")]
        [Author("vankatabe")]
        public void SelectableItems_SelectItem_SelectedItemNumberIsDisplayed()
        {
            var selectablePage = new SelectablePage(this.driver);
            // Get the current test method name (TestContext.CurrentContext.Test.Name = SelectableItems_SelectTwoNonAdjacent_SelectedElementsStatusChangedToSelected) and use it as a Key in the xlsx file
            InteractionPages select = AccessExcelData.GetInteractionTestsData(TestContext.CurrentContext.Test.Name);
            // Get the tab number (e.g. "Default functionality", Constrain movement") from the test property above and give it to the URL
            selectablePage.tabNo = TestContext.CurrentContext.Test.Properties.Get("Selectable test tab Number:").ToString();
            selectablePage.NavigateTo(selectablePage.URL);
            // Scroll page Up so the element is into view. Because when Firefox opens the desired page/tab, somehow the page is scrolled down
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", selectablePage.TopOfPage);

            selectablePage.SelectSelectableElement(this.driver, selectablePage.SelectableItemsTab3[int.Parse(select.Item1)-1]);

            selectablePage.AssertSelectedAttribute("ui-widget-content ui-corner-left ui-selectee ui-selected", selectablePage.SelectableItemsTab3[int.Parse(select.Item1)-1]);
            selectablePage.AssertSelectedElementNumberIsDisplayed("4", selectablePage.SelectedElementDisplay);
        }
    }
}
