using System.ComponentModel.DataAnnotations;

namespace BusinessManager.Business
{
    public class UserDTO
    {
        public string Unique_id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Password { get; set; }
        public string Birth_Day { get; set; }
        public string Gender { get; set; }
    }
}