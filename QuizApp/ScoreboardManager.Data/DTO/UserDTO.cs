using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    class UserDTO
    {
        public UserDTO( string first, string last,string email,string password,string birth_day)
        {
            First_Name = first;
            Last_Name = last;
            Email = email;
            Password = password;
            Birth_Day = birth_day;
        }

        public UserDTO()
        {

        }
        public string Unique_id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Birth_Day { get; set; }
    }
}

