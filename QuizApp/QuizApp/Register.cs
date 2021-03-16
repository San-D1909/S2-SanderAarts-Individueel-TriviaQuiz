using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace QuizApp
{
    public class Register
    {
        public static bool StoreUserData(string Fname, string Lname, string Email, string Password, string Adress, int Gender, string BirthDay)
        {
            string StoreData = "INSERT INTO `user`(`firstname`, `lastname`, `email`, `password`,  `adres`, `gender`, `birth_day`) VALUES ('" + Fname + "','" + Lname + "','" + Email + "','" + Password + "', '" + Adress + "','" + Gender + "','" + BirthDay + "');";
            MySqlConnection databaseConnection = new MySqlConnection(QuizApp.Models.DB_Credentials.DbConnectionString);
            MySqlCommand StoreRegisterData = new MySqlCommand(StoreData, databaseConnection);
            if (Fname == null || Lname == null || Password == null || Email == null || Adress == null || BirthDay == null)
            {
                return false;
            }
            else
            {
                try
                {
                    databaseConnection.Open();
                    MySqlDataReader executeString = StoreRegisterData.ExecuteReader();
                    databaseConnection.Close();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("error: " + e.Message);
                    return false;
                }
            }
        }
    }
}