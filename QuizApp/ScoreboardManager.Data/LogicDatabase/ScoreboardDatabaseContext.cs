using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardManager.Data
{
    class ScoreboardDatabaseContext : IScoreboardContext
    {
        public IEnumerable<ScoreboardDTO> Get_Scoreboard_Data(string difficulty, int category, string timeSpan)
        {
            List<ScoreboardDTO> Scoreboard_Data = new List<ScoreboardDTO>();
            MySqlConnection databaseConnection = new MySqlConnection("Datasource=127.0.0.1;port=3306;username=root;password=;database= quizapp;");
            if (difficulty == "0" || category == 0)
            {
                Scoreboard_Data = Get_Empty_Input(difficulty, category, databaseConnection, Scoreboard_Data);
            }
            else
            {
                DateTime now = DateTime.Now;
                DateTime startDate = now;
                if (timeSpan == "PastWeek")
                {
                    startDate = now.AddDays(-7);
                }
                else if (timeSpan == "PastMonth")
                {
                    startDate = now.AddDays(-30);
                }
                else if (timeSpan == "AllTime")
                {
                    startDate = now.AddYears(-40);
                }
                string startString = startDate.ToString("yyyy-MM-dd HH:mm:ss");
                MySqlCommand Get_Scoreboard_ID = new MySqlCommand("SELECT `id` FROM `scoreboard` WHERE `category` = " + category + " AND `difficulty` LIKE '" + difficulty + "' AND `date` BETWEEN '" + startString + "' AND '" + now.ToString("yyyy-MM-dd HH:mm:ss") + "' ORDER BY score DESC LIMIT 5", databaseConnection);
                List<string> scoreboardID= GetData(Get_Scoreboard_ID, databaseConnection);
                Scoreboard_Data = Fill_List(scoreboardID, Scoreboard_Data,databaseConnection);
            }
            return (Scoreboard_Data);
        }
        public List<ScoreboardDTO> Get_Empty_Input(string difficulty, int category, MySqlConnection databaseConnection, List<ScoreboardDTO> Scoreboard_Data)
        {
            string command = "";
            if (difficulty == "0" && category == 0)
            {
                command = "SELECT `id` FROM `scoreboard` ORDER BY score DESC LIMIT 5";
            }
            else if (category == 0)
            {
                command = "SELECT `id` FROM `scoreboard` WHERE `difficulty` = '" + difficulty + "' ORDER BY score DESC LIMIT 5";
            }
            else if (difficulty == "0")
            {
                command = "SELECT `id` FROM `scoreboard` WHERE `category` = " + category + " ORDER BY score DESC LIMIT 5";
            }
            MySqlCommand Get_Question_ID = new MySqlCommand(command, databaseConnection);
            List<string> scoreboardID = GetData(Get_Question_ID, databaseConnection);
            Scoreboard_Data = Fill_List(scoreboardID, Scoreboard_Data, databaseConnection);
            return Scoreboard_Data;
        }
        public List<ScoreboardDTO> Fill_List(List<string> scoreboardID, List<ScoreboardDTO> Scoreboard_Data, MySqlConnection databaseConnection)
        {
            foreach (string ID in scoreboardID)
            {
                MySqlCommand Get_Question_ID = new MySqlCommand("SELECT * FROM `scoreboard` WHERE `id` = " + ID + "", databaseConnection);
                var results = GetData(Get_Question_ID, databaseConnection);
                Scoreboard_Data.Add(new ScoreboardDTO(results[0], results[1], results[2], results[3], results[4], results[5], results[6], results[7]));
            }
            foreach (ScoreboardDTO user in Scoreboard_Data)
            {
                user.First_Name = Get_UserName(Convert.ToString(user.User_ID));
            }
            return Scoreboard_Data;
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
        public static void Check_databaseConnectionState(MySqlConnection databaseConnection)
        {
            if (databaseConnection.State == System.Data.ConnectionState.Open)
            {
                databaseConnection.Close();
            }
        }
        public static string Get_UserName(string user_ID)
        {
            MySqlConnection databaseConnection = new MySqlConnection("Datasource=127.0.0.1;port=3306;username=root;password=;database= quizapp;");
            MySqlCommand Get_Question_ID = new MySqlCommand("SELECT `firstname` FROM `user` WHERE `unique_id` ='" + user_ID + "'", databaseConnection);
            List<string> results = GetData(Get_Question_ID, databaseConnection);
            return results[0];
        }
    }
}
