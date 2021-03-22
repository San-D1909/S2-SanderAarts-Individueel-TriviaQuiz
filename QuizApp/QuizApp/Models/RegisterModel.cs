using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public class RegisterModel
    {
        [DisplayName("First Name")]
        [Required(ErrorMessage = "This field is required")]
        public string First_Name { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "This field is required")]
        public string Last_Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("E-Mail")]
        [Required(ErrorMessage = "This field is required")]

        public string Email { get; set; }
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        [Required(ErrorMessage = "This field is required")]

        public string Password { get; set; }
        [Required(ErrorMessage = "This field is required")]

        public string Adress { get; set; }

        [DisplayName("Birth Day")]
        [Required(ErrorMessage = "This field is required")]

        public string Birth_Day { get; set; }



    }

}