using MySql.Data.MySqlClient;
using QuizApp.Models;

namespace QuizApp.Services.Data
{
    public class CheckUserInput
    {
        internal UserModel FindByUser(UserModel user)
        {
            UserModel userModel = QuizApp.Database.Login(user.Email, user.Password, user);
            if (userModel != null)
            {
                return userModel;
            }
            else
            {
                return null;
            }
        }
        internal bool StoreUser(RegisterModel registration)
        {
            string StoreDataString = "INSERT INTO `user`(`firstname`, `lastname`, `email`, `password`,  `adres`, `birth_day`) VALUES (@val1,@val2,@val3,@val4,@val5,@val6);";
            MySqlConnection databaseConnection = new MySqlConnection(DB_Credentials.DbConnectionString);
            MySqlCommand storeData = new MySqlCommand(StoreDataString, databaseConnection);
            storeData.Parameters.AddWithValue("@val1", registration.First_Name);
            storeData.Parameters.AddWithValue("@val2", registration.Last_Name);
            storeData.Parameters.AddWithValue("@val3", registration.Email);
            storeData.Parameters.AddWithValue("@val4", registration.Password);
            storeData.Parameters.AddWithValue("@val5", registration.Adress);
            storeData.Parameters.AddWithValue("@val6", registration.Birth_Day);
            if (Database.StoreData(storeData, databaseConnection, true))
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
