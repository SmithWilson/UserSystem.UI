using Entity.Enums;
using System;

namespace Entity.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public string Passport { get; set; }

        public string Login { get; set; }

        public Secret Secret { get; set; }

        public DateTimeOffset RegisterDateTime { get; set; } = DateTimeOffset.Now;
    }
}
