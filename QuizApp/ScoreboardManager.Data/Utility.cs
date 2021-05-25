using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    class Utility
    {
        public static readonly MySqlConnection databaseConnection = new MySqlConnection("Datasource=127.0.0.1;port=3306;username=root;password=;database= quizapp;");
        public static void Check_databaseConnectionState(MySqlConnection databaseConnection)
        {
            if (databaseConnection.State == System.Data.ConnectionState.Open)
            {
                databaseConnection.Close();
            }
        }
        public static bool StoreData(MySqlCommand sqlCommand, bool prepare)
        {
            Check_databaseConnectionState(databaseConnection);
            try
            {
                sqlCommand.Connection = databaseConnection;
                databaseConnection.Open();
                if (prepare == true)
                {
                    sqlCommand.Prepare();
                }
                MySqlDataReader executeString = sqlCommand.ExecuteReader();
                databaseConnection.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e.Message);
                return false;
            }
        }
        public static List<string> GetData(MySqlCommand sqlCommand,bool prepare = false )
        {
            Check_databaseConnectionState(databaseConnection);
            List<string> results = new List<string> { };
            try
            {
                sqlCommand.Connection = databaseConnection;
                databaseConnection.Open();
                if (prepare == true)
                {
                    sqlCommand.Prepare();
                }
                MySqlDataReader executeString = sqlCommand.ExecuteReader();
                while (executeString.Read())
                {
                    for (int i = 0; i < executeString.FieldCount; i++)
                    {
                        results.Add(executeString.GetValue(i).ToString());
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
    }
}
