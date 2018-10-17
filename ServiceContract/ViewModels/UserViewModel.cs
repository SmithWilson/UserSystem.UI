using System;

namespace ServiceContract.ViewModels
{
    public class UserViewModel
    {
        public string Login { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Passport { get; set; }

        public DateTimeOffset RegisterDateTime { get; set; }
    }
}
