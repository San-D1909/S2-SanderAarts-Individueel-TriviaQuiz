using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizApp;

namespace ScoreboardManager.Data
{
    class ScoreboardDatabaseContext : IScoreboardContext
    {
        public IEnumerable<ScoreboardDTO> Get_Scoreboard_Data(string difficulty, int category, string timeSpan)
        {
            List<ScoreboardDTO> Scoreboard_Data = new List<ScoreboardDTO>();
            MySqlConnection databaseConnection = new MySqlConnection(QuizApp.Models.DB_Credentials.DbConnectionString);
            if (difficulty == "0" || category == 0)
            {
                Scoreboard_Data = Get_Empty_Input(difficulty, category, databaseConnection, Scoreboard_Data);
                return Scoreboard_Data;
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
                MySqlCommand Get_Question_ID = new MySqlCommand("SELECT * FROM `scoreboard` WHERE `category` = " + category + " AND `difficulty` LIKE '" + difficulty + "' AND `date` BETWEEN '" + startString + "' AND '" + now.ToString("yyyy-MM-dd HH:mm:ss") + "' ORDER BY score DESC LIMIT 5", databaseConnection);
                List<string> results = Database.GetData(Get_Question_ID, databaseConnection);
                Scoreboard_Data = Fill_List(results, Scoreboard_Data);
                return (Scoreboard_Data);
            }
        }
        public List<ScoreboardDTO> Get_Empty_Input(string difficulty, int category, MySqlConnection databaseConnection, List<ScoreboardDTO> Scoreboard_Data)
        {
            string command = "";
            if (difficulty == "0" && category == 0)
            {
                command = "SELECT * FROM `scoreboard` ORDER BY score DESC LIMIT 5";
            }
            else if (category == 0)
            {
                command = "SELECT * FROM `scoreboard` WHERE `difficulty` = '" + difficulty + "' ORDER BY score DESC LIMIT 5";
            }
            else if (difficulty == "0")
            {
                command = "SELECT * FROM `scoreboard` WHERE `category` = " + category + " ORDER BY score DESC LIMIT 5";
            }
            MySqlCommand Get_Question_ID = new MySqlCommand(command, databaseConnection);
            List<string> results = Database.GetData(Get_Question_ID, databaseConnection);
            Scoreboard_Data = Fill_List(results, Scoreboard_Data);
            return Scoreboard_Data;
        }


        public List<ScoreboardDTO> Fill_List(List<string>results, List<ScoreboardDTO> Scoreboard_Data)
        {
            if (results.Count() >= 7)
            {
                ScoreboardDTO scoreboardDTO = new ScoreboardDTO(results[0], results[1], results[2], results[3], results[4], results[5], results[6], Convert.ToDateTime(results[7]));
                Scoreboard_Data.Add(scoreboardDTO);
            }
            if (results.Count() >= 15)
            {
                ScoreboardDTO scoreboardDTO = new ScoreboardDTO(results[8], results[9], results[10], results[11], results[12], results[13], results[14], Convert.ToDateTime(results[15]));
                Scoreboard_Data.Add(scoreboardDTO);
            }
            if (results.Count() >= 23)
            {
                ScoreboardDTO scoreboardDTO = new ScoreboardDTO(results[16], results[17], results[18], results[19], results[20], results[21], results[22], Convert.ToDateTime(results[23]));
                Scoreboard_Data.Add(scoreboardDTO);
            }
            if (results.Count() >= 31)
            {
                ScoreboardDTO scoreboardDTO = new ScoreboardDTO(results[24], results[25], results[26], results[27], results[28], results[29], results[30], Convert.ToDateTime(results[31]));
                Scoreboard_Data.Add(scoreboardDTO);
            }
            if (results.Count() >= 39)
            {
                ScoreboardDTO scoreboardDTO = new ScoreboardDTO(results[32], results[33], results[34], results[35], results[36], results[37], results[38], Convert.ToDateTime(results[39]));
                Scoreboard_Data.Add(scoreboardDTO);
            }
            foreach(ScoreboardDTO user in Scoreboard_Data)
            {
                user.First_Name = QuizApp.Classes.Utility.Get_UserName(Convert.ToString(user.User_ID));
            }
            return Scoreboard_Data;
        }
    }
}
