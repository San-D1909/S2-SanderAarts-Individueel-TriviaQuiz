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
            UserModel userModel = Login.SelectUserData(user.Email, user.Password, user);
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
            string storeData = "INSERT INTO `user`(`firstname`, `lastname`, `email`, `password`,  `adres`, `birth_day`) VALUES ('" + registration.First_Name + "','" + registration.Last_Name + "','" + registration.Email + "','" + registration.Password + "', '" + registration.Adress + "','" + registration.Birth_Day + "');";
            if (StroreToDatabase.StoreData(storeData))
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
