using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using QuizApp.Models;

namespace QuizApp
{
    public class Database
    {
        public static bool StoreData(MySqlCommand storeData, MySqlConnection databaseConnection)
        {
            try
            {
                databaseConnection.Open();
                storeData.Prepare();
                MySqlDataReader executeString = storeData.ExecuteReader();
                databaseConnection.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e.Message);
                return false;
            }

        }
        public static UserModel Login(string Uname, string Password, UserModel userModel)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DB_Credentials.DbConnectionString);
            MySqlCommand getUserData = new MySqlCommand("SELECT * FROM user WHERE email=@val1 AND password=@val2", databaseConnection);
            getUserData.Parameters.AddWithValue("@val1", Uname);
            getUserData.Parameters.AddWithValue("@val2", Password);
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