using MySql.Data.MySqlClient;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApp.Classes
{
    public class Load_Scoreboard
    {
        public static List<string> Get_ScoreBoard_Data(string difficulty, int category)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DB_Credentials.DbConnectionString);
            MySqlCommand Get_Question_ID = new MySqlCommand("SELECT * FROM `scoreboard` WHERE `category` = "+category+" AND `difficulty` = '"+ difficulty + "' ORDER BY score DESC LIMIT 5", databaseConnection);
            List<string> results = Database.GetData(Get_Question_ID, databaseConnection);
            return(results);
        }
    }
}