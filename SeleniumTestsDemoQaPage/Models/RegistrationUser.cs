using System.Collections.Generic;

namespace SeleniumTestsDemoQaPage.Models
{
    public class RegistrationUser
    {
        private string firstName;
        private string lastName;
        private List<bool> maritalStatus;
        private List<bool> hobbies;
        private string country;
        private string birthMonth;
        private string birthDay;
        private string birthYear;
        private string phoneNumber;
        private string username;
        private string email;
        private string picture;
        private string description;
        private string password;
        private string confirmPassword;

        public RegistrationUser(string firstName,
                                string lastName,
                                List<bool> maritalStatus,
                                List<bool> hobbies,
                                string country,
                                string birthMonth,
                                string birthDay,
                                string birthYear,
                                string phoneNumber,
                                string username,
                                string email,
                                string picture,
                                string description,
                                string password,
                                string confirmPassword)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.maritalStatus = maritalStatus;
            this.hobbies = hobbies;
            this.country = country;
            this.birthMonth = birthMonth;
            this.birthDay = birthDay;
            this.birthYear = birthYear;
            this.phoneNumber = phoneNumber;
            this.username = username;
            this.email = email;
            this.picture = picture;
            this.description = description;
            this.password = password;
            this.confirmPassword = confirmPassword;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public List<bool> MaritalStatus
        {
            get { return this.maritalStatus; }
            set { this.maritalStatus = value; }
        }

        public List<bool> Hobbies
        {
            get { return this.hobbies; }
            set { this.hobbies = value; }
        }

        public string Country
        {
            get { return this.country; }
            set { this.country = value; }
        }

        public string BirthMonth
        {
            get { return this.birthMonth; }
            set { this.birthMonth = value; }
        }

        public string BirthDay
        {
            get { return this.birthDay; }
            set { this.birthDay = value; }
        }

        public string BirthYear
        {
            get { return this.birthYear; }
            set { this.birthYear = value; }
        }

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value; }
        }

        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string Picture
        {
            get { return this.picture; }
            set { this.picture = value; }
        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public string ConfirmPassword
        {
            get { return this.confirmPassword; }
            set { this.confirmPassword = value; }
        }
    }
}
