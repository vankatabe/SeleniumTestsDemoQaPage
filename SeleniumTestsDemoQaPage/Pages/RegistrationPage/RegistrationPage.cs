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
        {
            get
            {
                return base.url + "registration/";
            }
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

        private void ClickOnElements(List<IWebElement> elements, string values)
        {
            // parse string 'values' to List<int>
            List<int> itemsToClick = values.Split(',').Select(int.Parse).ToList();

            // if clickableElement's number exists in the list, clik the Element
            for (int clickableElement = 0; clickableElement < elements.Count; clickableElement++)
            {
                //* This is more elegant solution but it skips to click on MaritalStatus when there is only one digit in the Excel cell
                if (itemsToClick.Contains(clickableElement))
                {
                    /* The next row is needed to "find" the radiobutton and click it. Otherwise it doesn't click on it.
                     * Otherwise, I guess you need to handle it like a drop-down selection - one step to find it and second step to select an option.
                     */
                    elements[clickableElement].Submit();

                    elements[clickableElement].Click();
                }


                //Instead of the elegant solution:
                //     for (int itemToClick = 0; itemToClick < itemsToClick.Count; itemToClick++)
                //     {
                //         if (itemsToClick[itemToClick].Equals(clickableElement))
                //         {
                //             elements[clickableElement].Click();
                //         }
                //     }

            }
        }

        private void SelectRadioButton(List<IWebElement> elements, int value)
        {
            elements[value].Click();
        }

        private void Type(IWebElement element, string text)
        {
            element.Clear();
            if (text == null)
            {
                text = String.Empty;
            }
            element.SendKeys(text);

            // Or:
            //  element.Clear();
            //  if (text != null)
            //  {
            //      element.SendKeys(text);
            //  }
        }
    }
}
