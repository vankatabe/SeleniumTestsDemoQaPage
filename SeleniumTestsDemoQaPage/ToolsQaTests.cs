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
    public class ToolsQaTests
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
            // Add Logger to SoftUni Test
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
        [Property("ToolsQa", 3)]
        [Description("Exercise 1 from the lecture - Open ToolsQa_switch_windows_practice, click on New Tab button, assert the ToolsQaHOmePage is open, then close the first tab and assert Driver handles only one window/tab")]
        [Author("vankatabe")]
        public void HandlePopUp()
        {
            var automationPage = new AutomationPage(this.driver);
            var homePage = new ToolsQaHomePage(this.driver);

            automationPage.NavigateTo();
            automationPage.NewTabButton.Click();
            this.driver.SwitchTo().ActiveElement();

            // Check is logo has "src" attribute
            homePage.AssertToolsQaLogoSrcContains("/wp-content/uploads/2014/08/Toolsqa.jpg");

            // Close the first open tab
            automationPage.PageClose();

            // Check that the driver handles only one window (in ToolsQaHomePageAsserter.cs)
            driver.AssertNumberOfWindowsHandled(1); // Attention: There are two asserts in the method
        }

        [Test]
        [Property("ToolsQa", 3)]
        [Description("Exercise 2 from the lecture - Drag a droppable element and drop it into its target ")]
        [Author("vankatabe")]
        public void DroppableElement_DragAndDropToTarget_TargetAttributeChangedToDropped()
        {
            var droppablePage = new DroppablePage(this.driver);
            droppablePage.NavigateTo(droppablePage.URL);

            droppablePage.DragAndDrop();

            droppablePage.AssertTargetAttribute("ui-widget-header ui-droppable ui-state-highlight");
        }

        [Test]
        [Property("ToolsQa", 3)]
        [Description("Exercise 3 from the lecture - Resize resizable item with H and W with 100 pixels each")]
        [Author("vankatabe")]
        public void ResizableItem_ResizeSides100PixBigger_ItemSidesAre100PixBigger()
        {
            var resizablePage = new ResizablePage(this.driver);
            resizablePage.NavigateTo(resizablePage.URL);

            resizablePage.IncreaseWidthAndHeightBy(100);

            resizablePage.AssertSizeIncreasedWith(100);
        }

        [Test]
        [Property("ToolsQa", 3)]
        [Description("Exercise 3 from the lecture another try - Resize resizable item width with 100 pixels")]
        [Author("vankatabe")]
        public void ResizableItem_ResizeWidth100PixBigger_ItemWidthIs100PixBigger()
        {
            var resizablePage = new ResizablePage(this.driver);
            resizablePage.NavigateTo(resizablePage.URL);

            resizablePage.IncreaseWidthBy(100);

            resizablePage.AssertWidthIncreasedWith(100);
        }

        [Test] // This test utilises both Data-driven tests and Log functonality (below)
        [Property("ToolsQa", 3)]
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
