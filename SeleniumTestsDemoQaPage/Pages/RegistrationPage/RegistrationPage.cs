using OpenQA.Selenium;
using SeleniumTestsDemoQaPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestsDemoQaPage.Pages.RegistrationPage
{
    public partial class RegistrationPage : BasePage
    {

        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        public string URL
        { get
            {
                return "http://demoqa.com/registration/";
            }
        }

        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public void FillRegistrationForm(RegistrationUser user)
        {
            Type(this.FirstName, user.FirstName);
            Type(this.LastName, user.LastName);
            ClickOnElements(this.MaritalStatus, user.MaritalStatus);
            ClickOnElements(this.Hobbies, user.Hobbies);
            this.CountryListSelect.SelectByText(user.Country);
            this.MonthListSelect.SelectByValue(user.BirthMonth);
            this.DayListSelect.SelectByText(user.BirthDay);
            this.YearListSelect.SelectByText(user.BirthYear);
            Type(this.PhoneNumber, user.PhoneNumber);
            Type(this.Username, user.Username);
            Type(this.Email, user.Email);
            this.UploadButton.Click();
            this.Driver.SwitchTo().ActiveElement().SendKeys(user.Picture);
            Type(this.Description, user.Description);
            Type(this.Password, user.Password);
            Type(this.ConfirmPassword, user.ConfirmPassword);
            this.SubmitButton.Click();
        }

        private void ClickOnElements(List<IWebElement> elements, List<bool> conditions)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                if (conditions[i])
                {
                    elements[i].Click();
                }
            }
        }

        private void Type(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
