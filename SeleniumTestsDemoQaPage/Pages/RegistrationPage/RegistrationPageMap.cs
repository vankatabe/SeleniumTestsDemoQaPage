    using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestsDemoQaPage.Pages.RegistrationPage
{
    public partial class RegistrationPage
    {
        public IWebElement FirstName
        {
            get
            {
                return this.Driver.FindElement(By.Id("name_3_firstname"));
            }
        }

        public IWebElement LastName
        {
            get
            {
                return this.Driver.FindElement(By.Id("name_3_lastname"));
            }
        }

        public List<IWebElement> MaritalStatus
        {
            get
            {
                return this.Driver.FindElements(By.Name("radio_4[]")).ToList();
            }   
        }



        public List<IWebElement> Hobbies
        {
            get
            {
                return this.Driver.FindElements(By.Name("checkbox_5[]")).ToList();
            }
        }

        private IWebElement CountryDD
        {
            get
            {
                return this.Driver.FindElement(By.Id("dropdown_7"));
            }
        }

        public SelectElement CountryListSelect
        {
            get
            {
                return new SelectElement(CountryDD);
            }
        }

        private IWebElement MonthDD
        {
            get
            {
                return this.Driver.FindElement(By.Id("mm_date_8"));
            }
        }

        public SelectElement MonthListSelect
        {
            get
            {
                return new SelectElement(MonthDD);
            }
        }

        private IWebElement DayDD
        {
            get
            {
                return this.Driver.FindElement(By.Id("dd_date_8"));
            }
        }

        public SelectElement DayListSelect
        {
            get
            {
                return new SelectElement(DayDD);
            }
        }
        private IWebElement YearDD
        {
            get
            {
                return this.Driver.FindElement(By.Id("yy_date_8"));
            }
        }

        public SelectElement YearListSelect
        {
            get
            {
                return new SelectElement(YearDD);
            }
        }

        public IWebElement PhoneNumber
        {
            get
            {
                return this.Driver.FindElement(By.Id("phone_9"));
            }
        }

        public IWebElement Username
        {
            get
            {
                return this.Driver.FindElement(By.Id("username"));
            }
        }

        public IWebElement Email
        {
            get
            {
                return this.Driver.FindElement(By.Id("email_1"));
            }
        }

        public IWebElement UploadButton
        {
            get
            {
                return this.Driver.FindElement(By.Id("profile_pic_10"));
            }
        }

        public IWebElement Description
        {
            get
            {
                return this.Driver.FindElement(By.Id("description"));
            }
        }

        public IWebElement Password
        {
            get
            {
                return this.Driver.FindElement(By.Id("password_2"));
            }
        }

        public IWebElement ConfirmPassword
        {
            get
            {
                return this.Driver.FindElement(By.Id("confirm_password_password_2"));
            }
        }
        public IWebElement SubmitButton
        {
            get
            {
                return this.Driver.FindElement(By.Name("pie_submit"));
            }
        }

        public IWebElement ErrorMessageForName
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='pie_register']/li[1]/div/div/span")));
                return this.Driver.FindElement(By.XPath("//*[@id='pie_register']/li[1]/div/div/span"));
            }
        }

        /* Another way to do the above, so you get a meaningful Exception message instead of "Time out" and "No such element {some Xpath}":
         * Try it!
        public IWebElement ErrorMessageForName
        {
            get
            {
                try
                {
                    this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='pie_register']/li[1]/div/div/span")));
                    return this.Driver.FindElement(By.XPath("//*[@id='pie_register']/li[1]/div/div/span"));
                }
                catch (WebDriverTimeoutException ex)
                {
                    throw new NoSuchElementException(string.Format("There is no Error Message in the Reg form"), ex);
                }
            }
	    }
        */

        public IWebElement ErrorMessageForHobby
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='pie_register']/li[3]/div/div[2]/span")));
                return this.Driver.FindElement(By.XPath("//*[@id='pie_register']/li[3]/div/div[2]/span"));
            }
        }

        public IWebElement ErrorMessageForEmail
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='pie_register']/li[8]/div/div/span")));
                return this.Driver.FindElement(By.XPath("//*[@id='pie_register']/li[8]/div/div/span"));
            }
        }

        public IWebElement ErrorMessageTopOfPage
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='post-49']/div/p")));
                return this.Driver.FindElement(By.XPath("//*[@id='post-49']/div/p"));
            }
        }

        public IWebElement ErrorMessageForTelephone
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='pie_register']/li[6]/div/div/span")));
                return this.Driver.FindElement(By.XPath("//*[@id='pie_register']/li[6]/div/div/span"));
            }
        }

        public IWebElement ErrorMessageForUsername
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='pie_register']/li[7]/div/div/span")));
                return this.Driver.FindElement(By.XPath("//*[@id='pie_register']/li[7]/div/div/span"));
            }
        }

        public IWebElement ErrorMessageForPicture
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='pie_register']/li[9]/div/div/span")));
                return this.Driver.FindElement(By.XPath("//*[@id='pie_register']/li[9]/div/div/span"));
            }
        }

        public IWebElement ErrorMessageForPassword
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='pie_register']/li[11]/div/div/span")));
                return this.Driver.FindElement(By.XPath("//*[@id='pie_register']/li[11]/div/div/span"));
            }
        }

        public IWebElement ErrorMessageForConfirmPassword
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='pie_register']/li[12]/div/div/span")));
                return this.Driver.FindElement(By.XPath("//*[@id='pie_register']/li[12]/div/div/span"));
            }
        }

        public IWebElement ErrorMessageForPasswordStrength
        {
            get
            {
                this.Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='piereg_passwordStrength']")));
                return this.Driver.FindElement(By.XPath("//*[@id='piereg_passwordStrength']"));
            }
        }
    }
}
