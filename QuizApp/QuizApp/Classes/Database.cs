using MySql.Data.MySqlClient;
using QuizApp.Models;
using System;
using System.Collections.Generic;

namespace QuizApp
{
    public class Database
    {
        public static void Check_databaseConnectionState(MySqlConnection databaseConnection)
        {
            if (databaseConnection.State == System.Data.ConnectionState.Open)
            {
                databaseConnection.Close();
            }
        }
        public static bool StoreData(MySqlCommand storeData, MySqlConnection databaseConnection, bool prepare)
        {
            Check_databaseConnectionState(databaseConnection);
            try
            {
                databaseConnection.Open();
                if (prepare == true)
                {
                    storeData.Prepare();
                }
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
        public static List<string> GetData(MySqlCommand GetData, MySqlConnection databaseConnection)
        {
            Check_databaseConnectionState(databaseConnection);
            List<string> results = new List<string> { };
            try
            {
                databaseConnection.Open();
                MySqlDataReader executeString = GetData.ExecuteReader();
                while (executeString.Read())
                {
                    for (int i = 0; i < executeString.FieldCount; i++)
                    {
                        results.Add(executeString.GetString(i));
                    }
                }
                databaseConnection.Close();
                return results;
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e.Message);
                return null;
            }
        }
        public static UserModel Login(string Uname, string Password, UserModel userModel)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DB_Credentials.DbConnectionString);
            MySqlCommand getUserData = new MySqlCommand("SELECT * FROM user WHERE email=@val1 AND password=@val2", databaseConnection);
            getUserData.Parameters.AddWithValue("@val1", Uname);
            getUserData.Parameters.AddWithValue("@val2", Password);
            Check_databaseConnectionState(databaseConnection);
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
            databaseConnection.Close();
            return userModel;
        }
    }
}