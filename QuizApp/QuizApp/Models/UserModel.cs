using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public class UserModel
    {
        public UserModel(BusinessManager.Business.UserDTO dto)
        {
            Unique_id = dto.Unique_id;
            First_Name = dto.First_Name;
            Last_Name = dto.Last_Name;
            Email = dto.Email;
            Birth_Day = dto.Birth_Day;
        }

        public UserModel()
        {

        }
        public string Unique_id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Enter Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string Birth_Day { get; set; }
    }
}