using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using QuizApp.Models;

namespace QuizApp
{
    public class StroreToDatabase
    {
        public static bool StoreData(string storeData)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DB_Credentials.DbConnectionString);
            MySqlCommand StoreRegisterData = new MySqlCommand(storeData, databaseConnection);
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