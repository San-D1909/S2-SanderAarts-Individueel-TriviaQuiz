using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Models
{
    public class UserModel
    {
        public string Unique_id { get; set; }
        public string First_Name { get; set; }


        public string Last_Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Enter Email")]
        public string Email { get; set; }

        public string Adress { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string Birth_Day { get; set; }

        public string Gender { get; set; }
    }
}