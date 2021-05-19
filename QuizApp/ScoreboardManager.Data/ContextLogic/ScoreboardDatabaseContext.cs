using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    class ScoreboardDatabaseContext : IScoreboardContext
    {
        public IEnumerable<ScoreboardDTO> GetScoreboardData(string difficulty, int category, string timeSpan)
        {
            List<ScoreboardDTO> Scoreboard_Data = new List<ScoreboardDTO>();
            if (difficulty == "0" || category == 0)
            {
                Scoreboard_Data = EmptyUserInput(difficulty, category, Scoreboard_Data);
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
                MySqlCommand Get_Scoreboard_ID = new MySqlCommand("SELECT `id` FROM `scoreboard` WHERE `category` = " + category + " AND `difficulty` LIKE '" + difficulty + "' AND `date` BETWEEN '" + startString + "' AND '" + now.ToString("yyyy-MM-dd HH:mm:ss") + "' ORDER BY score DESC LIMIT 5");
                List<string> scoreboardID= Utility.GetData(Get_Scoreboard_ID);
                Scoreboard_Data = ListWithRequestedScores(scoreboardID, Scoreboard_Data);
            }
            return (Scoreboard_Data);
        }
        public List<ScoreboardDTO> EmptyUserInput(string difficulty, int category, List<ScoreboardDTO> Scoreboard_Data)
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
            MySqlCommand Get_Question_ID = new MySqlCommand(command);
            List<string> scoreboardID = Utility.GetData(Get_Question_ID);
            Scoreboard_Data = ListWithRequestedScores(scoreboardID, Scoreboard_Data);
            return Scoreboard_Data;
        }
        public List<ScoreboardDTO> ListWithRequestedScores(List<string> scoreboardID, List<ScoreboardDTO> Scoreboard_Data)
        {
            foreach (string ID in scoreboardID)
            {
                MySqlCommand Get_Question_ID = new MySqlCommand("SELECT * FROM `scoreboard` WHERE `id` = " + ID + "");
                var results = Utility.GetData(Get_Question_ID);
                Scoreboard_Data.Add(new ScoreboardDTO(results[0], results[1], results[2], results[3], results[4], results[5], results[6], results[7]));
            }
            foreach (ScoreboardDTO user in Scoreboard_Data)
            {
                user.First_Name = GetNameFromUniqueID(Convert.ToString(user.User_ID));
            }
            return Scoreboard_Data;
        }
        private static string GetNameFromUniqueID(string user_ID)
        {
            MySqlCommand Get_Question_ID = new MySqlCommand("SELECT `firstname` FROM `user` WHERE `unique_id` ='" + user_ID + "'");
            List<string> results = Utility.GetData(Get_Question_ID);
            return results[0];
        }
    }
}
