using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
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
    public class DraggableTests
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
        [Property("Draggable", 1), Property("Draggable test tab Number:", 1)] // Default functionality = tab no 1
        [Description("Default functionality: Drag a draggable element to the diagonally opposite corner of the containing window, check if element is dragged to the new location")]
        [Author("vankatabe")]
        public void DefaultFunctionality_DragToOppositeCorner_ElementMovedToOppositeCorner()
        {
            var draggablePage = new DraggablePage(this.driver);
            InteractionPages drag = AccessExcelData.GetInteractionTestsData(TestContext.CurrentContext.Test.Name); // Get the current test method name (TestContext.CurrentContext.Test.Name = DefaultFunctionality_DragToOppositeCorner_ElementMovedToOppositeCorner) and use it as a Key in the xlsx file
            // Get the tab number (e.g. "Default functionality", Constrain movement") from the test property above and give it to the URL
            draggablePage.tabNo = TestContext.CurrentContext.Test.Properties.Get("Draggable test tab Number:").ToString();
            draggablePage.NavigateTo(draggablePage.URL);
            // Scroll page Up so the element is into view. Because when Firefox opens the desired page/tab, somehow the page is scrolled down
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", draggablePage.TopOfPage);

            draggablePage.DragObject(int.Parse(drag.HorizontalOffset), int.Parse(drag.VerticalOffset), draggablePage.DraggableElement);

            draggablePage.AssertElementIsMovedCorrectly(int.Parse(drag.HorizontalOffset), int.Parse(drag.VerticalOffset), draggablePage.DraggableElement);
        }

        [Test]
        [Property("Draggable", 2), Property("Draggable test tab Number:", 3)] // Constrain movement = tab no 3
        [Description("Constrain movement: Drag diagonally a horizontally-only-draggable element, check if element position changed only horizontally")]
        [Author("vankatabe")]
        public void ConstrainMovementHorizontal_DragDiagonally_ElementMovedHorizontallyOnly()
        {
            var draggablePage = new DraggablePage(this.driver);
            InteractionPages drag = AccessExcelData.GetInteractionTestsData(TestContext.CurrentContext.Test.Name); // Get the current test method name (TestContext.CurrentContext.Test.Name = ConstrainMovementHorizontal_DragDiagonally_ElementMovedHorizontallyOnly) and use it as a Key in the xlsx file
            // Get the tab number (e.g. "Default functionality", Constrain movement") from the test property above and give it to the URL
            draggablePage.tabNo = TestContext.CurrentContext.Test.Properties.Get("Draggable test tab Number:").ToString();
            draggablePage.NavigateTo(draggablePage.URL);
            // Scroll page Up so the element is into view. Because when Firefox opens the desired page/tab, somehow the page is scrolled down
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", draggablePage.TopOfPage);

            draggablePage.DragObject(int.Parse(drag.HorizontalOffset), int.Parse(drag.VerticalOffset), draggablePage.DraggableElementConstraint);

            draggablePage.AssertElementIsMovedCorrectly(int.Parse(drag.HorizontalOffset), 0, draggablePage.DraggableElementConstraint);
        }

        [Test]
        [Property("Draggable", 3), Property("Draggable test tab Number:", 4)] // Cursor style = tab no 4
        [Description("Cursor style: Drag all dragables diagonally with same offset, check if elements' positions changed properly")]
        [Author("vankatabe")]
        /* Not all of this test's Asserts will pass. Because of the nature of the draggable elements on the page. It could be adjusted to pass, though
         *  - by calculating the correct cursor positions and offsets - get the size of the element, divide by two.
         *  Then for the "-5" element - extract from the expected offset 5 and extract also size/2 - for both horizontal and vertical coordinates
         *  For the "bottom" element - extract from expected offset size(height)/2 for the vertical coordinate
         */
        public void CursorStyle_DragDiagonallyAllElements_ElementsMovedAccordingly()
        {
            var draggablePage = new DraggablePage(this.driver);
            InteractionPages drag = AccessExcelData.GetInteractionTestsData(TestContext.CurrentContext.Test.Name); // Get the current test method name (CursorStyle_DragDiagonallyAllElements_ElementsMovedAccordingly) and use it as a Key in the xlsx file
            // Get the tab number (e.g. "Default functionality", Constrain movement") from the test property above and give it to the URL
            draggablePage.tabNo = TestContext.CurrentContext.Test.Properties.Get("Draggable test tab Number:").ToString();
            draggablePage.NavigateTo(draggablePage.URL);
            // Scroll page Up so the element is into view. Because when Firefox opens the desired page/tab, somehow the page is scrolled down
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", draggablePage.TopOfPage);

            draggablePage.DragObject(int.Parse(drag.HorizontalOffset), int.Parse(drag.VerticalOffset), draggablePage.DraggableElementCursor1);
            draggablePage.DragObject(int.Parse(drag.HorizontalOffset), int.Parse(drag.VerticalOffset), draggablePage.DraggableElementCursor2);
            draggablePage.DragObject(int.Parse(drag.HorizontalOffset), int.Parse(drag.VerticalOffset), draggablePage.DraggableElementCursor3);

            draggablePage.AssertElementIsMovedCorrectly(int.Parse(drag.HorizontalOffset), int.Parse(drag.VerticalOffset), draggablePage.DraggableElementCursor1);
            draggablePage.AssertElementIsMovedCorrectly(int.Parse(drag.HorizontalOffset), int.Parse(drag.VerticalOffset), draggablePage.DraggableElementCursor2);
            draggablePage.AssertElementIsMovedCorrectly(int.Parse(drag.HorizontalOffset), int.Parse(drag.VerticalOffset), draggablePage.DraggableElementCursor3);
        }

        [Test]
        [Property("Draggable", 4), Property("Draggable test tab Number:", 5)] // Events = tab no 5
        [Description("Events: Drag element once, check if drag counters increased by 1")]
        [Author("vankatabe")]
        public void EventsElement_DragDiagonally_DragCountersIncreasedByOne()
        {
            var draggablePage = new DraggablePage(this.driver);
            InteractionPages drag = AccessExcelData.GetInteractionTestsData(TestContext.CurrentContext.Test.Name); // Get the current test method name (TestContext.CurrentContext.Test.Name = EventsElement_DragDiagonally_DragCountersIncreasedByOne) and use it as a Key in the xlsx file
            // Get the tab number (e.g. "Default functionality", Constrain movement") from the test property above and give it to the URL
            draggablePage.tabNo = TestContext.CurrentContext.Test.Properties.Get("Draggable test tab Number:").ToString();
            draggablePage.NavigateTo(draggablePage.URL);
            // Scroll page Up so the element is into view. Because when Firefox opens the desired page/tab, somehow the page is scrolled down
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", draggablePage.TopOfPage);

            draggablePage.DragObject(int.Parse(drag.HorizontalOffset), int.Parse(drag.VerticalOffset), draggablePage.DraggableElementCounters);

            // Assert that the element has been actually moved
            draggablePage.AssertElementIsMoved(int.Parse(drag.HorizontalOffset), int.Parse(drag.VerticalOffset), draggablePage.DraggableElementCounters);
            // Now assert that the counters increased by 1
            draggablePage.AssertElementIsMovedCounter(draggablePage.DragCounterStart + 1, draggablePage.DraggableElementDragCounterStart);
            draggablePage.AssertElementIsMovedCounter(draggablePage.DragCounterStop + 1, draggablePage.DraggableElementDragCounterStop);
        }

        [Test]
        [Property("Draggable", 5), Property("Draggable test tab Number:", 7)] // Events = tab no 7
        [Description("Draggable + Sortable: Drag Item 2 to bottom of the list, check if Item 2 is at the bottom of the list")]
        [Author("vankatabe")]
        public void DraggableAndSortable_DragItem2ToListBottom_Item2IsAtListBottom()
        {
            var draggablePage = new DraggablePage(this.driver);
            // Get the current test method name and use it as a Key in the xlsx file
            InteractionPages drag = AccessExcelData.GetInteractionTestsData(TestContext.CurrentContext.Test.Name);
            // Get the tab number (e.g. "Default functionality", Constrain movement") from the test property above and give it to the URL
            draggablePage.tabNo = TestContext.CurrentContext.Test.Properties.Get("Draggable test tab Number:").ToString();
            draggablePage.NavigateTo(draggablePage.URL);
            // Scroll page Up so the element is into view. Because when Firefox opens the desired page/tab, somehow the page is scrolled down
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", draggablePage.TopOfPage);

            draggablePage.DragObject(int.Parse(drag.HorizontalOffset), int.Parse(drag.VerticalOffset), draggablePage.DraggableSortableElement2);

            // Assert that the element 5 from the list now has text "Item 2"
            Thread.Sleep(1000);
            draggablePage.AssertSortableElementIsMovedAtBottom("Item 2");
        }
    }
}
