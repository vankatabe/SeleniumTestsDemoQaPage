using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumTestsDemoQaPage.Models;
using SeleniumTestsDemoQaPage.Pages.RegistrationPage;
using System;
using System.Collections.Generic;

namespace SeleniumTestsDemoQaPage
{
    [TestFixture]
    public class RegistrationFormTests
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
            //  this.driver.Quit(); // makes Firefox to crash on a 64-bit system :(
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 1),
            Description("Test First Name field with empty string, expected Error message")]
        [Author("vankatabe")]
        // The test doesn't pass because there is a bug in the form - the error mesage disappears once you leave Name fields and go to Marital status
        public void FirstNameField_Empty_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("",
                                                         "Deianov",
                                                         new List<bool>(new bool[] { false, false, true }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "2",
                                                         "2",
                                                         "1980",
                                                         "0123456789",
                                                         "MyUsername",
                                                         "user@test.com",
                                                         @"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg",
                                                         "Short description",
                                                         "validPass",
                                                         "validPass");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertNameErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 2),
            Description("Test Last Name field with empty string, expected Error message")]
        [Author("vankatabe")] // This test uses the same code/Assert/Error elements like the First name test. Only the input data is adjusted.
        public void LastNameField_Empty_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "",
                                                         new List<bool>(new bool[] { false, false, true }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "2",
                                                         "2",
                                                         "1980",
                                                         "0123456789",
                                                         "MyUsername",
                                                         "user@test.com",
                                                         @"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg",
                                                         "Short description",
                                                         "validPass",
                                                         "validPass");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertNameErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 3),
            Description("Test First Name and Last Name fields with empty string, expected Error message")]
        [Author("vankatabe")] // This test uses the same code/Assert/Error elements like the First name test. Only the input data is adjusted.
        public void FirstNameLastNameField_Empty_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("",
                                                         "",
                                                         new List<bool>(new bool[] { false, false, true }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "2",
                                                         "2",
                                                         "1980",
                                                         "0123456789",
                                                         "MyUsername",
                                                         "user@test.com",
                                                         @"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg",
                                                         "Short description",
                                                         "validPass",
                                                         "validPass");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertNameErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 4), Property("Test No. from First iteration", 4),
            Description("Test Hobby checkboxes unchecked, expected Error message")]
        [Author("vankatabe")]
        public void HobbyCheckboxes_Unchecked_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Deianov",
                                                         new List<bool>(new bool[] { false, false, true }),
                                                         new List<bool>(new bool[] { false, false, false }),
                                                         "Bulgaria",
                                                         "2",
                                                         "2",
                                                         "1980",
                                                         "0123456789",
                                                         "MyUsername",
                                                         "user@test.com",
                                                         @"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg",
                                                         "Short description",
                                                         "validPass",
                                                         "validPass");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertHobbyErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 3), Property("Test No. from First iteration", 5),
            Description("Test Telephone number field empty, expected Error message")]
        [Author("vankatabe")]
        public void TelephoneNumberField_Empty_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Deianov",
                                                         new List<bool>(new bool[] { false, false, true }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "2",
                                                         "2",
                                                         "1980",
                                                         "",
                                                         "MyUsername",
                                                         "user@test.com",
                                                         @"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg",
                                                         "Short description",
                                                         "validPass",
                                                         "validPass");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertTelephoneErrorMessage("* This field is required");
        }


        [Test, Property("Priority", 3), Property("Test No. from First iteration", 6),
            Description("Test Telephone number field - input is between 1 and 9 digits length, expected Error message")]
        [Author("vankatabe")]
        public void TelephoneNumberField_TooShortNumber_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Deianov",
                                                         new List<bool>(new bool[] { false, false, true }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "2",
                                                         "2",
                                                         "1980",
                                                         "012345678",
                                                         "MyUsername",
                                                         "user@test.com",
                                                         @"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg",
                                                         "Short description",
                                                         "validPass",
                                                         "validPass");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertTelephoneErrorMessage("Minimum 10 Digits starting with Country Code");
        }

        [Test, Property("Priority", 3), Property("Test No. from First iteration", 7),
         Description("Test Telephone number field - input is not numerical, expected Error message")]
        [Author("vankatabe")]
        public void TelephoneNumberField_NonNumericalCharacters_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Deianov",
                                                         new List<bool>(new bool[] { false, false, true }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "2",
                                                         "2",
                                                         "1980",
                                                         "0123456789abc",
                                                         "MyUsername",
                                                         "user@test.com",
                                                         @"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg",
                                                         "Short description",
                                                         "validPass",
                                                         "validPass");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertTelephoneErrorMessage("Minimum 10 Digits starting with Country Code");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 8),
         Description("Test Username field empty, expected Error message")]
        [Author("vankatabe")]
        public void UsernameField_Empty_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Deianov",
                                                         new List<bool>(new bool[] { false, false, true }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "2",
                                                         "2",
                                                         "1980",
                                                         "0123456789",
                                                         "",
                                                         "user@test.com",
                                                         @"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg",
                                                         "Short description",
                                                         "validPass",
                                                         "validPass");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertUsernameErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 9),
         Description("Test Username already registered username, expected Error message")]
        [Author("vankatabe")]
        public void UsernameField_DuplicateUsername_ErrorMessage() // Needs a lot of wait
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Deianov",
                                                         new List<bool>(new bool[] { false, false, true }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "2",
                                                         "2",
                                                         "1980",
                                                         "0123456789",
                                                         "MyUsername",
                                                         "user@test.com",
                                                         @"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg",
                                                         "Short description",
                                                         "validPass",
                                                         "validPass");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertTopOfPageErrorMessage("Username already exists");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 10),
         Description("Test Email field empty, expected Error message")]
        [Author("vankatabe")]
        public void EmailField_Empty_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Deianov",
                                                         new List<bool>(new bool[] { false, false, true }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "2",
                                                         "2",
                                                         "1980",
                                                         "0123456789",
                                                         "MyUsername",
                                                         "",
                                                         @"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg",
                                                         "Short description",
                                                         "validPass",
                                                         "validPass");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertEmailErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 11),
         Description("Test Email field with invalid email string format, expected Error message")]
        [Author("vankatabe")]
        public void EmailField_InvalidEmailAddressFormat_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Deianov",
                                                         new List<bool>(new bool[] { false, false, true }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "2",
                                                         "2",
                                                         "1980",
                                                         "0123456789",
                                                         "MyUsername",
                                                         "invalid.email-address@format",
                                                         @"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg",
                                                         "Short description",
                                                         "validPass",
                                                         "validPass");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertEmailErrorMessage("* Invalid email address");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 12),
        Description("Test Email field with not allowed ANSI characters, expected Error message")]
        [Author("vankatabe")]
        public void EmailField_NotAllowedCharacters_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Deianov",
                                                         new List<bool>(new bool[] { false, false, true }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "2",
                                                         "2",
                                                         "1980",
                                                         "0123456789",
                                                         "MyUsername",
                                                         "user@tes;:t.com",
                                                         @"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg",
                                                         "Short description",
                                                         "validPass",
                                                         "validPass");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertEmailErrorMessage("* Invalid email address");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 13),
        Description("Test Email field with non-ANSI characters, expected Error message")]
        [Author("vankatabe")]
        public void EmailField_NonAnsiChars_ErrorMessage() // Needs a lot of wait
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Deianov",
                                                         new List<bool>(new bool[] { false, false, true }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "2",
                                                         "2",
                                                         "1980",
                                                         "0123456789",
                                                         "MyUsername",
                                                         "userюзер@test.com",
                                                         @"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg",
                                                         "Short description",
                                                         "validPass",
                                                         "validPass");

            regPage.NavigateTo();
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
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Deianov",
                                                         new List<bool>(new bool[] { false, false, true }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "2",
                                                         "2",
                                                         "1980",
                                                         "0123456789",
                                                         "MyUsername3",
                                                         "user@test.com",
                                                         @"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg",
                                                         "Short description",
                                                         "validPass",
                                                         "validPass");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            //regPage.AssertTopOfPageErrorMessage("Invalid E-mail address"); // This Assert fails if there are more errors than only Email address - e.g. if Username already exists
            regPage.AssertTopOfPageErrorMessage("E-mail address already exists");
            // If username is already used, only Username error appears, not Email error
        }

        [Test, Property("Priority", 4), Property("Test No. from First iteration", 15),
        Description("Test Picture field with invalid file format, expected Error message")]
        [Author("vankatabe")]
        public void PictureField_InvalidFileFormat_ErrorMessag()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Deianov",
                                                         new List<bool>(new bool[] { false, false, true }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "2",
                                                         "2",
                                                         "1980",
                                                         "0123456789",
                                                         "MyUsername",
                                                         "user@test.com",
                                                         @"C:\Program Files (x86)\Microsoft Silverlight\sllauncher.exe",
                                                         "Short description",
                                                         "validPass",
                                                         "validPass");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPictureErrorMessage("* Invalid File");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 17),
        Description("Password field empty, expected Error message")]
        [Author("vankatabe")]
        public void PassworField_Empty_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Deianov",
                                                         new List<bool>(new bool[] { false, false, true }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "2",
                                                         "2",
                                                         "1980",
                                                         "0123456789",
                                                         "MyUsername",
                                                         "user@test.com",
                                                         @"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg",
                                                         "Short description",
                                                         "",
                                                         "validPass");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPasswordErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 18),
        Description("Password field with less than 8 characters , expected Error message")]
        [Author("vankatabe")]
        public void PassworField_TooShortPassword_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Deianov",
                                                         new List<bool>(new bool[] { false, false, true }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "2",
                                                         "2",
                                                         "1980",
                                                         "0123456789",
                                                         "MyUsername",
                                                         "user@test.com",
                                                         @"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg",
                                                         "Short description",
                                                         "shortPs",
                                                         "validPass");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPasswordErrorMessage("* Minimum 8 characters required");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 19),
       Description("Confirm Password field empty, expected Error message")]
        [Author("vankatabe")]
        public void ConfirmPassworField_Empty_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Deianov",
                                                         new List<bool>(new bool[] { false, false, true }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "2",
                                                         "2",
                                                         "1980",
                                                         "0123456789",
                                                         "MyUsername",
                                                         "user@test.com",
                                                         @"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg",
                                                         "Short description",
                                                         "validPass",
                                                         "");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertConfirmPasswordErrorMessage("* This field is required");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 20),
       Description("Confirm Password field not matching Password, expected Error message")]
        [Author("vankatabe")]
        public void ConfirmPasswordField_NotMatchingPassword_ErrorMessage()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Deianov",
                                                         new List<bool>(new bool[] { false, false, true }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "2",
                                                         "2",
                                                         "1980",
                                                         "0123456789",
                                                         "MyUsername",
                                                         "user@test.com",
                                                         @"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg",
                                                         "Short description",
                                                         "validPass",
                                                         "notMatchingConfirmPassString");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertConfirmPasswordErrorMessage("* Fields do not match");
        }

        [Test, Property("Priority", 2), Property("Test No. from First iteration", 21),
       Description("Confirm Password field not matching Password, expected Error message in Password Strength field")]
        [Author("vankatabe")]
        public void ConfirmPasswordField_NotMatchingPassword_ErrorMessageInPassStrengthField()
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Deianov",
                                                         new List<bool>(new bool[] { false, false, true }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "2",
                                                         "2",
                                                         "1980",
                                                         "0123456789",
                                                         "MyUsername",
                                                         "user@test.com",
                                                         @"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg",
                                                         "Short description",
                                                         "validPass",
                                                         "notMatchingConfirmPassString");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertPasswordStrengthErrorMessage("Mismatch");
        }

        [Test, Property("Priority", 1), Property("Test No. from First iteration", 25),
     Description("Test Username field with already used email and Email field with already used username expected two Error messages")]
        [Author("vankatabe")]
        // This test fails - only Username Eror message appears
        public void UsernameFieldEmailField_DuplicateEmailAndUsername_ErrorMessages() // Needs a lot of wait
        {
            RegistrationPage regPage = new RegistrationPage(this.driver);
            RegistrationUser user = new RegistrationUser("Ivan",
                                                         "Deianov",
                                                         new List<bool>(new bool[] { false, false, true }),
                                                         new List<bool>(new bool[] { true, true, false }),
                                                         "Bulgaria",
                                                         "2",
                                                         "2",
                                                         "1980",
                                                         "0123456789",
                                                         "MyUsername",
                                                         "user@test.com",
                                                         @"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg",
                                                         "Short description",
                                                         "validPass",
                                                         "validPass");

            regPage.NavigateTo();
            regPage.FillRegistrationForm(user);

            regPage.AssertTopOfPageErrorMessage("Username already exists");
            regPage.AssertTopOfPageErrorMessage("E-mail address already exists");
        }
    }
}
