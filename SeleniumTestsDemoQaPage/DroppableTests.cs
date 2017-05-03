using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumTestsDemoQaPage.Models;
using SeleniumTestsDemoQaPage.Pages.DroppablePage;
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
    public class DroppableTests
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
        [Property("Droppable", 1), Property("Droppable test tab Number:", 1)] // Default functionality = tab no 1
        [Description("Default functionality: Drag a droppable element and drop it into its target, expected target status is dropped")]
        [Author("vankatabe")]
        public void DefaultFunctionality_DragAndDropToTarget_TargetAttributeChangedToDropped()
        {
            var droppablePage = new DroppablePage(this.driver);
            // Get the tab number (e.g. "Default functionality", "Prevent propagation") from the test property above and give it to the URL
            droppablePage.tabNo = TestContext.CurrentContext.Test.Properties.Get("Droppable test tab Number:").ToString();
            droppablePage.NavigateTo(droppablePage.URL);
            // Scroll page Up so the element is into view. Because when Firefox opens the desired page/tab, somehow the page is scrolled down
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", droppablePage.TopOfPage);

            droppablePage.DragAndDrop2(droppablePage.DroppableElement, droppablePage.TargetElement);

            droppablePage.AssertTargetAttribute2("ui-widget-header ui-droppable ui-state-highlight", droppablePage.TargetElement);
        }

        [Test]
        [Property("Droppable", 2), Property("Droppable test tab Number:", 2)] // Accept = tab no 2
        [Description("Accept: Drag a non-droppable element and drop it into target, expected target status is non-dropped")]
        [Author("vankatabe")]
        public void NonDroppableElement_DragAndDropToTarget_TargetAttributeUnchanged()
        {
            var droppablePage = new DroppablePage(this.driver);
            // Get the tab number (e.g. "Default functionality", "Prevent propagation") from the test property above and give it to the URL
            droppablePage.tabNo = TestContext.CurrentContext.Test.Properties.Get("Droppable test tab Number:").ToString();
            droppablePage.NavigateTo(droppablePage.URL);
            // Scroll page Up so the element is into view. Because when Firefox opens the desired page/tab, somehow the page is scrolled down
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", droppablePage.TopOfPage);

            droppablePage.ObjectLocation(droppablePage.TargetElementTab2); // Initial location of the Target element
            droppablePage.DragAndDrop2(droppablePage.NonDroppableElementTab2, droppablePage.TargetElementTab2);

            // First Assert that the non-droppable element was really moved (and moved on top of the target)
            droppablePage.AssertElementPosition(droppablePage.TargetElementTab2);
            // Then Assert that the Target property has not changed to Dropped
            droppablePage.AssertTargetAttribute2("ui-widget-header ui-droppable", droppablePage.TargetElementTab2);
        }

        [Test]
        [Property("Droppable", 3), Property("Droppable test tab Number:", 3)] // Prevent propagation = tab no 3
        [Description("Prevent propagation: Drag a droppable element and drop it into inner non-greedy target, expected both inner and outer targets status is changed to dropped")]
        [Author("vankatabe")]
        public void DroppableElement_DragAndDropToInnerNonGreedyTarget_BothInnerAndOuterTargetAttributesChangedToDropped()
        {
            var droppablePage = new DroppablePage(this.driver);
            // Get the tab number (e.g. "Default functionality", "Prevent propagation") from the test property above and give it to the URL
            droppablePage.tabNo = TestContext.CurrentContext.Test.Properties.Get("Droppable test tab Number:").ToString();
            droppablePage.NavigateTo(droppablePage.URL);
            // Scroll page Up so the element is into view. Because when Firefox opens the desired page/tab, somehow the page is scrolled down
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", droppablePage.TopOfPage);

            droppablePage.DragAndDrop2(droppablePage.DroppableElementTab3, droppablePage.TargetElementInnerNonGreedyTab3);

            droppablePage.AssertTargetAttribute2("ui-widget-header ui-droppable ui-state-highlight", droppablePage.TargetElementInnerNonGreedyTab3);
            droppablePage.AssertTargetAttribute2("ui-widget-header ui-droppable ui-state-highlight", droppablePage.TargetElementOuterNonGreedyTab3);
        }

        [Test]
        [Property("Droppable", 4), Property("Droppable test tab Number:", 4)] // Revert draggable Position = tab no 4
        [Description("Revert draggable Position: Drag a revertable droppable element and drop it into target, expected element reverted to initial position and target status is changed to dropped")]
        [Author("vankatabe")]
        public void RevertWhenDroppedElement_DragAndDropToTarget_TargetAttributesChangedToDroppedAndElementRevertsToItsPreviousPosition()
        {
            var droppablePage = new DroppablePage(this.driver);
            // Get the tab number (e.g. "Default functionality", "Prevent propagation") from the test property above and give it to the URL
            droppablePage.tabNo = TestContext.CurrentContext.Test.Properties.Get("Droppable test tab Number:").ToString();
            droppablePage.NavigateTo(droppablePage.URL);
            // Scroll page Up so the element is into view. Because when Firefox opens the desired page/tab, somehow the page is scrolled down
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", droppablePage.TopOfPage);

            droppablePage.ObjectLocation(droppablePage.DroppableRevertableElementTab4); // Initial location of the Droppable revertable element
            droppablePage.DragAndDrop2(droppablePage.DroppableRevertableElementTab4, droppablePage.TargetElementTab4);

            // Assert target attribute is changed to Dropped - a proof that the droppale element was moved and was there
            droppablePage.AssertTargetAttribute2("ui-widget-header ui-droppable ui-state-highlight", droppablePage.TargetElementTab4);
            // Assert that Droppable element is now at (reverted to) its starting position
            //Thread.Sleep(1000); - deprecated because I use now a sleeker wait in the AssertElementPosition()
            droppablePage.AssertElementPosition(droppablePage.DroppableRevertableElementTab4);
        }

        [Test]
        [Property("Droppable", 5), Property("Droppable test tab Number:", 5)] // Shopping cart demo = tab no 5
        [Description("Shopping cart demo: Drag one element from each category to Shopping cart, expected that items are added to Shoppng cart")]
        // Similar test with dragging only one element from only First category is far easier :/
        [Author("vankatabe")]
        public void ItemsFromEachCategory_DragAndDropToTargetArea_TargetAreaContainsTheItems()
        {
            var droppablePage = new DroppablePage(this.driver);
            InteractionPages drop = AccessExcelData.GetInteractionTestsData(TestContext.CurrentContext.Test.Name); // Get the current test method name (TestContext.CurrentContext.Test.Name = DefaultFunctionality_DragToOppositeCorner_ElementMovedToOppositeCorner) and use it as a Key in the xlsx file
            // Get the tab number (e.g. "Default functionality", "Prevent propagation") from the test property above and give it to the URL
            droppablePage.tabNo = TestContext.CurrentContext.Test.Properties.Get("Droppable test tab Number:").ToString();
            droppablePage.NavigateTo(droppablePage.URL);
            // Scroll page Up so the element is into view. Because when Firefox opens the desired page/tab, somehow the page is scrolled down
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", droppablePage.TopOfPage);
            // Find by one element from each Category accoeding to Data Driven xlsx


            // Open the respective category, Drag the elements to cart (to Target)
            droppablePage.OpenCategory(1);
            Thread.Sleep(1000);
            droppablePage.DragAndDrop3(drop.Item1, droppablePage.TargetElementTab5);
            droppablePage.OpenCategory(2);
            Thread.Sleep(1000);
            droppablePage.DragAndDrop3(drop.Item2, droppablePage.TargetElementTab5);
            droppablePage.OpenCategory(3);
            Thread.Sleep(1000);
            droppablePage.DragAndDrop3(drop.Item3, droppablePage.TargetElementTab5);
            Thread.Sleep(1000);
            droppablePage.AssertTargetContains(drop.Item1);
            droppablePage.AssertTargetContains(drop.Item2);
            droppablePage.AssertTargetContains(drop.Item3);
        }
    }
}
