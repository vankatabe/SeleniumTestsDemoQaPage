using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumTestsDemoQaPage.Models;
using SeleniumTestsDemoQaPage.Pages.RegistrationPage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace SeleniumTestsDemoQaPage
{
    [TestFixture]
    public class RegistrationFormTests_dataDriven_olderWay
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
            // Add txt logger and screenshot for failed tests
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

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 1),
            Description("Test First Name field with empty string, expected Error message")]
        [Author("vankatabe")]
        // The test doesn't pass because there is a bug in the form - the error mesage disappears once you leave Name fields and go to Marital status
        public void FirstNameField_Empty_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = AccessExcelData.GetTestUserData(TestContext.CurrentContext.Test.Name); // Get the current test method name (TestContext.CurrentContext.Test.Name = FirstNameField_Empty_ErrorMessage) and use it as a Key in the xlsx file

            regPage.NavigateTo(regPage.URL);
            regPage.FillRegistrationForm(user);

            regPage.AssertNameErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 2),
            Description("Test Last Name field with empty string, expected Error message")]
        [Author("vankatabe")] // This test uses the same code/Assert/Error elements like the First name test. Only the input data is adjusted.
        public void LastNameField_Empty_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = AccessExcelData.GetTestUserData(TestContext.CurrentContext.Test.Name); // Get the current test method name (TestContext.CurrentContext.Test.Name = FirstNameField_Empty_ErrorMessage) and use it as a Key in the xlsx file

            regPage.NavigateTo(regPage.URL);
            regPage.FillRegistrationForm(user);

            regPage.AssertNameErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 3),
            Description("Test First Name and Last Name fields with empty string, expected Error message")]
        [Author("vankatabe")] // This test uses the same code/Assert/Error elements like the First name test. Only the input data is adjusted.
        public void FirstNameLastNameField_Empty_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = AccessExcelData.GetTestUserData(TestContext.CurrentContext.Test.Name); // Get the current test method name (TestContext.CurrentContext.Test.Name = FirstNameField_Empty_ErrorMessage) and use it as a Key in the xlsx file

            regPage.NavigateTo(regPage.URL);
            regPage.FillRegistrationForm(user);

            regPage.AssertNameErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 4), Property("Test No. from First iteration", 4),
            Description("Test Hobby checkboxes unchecked, expected Error message")]
        [Author("vankatabe")]
        public void HobbyCheckboxes_Unchecked_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = AccessExcelData.GetTestUserData(TestContext.CurrentContext.Test.Name); // Get the current test method name (TestContext.CurrentContext.Test.Name = FirstNameField_Empty_ErrorMessage) and use it as a Key in the xlsx file

            regPage.NavigateTo(regPage.URL);
            regPage.FillRegistrationForm(user);

            regPage.AssertHobbyErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 3), Property("Test No. from First iteration", 5),
            Description("Test Telephone number field empty, expected Error message")]
        [Author("vankatabe")]
        public void TelephoneNumberField_Empty_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = AccessExcelData.GetTestUserData(TestContext.CurrentContext.Test.Name); // Get the current test method name (TestContext.CurrentContext.Test.Name = FirstNameField_Empty_ErrorMessage) and use it as a Key in the xlsx file

            regPage.NavigateTo(regPage.URL);
            regPage.FillRegistrationForm(user);

            regPage.AssertTelephoneErrorMessage("* This field is required");
        }


        [Test, Property("Priority", 3), Property("Test No. from First iteration", 6),
            Description("Test Telephone number field - input is between 1 and 9 digits length, expected Error message")]
        [Author("vankatabe")]
        public void TelephoneNumberField_TooShortNumber_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = AccessExcelData.GetTestUserData(TestContext.CurrentContext.Test.Name); // Get the current test method name (TestContext.CurrentContext.Test.Name = FirstNameField_Empty_ErrorMessage) and use it as a Key in the xlsx file

            regPage.NavigateTo(regPage.URL);
            regPage.FillRegistrationForm(user);

            regPage.AssertTelephoneErrorMessage("Minimum 10 Digits starting with Country Code");
        }

        [Test, Property("Priority", 3), Property("Test No. from First iteration", 7),
         Description("Test Telephone number field - input is not numerical, expected Error message")]
        [Author("vankatabe")]
        public void TelephoneNumberField_NonNumericalCharacters_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = AccessExcelData.GetTestUserData(TestContext.CurrentContext.Test.Name); // Get the current test method name (TestContext.CurrentContext.Test.Name = FirstNameField_Empty_ErrorMessage) and use it as a Key in the xlsx file

            regPage.NavigateTo(regPage.URL);
            regPage.FillRegistrationForm(user);

            regPage.AssertTelephoneErrorMessage("Minimum 10 Digits starting with Country Code");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 8),
         Description("Test Username field empty, expected Error message")]
        [Author("vankatabe")]
        public void UsernameField_Empty_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = AccessExcelData.GetTestUserData(TestContext.CurrentContext.Test.Name); // Get the current test method name (TestContext.CurrentContext.Test.Name = FirstNameField_Empty_ErrorMessage) and use it as a Key in the xlsx file

            regPage.NavigateTo(regPage.URL);
            regPage.FillRegistrationForm(user);

            regPage.AssertUsernameErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 9),
         Description("Test Username already registered username, expected Error message")]
        [Author("vankatabe")]
        public void UsernameField_DuplicateUsername_ErrorMessage() // Needs a lot of wait
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = AccessExcelData.GetTestUserData(TestContext.CurrentContext.Test.Name); // Get the current test method name (TestContext.CurrentContext.Test.Name = FirstNameField_Empty_ErrorMessage) and use it as a Key in the xlsx file

            regPage.NavigateTo(regPage.URL);
            regPage.FillRegistrationForm(user);

            regPage.AssertTopOfPageErrorMessage("Username already exists");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 10),
         Description("Test Email field empty, expected Error message")]
        [Author("vankatabe")]
        public void EmailField_Empty_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = AccessExcelData.GetTestUserData(TestContext.CurrentContext.Test.Name); // Get the current test method name (TestContext.CurrentContext.Test.Name = FirstNameField_Empty_ErrorMessage) and use it as a Key in the xlsx file

            regPage.NavigateTo(regPage.URL);
            regPage.FillRegistrationForm(user);

            regPage.AssertEmailErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 11),
         Description("Test Email field with invalid email string format, expected Error message")]
        [Author("vankatabe")]
        public void EmailField_InvalidEmailAddressFormat_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = AccessExcelData.GetTestUserData(TestContext.CurrentContext.Test.Name); // Get the current test method name (TestContext.CurrentContext.Test.Name = FirstNameField_Empty_ErrorMessage) and use it as a Key in the xlsx file

            regPage.NavigateTo(regPage.URL);
            regPage.FillRegistrationForm(user);

            regPage.AssertEmailErrorMessage("* Invalid email address");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 12),
        Description("Test Email field with not allowed ANSI characters, expected Error message")]
        [Author("vankatabe")]
        public void EmailField_NotAllowedCharacters_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = AccessExcelData.GetTestUserData(TestContext.CurrentContext.Test.Name); // Get the current test method name (TestContext.CurrentContext.Test.Name = FirstNameField_Empty_ErrorMessage) and use it as a Key in the xlsx file

            regPage.NavigateTo(regPage.URL);
            regPage.FillRegistrationForm(user);

            regPage.AssertEmailErrorMessage("* Invalid email address");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 13),
        Description("Test Email field with non-ANSI characters, expected Error message")]
        [Author("vankatabe")]
        public void EmailField_NonAnsiChars_ErrorMessage() // Needs a lot of wait
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = AccessExcelData.GetTestUserData(TestContext.CurrentContext.Test.Name); // Get the current test method name (TestContext.CurrentContext.Test.Name = FirstNameField_Empty_ErrorMessage) and use it as a Key in the xlsx file

            regPage.NavigateTo(regPage.URL);
            regPage.FillRegistrationForm(user);

            //regPage.AssertTopOfPageErrorMessage("Invalid E-mail address"); // This Assert fails if there are more errors than only Email address - e.g. if Username already exists
            regPage.AssertTopOfPageErrorMessage("E-mailField must contain a valid email address");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 14),
        Description("Test Email field with already used email, expected Error message")]
        [Author("vankatabe")]
        // Username must be unique / not duplicate
        public void EmailField_DuplicateEmail_ErrorMessage() // Needs a lot of wait
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = AccessExcelData.GetTestUserData(TestContext.CurrentContext.Test.Name); // Get the current test method name (TestContext.CurrentContext.Test.Name = FirstNameField_Empty_ErrorMessage) and use it as a Key in the xlsx file

            regPage.NavigateTo(regPage.URL);
            regPage.FillRegistrationForm(user);

            //regPage.AssertTopOfPageErrorMessage("Invalid E-mail address"); // This Assert fails if there are more errors than only Email address - e.g. if Username already exists
            regPage.AssertTopOfPageErrorMessage("E-mail address already exists");
            // If username is already used, only Username error appears, not Email error
        }

        [Test, Property("Priority", 4), Property("Test No. from First iteration", 15),
        Description("Test Picture field with invalid file format, expected Error message")]
        [Author("vankatabe")]
        public void PictureField_InvalidFileFormat_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = AccessExcelData.GetTestUserData(TestContext.CurrentContext.Test.Name); // Get the current test method name (TestContext.CurrentContext.Test.Name = FirstNameField_Empty_ErrorMessage) and use it as a Key in the xlsx file

            regPage.NavigateTo(regPage.URL);
            regPage.FillRegistrationForm(user);

            regPage.AssertPictureErrorMessage("* Invalid File");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 17),
        Description("Password field empty, expected Error message")]
        [Author("vankatabe")]
        public void PassworField_Empty_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = AccessExcelData.GetTestUserData(TestContext.CurrentContext.Test.Name); // Get the current test method name (TestContext.CurrentContext.Test.Name = FirstNameField_Empty_ErrorMessage) and use it as a Key in the xlsx file

            regPage.NavigateTo(regPage.URL);
            regPage.FillRegistrationForm(user);

            regPage.AssertPasswordErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 18),
        Description("Password field with less than 8 characters , expected Error message")]
        [Author("vankatabe")]
        public void PassworField_TooShortPassword_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = AccessExcelData.GetTestUserData(TestContext.CurrentContext.Test.Name); // Get the current test method name (TestContext.CurrentContext.Test.Name = FirstNameField_Empty_ErrorMessage) and use it as a Key in the xlsx file

            regPage.NavigateTo(regPage.URL);
            regPage.FillRegistrationForm(user);

            regPage.AssertPasswordErrorMessage("* Minimum 8 characters required");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 19),
       Description("Confirm Password field empty, expected Error message")]
        [Author("vankatabe")]
        public void ConfirmPassworField_Empty_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = AccessExcelData.GetTestUserData(TestContext.CurrentContext.Test.Name); // Get the current test method name (TestContext.CurrentContext.Test.Name = FirstNameField_Empty_ErrorMessage) and use it as a Key in the xlsx file

            regPage.NavigateTo(regPage.URL);
            regPage.FillRegistrationForm(user);

            regPage.AssertConfirmPasswordErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 20),
       Description("Confirm Password field not matching Password, expected Error message")]
        [Author("vankatabe")]
        public void ConfirmPasswordField_NotMatchingPassword_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = AccessExcelData.GetTestUserData(TestContext.CurrentContext.Test.Name); // Get the current test method name (TestContext.CurrentContext.Test.Name = FirstNameField_Empty_ErrorMessage) and use it as a Key in the xlsx file

            regPage.NavigateTo(regPage.URL);
            regPage.FillRegistrationForm(user);

            regPage.AssertConfirmPasswordErrorMessage("* Fields do not match");
        }

        [Test, Property("Priority", 2), Property("Test No. from First iteration", 21),
       Description("Confirm Password field not matching Password, expected Error message in Password Strength field")]
        [Author("vankatabe")]
        public void ConfirmPasswordField_NotMatchingPassword_ErrorMessageInPassStrengthField()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = AccessExcelData.GetTestUserData(TestContext.CurrentContext.Test.Name); // Get the current test method name (TestContext.CurrentContext.Test.Name = FirstNameField_Empty_ErrorMessage) and use it as a Key in the xlsx file

            regPage.NavigateTo(regPage.URL);
            regPage.FillRegistrationForm(user);

            regPage.AssertPasswordStrengthErrorMessage("Mismatch");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 25),
        Description("Test Username field with already used email and Email field with already used username expected two Error messages")]
        [Author("vankatabe")]
        // This test fails - only Username Eror message appears
        public void UsernameFieldAndEmailField_DuplicateEmailAndUsername_ErrorMessages() // Needs a lot of wait
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = AccessExcelData.GetTestUserData(TestContext.CurrentContext.Test.Name); // Get the current test method name (TestContext.CurrentContext.Test.Name = FirstNameField_Empty_ErrorMessage) and use it as a Key in the xlsx file

            regPage.NavigateTo(regPage.URL);
            regPage.FillRegistrationForm(user);

            regPage.AssertTopOfPageErrorMessage("Username already exists");
            regPage.AssertTopOfPageErrorMessage("E-mail address already exists");
        }
    }
}
