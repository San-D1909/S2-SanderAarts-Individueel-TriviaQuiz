using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public class RegisterModel
    {
        [DisplayName("First Name")]
        [Required(ErrorMessage = "This field is required")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "This field is required")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("E-Mail")]
        [Required(ErrorMessage = "This field is required")]

        public string Email { get; set; }
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        [Required(ErrorMessage = "This field is required")]

        public string Password { get; set; }

        [DisplayName("Birth Day")]
        [Required(ErrorMessage = "This field is required")]

        public string BirthDay { get; set; }



    }

}