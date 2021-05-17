using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    public class LoginDatabaseContext : ILoginDatabaseContext
    {
        UserDTO ILoginDatabaseContext.Login(string email, string password)
        {
            if (email.Length > 0 && password.Length > 0)
            {
                UserDTO userDTO = Login(email, password);
                return userDTO;
            }
            return null;
        }
        private UserDTO Login(string email, string password)
        {
            UserDTO userDTO = new UserDTO();
            MySqlConnection databaseConnection = new MySqlConnection("Datasource=127.0.0.1;port=3306;username=root;password=;database= quizapp;");
            MySqlCommand getUserData = new MySqlCommand("SELECT * FROM user WHERE email=@val1 AND password=@val2", databaseConnection);
            getUserData.Parameters.AddWithValue("@val1", email);
            getUserData.Parameters.AddWithValue("@val2", password);
            Utility.Check_databaseConnectionState(databaseConnection);
            try
            {
                databaseConnection.Open();
                getUserData.Prepare();
                var executeString = getUserData.ExecuteReader();
                while (executeString.Read())
                {
                    userDTO.Unique_id = executeString.GetString(0);
                    userDTO.First_Name = executeString.GetString(1);
                    userDTO.Last_Name = executeString.GetString(2);
                    userDTO.Email = executeString.GetString(3);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e.Message);
            }
            databaseConnection.Close();
            return userDTO;
        }
    }
}
