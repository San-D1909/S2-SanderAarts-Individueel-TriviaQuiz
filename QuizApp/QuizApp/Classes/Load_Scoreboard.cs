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
        public static List<string> Get_ScoreBoard_Data(string difficulty, int category, string timeSpan)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DB_Credentials.DbConnectionString);
            if (difficulty=="0"&&category==0)
            {
                MySqlCommand Get_Question_ID = new MySqlCommand("SELECT * FROM `scoreboard` WHERE `category` = " + 15 + " AND `difficulty` = '" + "medium" + "' ORDER BY score DESC LIMIT 5", databaseConnection);
                List<string> results = Database.GetData(Get_Question_ID, databaseConnection);
                return (results);
            }
            else
            {
                
                DateTime now = DateTime.Now;
                string nowString = now.ToString("yyyy-MM-dd HH:mm:ss");
                DateTime startDate = DateTime.Now;
                string startString = "";
                if (timeSpan == "PastWeek")
                {
                    startDate = now.AddDays(-7);
                    startString = startDate.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else if (timeSpan == "PastMonth")
                {
                    startDate = now.AddDays(-30);
                    startString = startDate.ToString("yyyy-MM-dd HH:mm:ss");
                }
                MySqlCommand Get_Question_ID = new MySqlCommand("SELECT * FROM `scoreboard` WHERE `category` = " + category + " AND `difficulty` LIKE '" + difficulty + "' AND `date` BETWEEN '" + startString + "' AND '" + nowString + "' ORDER BY score DESC LIMIT 5", databaseConnection);
                if (timeSpan == "AllTime")
                {
                    Get_Question_ID = new MySqlCommand("SELECT * FROM `scoreboard` WHERE `category` = " + category + " AND `difficulty` = '" + difficulty + "' ORDER BY score DESC LIMIT 5", databaseConnection);
                }
                List<string> results = Database.GetData(Get_Question_ID, databaseConnection);
                return (results);
            }
        }
    }
}