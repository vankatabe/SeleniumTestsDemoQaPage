using System.Collections.Generic;

namespace SeleniumTestsDemoQaPage.Models
{
    public class RegistrationUser
    {
        public string Key { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        /* If we want to hardcode the next two values or we want to put somewhere a random-string generating function:
        * public List<bool> MaritalStatus { get { return new List<bool>(new bool[] { false, false, true }); } }
        * public List<bool> Hobbies { get { return new List<bool>(new bool[] { false, false, true }); } }
        */

        public string MaritalStatus { get; set; }

        public string Hobbies { get; set; }

        public string Country { get; set; }

        public string BirthMonth { get; set; }

        public string BirthDay { get; set; }

        public string BirthYear { get; set; }

        public string PhoneNumber { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

    }
}
