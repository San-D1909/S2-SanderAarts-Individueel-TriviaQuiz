using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    class RegisterDatabaseContext : IRegisterDatabaseContext
    {
        bool IRegisterDatabaseContext.InsertUser(UserDTO userDTO)
        {
            MySqlCommand storeData = new MySqlCommand("INSERT INTO `user`(`firstname`, `lastname`, `email`, `password`, `birth_day`) VALUES (@val1,@val2,@val3,@val4,@val5);");
            storeData.Parameters.AddWithValue("@val1", userDTO.FirstName);
            storeData.Parameters.AddWithValue("@val2", userDTO.LastName);
            storeData.Parameters.AddWithValue("@val3", userDTO.Email);
            storeData.Parameters.AddWithValue("@val4", userDTO.Password);
            storeData.Parameters.AddWithValue("@val5", userDTO.BirthDay);
            if (DatabaseClass.StoreData(storeData, true))
            {
                return true;
            }
            return false;
        }
    }
}
