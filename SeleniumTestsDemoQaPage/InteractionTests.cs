using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using SeleniumTestsDemoQaPage.Models;
using SeleniumTestsDemoQaPage.Pages.AutomationPracticePage;
using SeleniumTestsDemoQaPage.Pages.DroppablePage;
using SeleniumTestsDemoQaPage.Pages.ResizablePage;
using SeleniumTestsDemoQaPage.Pages.ToolsQaHomePage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestsDemoQaPage
{
    [TestFixture]
    public class InteractionTests
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

            driver.Quit(); // causes Firefox to crash
        }

        [Test]
        [Property("Interaction type:", 1), Property("Draggable tests number:", 1)]
        [Description("1 - Draggable: Drag a draggable element and drop it into its target, check if target status is dropped")]
        [Author("vankatabe")]
        public void DraggableElement_DragAndDropToTarget_TargetAttributeChangedToDropped()
        {
            var droppablePage = new DroppablePage(this.driver);
            droppablePage.NavigateTo(droppablePage.URL);

            droppablePage.DragAndDrop();

            droppablePage.AssertElementIsDroppedAttribute("ui-widget-header ui-droppable ui-state-highlight");
        }

        [Test]
        [Property("Interaction type:", 1), Property("Draggable tests number:", 2)]
        [Description("1 - Draggable: Drag a draggable element and drop it into its target, check if target status is dropped")]
        [Author("vankatabe")]
        public void DraggableElement_DragAndDropToTarget_TargetAttributeChangedToDropped9()
        {
            var droppablePage = new DroppablePage(this.driver);
            droppablePage.NavigateTo(droppablePage.URL);

            droppablePage.DragAndDrop();

            droppablePage.AssertElementIsDroppedAttribute("ui-widget-header ui-droppable ui-state-highlight");
        }

        [Test]
        [Property("Interaction", 3)]
        [Description("Exercise 3 from the lecture - Resize resizable item bith H and W with 100 pixels each")]
        [Author("vankatabe")]
        public void ResizableItem_ResizeSides100PixBigger_ItemSidesAre100PixBigger()
        {
            var resizablePage = new ResizablePage(this.driver);
            resizablePage.NavigateTo(resizablePage.URL);

            resizablePage.IncreaseWidthAndHeightBy(100);

            resizablePage.AssertSizeIncreasedWith(100);
        }

        [Test] // This test utilises both Data-driven tests and Log functonality (below)
        [Property("Interaction", 3)]
        [Description("Exercise 4 from the lecture - Add Logger to SoftUni Test")]
        [Author("vankatabe")]
        public void loginSoftUni_ValidCredentials_CorrectLogoDisplayedAfterLogin()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "http://www.softuni.bg";
            IWebElement loginButton = driver.FindElement(By.XPath("//nav[@id='header-nav']/div[2]/ul/li[2]/span/a"));
            loginButton.Click();

            var softUniUser = AccessExcelData.GetTestData("Login");
            IWebElement userName = driver.FindElement(By.Name("username"));
            userName.Clear();
            userName.SendKeys(softUniUser.Username);
            IWebElement password = driver.FindElement(By.Name("password"));
            password.Clear();
            password.SendKeys(softUniUser.Password);

            IWebElement loginButton2 = driver.FindElement(By.XPath("//form/input[2]"));
            loginButton2.Click();
            IWebElement logo = driver.FindElement(By.XPath("//header[@id='page-header']/div/div/div/div/a/img"));
            Assert.IsTrue(logo.Displayed, "The logo is not displayed properly");
        }

       
    }
}
