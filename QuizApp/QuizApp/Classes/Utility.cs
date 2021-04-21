using MySql.Data.MySqlClient;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizApp.Classes
{
    public class Utility
    {
        public static List<T> Shuffle<T>(List<T> list)
        {//Creates list with correct answer at random index
            Random random = new Random();
            var newList = list.OrderBy(x => random.Next(0, 3)).ToList();
            return newList;
        }
        public static string Get_UserName(string user_ID)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DB_Credentials.DbConnectionString);
            MySqlCommand Get_Question_ID = new MySqlCommand("SELECT `firstname` FROM `user` WHERE `unique_id` ='" + user_ID + "'", databaseConnection);
            List<string> results = Database.GetData(Get_Question_ID, databaseConnection);
            return results[0];
        }
    }
}