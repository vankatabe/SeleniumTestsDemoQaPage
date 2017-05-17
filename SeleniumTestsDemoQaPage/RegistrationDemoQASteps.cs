using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumTestsDemoQaPage.Models;
using SeleniumTestsDemoQaPage.Pages.RegistrationPage;
using System;
using System.Reflection;
using TechTalk.SpecFlow;

namespace SeleniumTestsDemoQaPage
{
    [Binding]
    public class RegistrationDemoQASteps
    {
        IWebDriver driver = new FirefoxDriver();
        private RegistrationUser user;
        private RegistrationPage regPage;

        [Given(@"I am on the Registration page")]
        public void GivenIAmOnTheRegistrationPage()
        {
            regPage = new RegistrationPage(this.driver);
            regPage.NavigateTo(regPage.URL);
        }

        [When(@"I fill-in the registration form without first name is ""(.*)""")]
        public void WhenIFill_InTheRegistrationFormWithoutFirstNameIs(string testName)
        {
            user = AccessExcelData.GetTestUserData(testName);
            regPage.FillRegistrationForm(user);
        }

        [Then(@"Error message for names should be displayed is ""(.*)""")]
        public void ThenErrorMessageForNamesShouldBeDisplayedIs(string errorMessage)
        {
            MethodInfo asserter = typeof(RegistrationPageAssester).GetMethod(user.Asserter);
            asserter.Invoke(null, new object[] { regPage, errorMessage });
            // could be also like next row - Effect - from the Effect column in the Excel file. Need to add Effect property in RegistrationUser.cs
            asserter.Invoke(null, new object[] { regPage, user.Effect });
        }
    }
}

