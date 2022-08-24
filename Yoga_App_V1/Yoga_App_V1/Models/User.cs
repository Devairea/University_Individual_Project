using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Yoga_App_V1.Models
{
    public class User
    {
        // Properties
        [PrimaryKey]
        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime RegisterDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }

        public string FreeTime { get; set; }
    }
}
