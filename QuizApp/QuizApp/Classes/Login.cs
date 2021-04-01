using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Web.Mvc;
using QuizApp.Models;

namespace QuizApp
{
    public class Login
    {
        public static UserModel SelectUserData(string Uname, string Password, UserModel userModel)
        {
            //string getUserData = "SELECT * FROM `user` WHERE `email` = '" + Uname + "' AND `password` = '" + Password + "'";
            MySqlConnection databaseConnection = new MySqlConnection(DB_Credentials.DbConnectionString);
            MySqlCommand getUserData = new MySqlCommand("SELECT * FROM user WHERE email=@val1 AND password=@val2", databaseConnection);
            getUserData.Parameters.AddWithValue("@val1",Uname);
            getUserData.Parameters. AddWithValue("@val2", Password);
            

            try
            {
                databaseConnection.Open();
                getUserData.Prepare();
                var executeString = getUserData.ExecuteReader();
                while (executeString.Read())
                {
                    userModel.Unique_id = executeString.GetString(0);
                    userModel.First_Name = executeString.GetString(1);
                    userModel.Last_Name = executeString.GetString(2);
                    userModel.Adress = executeString.GetString(3);
                    userModel.Gender = executeString.GetString(4);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e.Message);
            }
            return userModel;
        }
    }
}