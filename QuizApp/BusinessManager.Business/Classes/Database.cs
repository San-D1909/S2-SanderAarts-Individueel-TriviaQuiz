using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace BusinessManager.Business
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
    }
}