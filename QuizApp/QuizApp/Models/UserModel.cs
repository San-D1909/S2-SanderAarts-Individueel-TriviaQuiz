using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public class UserModel
    {
        public UserModel(BusinessManager.Business.UserDTO dto)
        {
            UniqueID = dto.UniqueID;
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            Email = dto.Email;
            BirthDay = dto.BirthDay;
        }

        public UserModel()
        {

        }
        public string UniqueID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Enter Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string BirthDay { get; set; }
    }
}