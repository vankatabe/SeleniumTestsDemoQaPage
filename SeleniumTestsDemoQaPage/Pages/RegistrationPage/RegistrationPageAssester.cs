using NUnit.Framework;
using System;

namespace SeleniumTestsDemoQaPage.Pages.RegistrationPage
{
    public static class RegistrationPageAssester
    {
        public static void AssertNameErrorMessage(this RegistrationPage page, String text)
        {
            StringAssert.Contains(text, page.ErrorMessageForName.Text);
        }

        public static void AssertHobbyErrorMessage(this RegistrationPage page, String text)
        {
            StringAssert.Contains(text, page.ErrorMessageForHobby.Text);
        }

        public static void AssertUsernameErrorMessage(this RegistrationPage page, String text)
        {
            StringAssert.Contains(text, page.ErrorMessageForUsername.Text);
        }

        public static void AssertTopOfPageErrorMessage(this RegistrationPage page, String text)
        {
            StringAssert.Contains(text, page.ErrorMessageTopOfPage.Text);
        }

        public static void AssertEmailErrorMessage(this RegistrationPage page, String text)
        {
            Assert.IsTrue(page.ErrorMessageForEmail.Displayed);
            Assert.AreEqual(text, page.ErrorMessageForEmail.Text);
        }

        public static void AssertTelephoneErrorMessage(this RegistrationPage page, String text)
        {
            StringAssert.Contains(text, page.ErrorMessageForTelephone.Text);
        }

        public static void AssertPictureErrorMessage(this RegistrationPage page, String text)
        {
            StringAssert.Contains(text, page.ErrorMessageForPicture.Text);
        }

        public static void AssertPasswordErrorMessage(this RegistrationPage page, String text)
        {
            StringAssert.Contains(text, page.ErrorMessageForPassword.Text);
        }

        public static void AssertConfirmPasswordErrorMessage(this RegistrationPage page, String text)
        {
            StringAssert.Contains(text, page.ErrorMessageForConfirmPassword.Text);
        }

        public static void AssertPasswordStrengthErrorMessage(this RegistrationPage page, String text)
        {
            StringAssert.Contains(text, page.ErrorMessageForPasswordStrength.Text);
        }
    }
}
