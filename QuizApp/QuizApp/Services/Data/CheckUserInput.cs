using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizApp.Models;

namespace QuizApp.Services.Data
{
    public class CheckUserInput
    {
        internal UserModel FindByUser(UserModel user)
        {
            UserModel userModel = Login.SelectUserData(user.Email, user.Password,user);
            if (userModel != null)
            {
                return userModel;
            }
            else
            {
                return null;
            }
        }
        internal bool StoreUser(RegisterModel registration)
        {
            if(QuizApp.Register.StoreUserData(registration.First_Name, registration.Last_Name, registration.Email, registration.Password, registration.Adress, (int)registration.Gender, registration.Birth_Day))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
