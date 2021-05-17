using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    class RegisterDatabaseContext: IRegisterDatabaseContext
    {
        bool IRegisterDatabaseContext.StoreUser(UserDTO userDTO)
        {
            string StoreDataString = "INSERT INTO `user`(`firstname`, `lastname`, `email`, `password`, `birth_day`) VALUES (@val1,@val2,@val3,@val4,@val5);";
            MySqlConnection databaseConnection = new MySqlConnection("Datasource=127.0.0.1;port=3306;username=root;password=;database= quizapp;");
            MySqlCommand storeData = new MySqlCommand(StoreDataString, databaseConnection);
            storeData.Parameters.AddWithValue("@val1", userDTO.First_Name);
            storeData.Parameters.AddWithValue("@val2", userDTO.Last_Name);
            storeData.Parameters.AddWithValue("@val3", userDTO.Email);
            storeData.Parameters.AddWithValue("@val4", userDTO.Password);
            storeData.Parameters.AddWithValue("@val5", userDTO.Birth_Day);
            if (Utility.StoreData(storeData, databaseConnection, true))
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
