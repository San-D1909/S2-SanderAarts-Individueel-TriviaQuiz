using System.ComponentModel.DataAnnotations;

namespace BusinessManager.Business
{
    public class UserDTO
    {
        public UserDTO( string first, string last, string email, string password, string birth_day)
        {
            First_Name = first;
            Last_Name = last;
            Email = email;
            Password = password;
            Birth_Day = birth_day;
        }
        public UserDTO(DataManager.Data.UserDTO data)
        {
            Unique_id = data.Unique_id;
            First_Name = data.First_Name;
            Last_Name = data.Last_Name;
            Email = data.Email;
            Birth_Day = data.Birth_Day;
        }
        public string Unique_id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Birth_Day { get; set; }
    }
}