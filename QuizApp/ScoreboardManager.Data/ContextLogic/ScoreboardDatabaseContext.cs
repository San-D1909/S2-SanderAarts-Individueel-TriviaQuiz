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
        public IEnumerable<ScoreboardDTO> SelectScoreboardData(string difficulty, int category, string timeSpan)
        {
            List<ScoreboardDTO> ListScoreboardData = new List<ScoreboardDTO>();
            if (difficulty == "0" || category == 0)
            {
                ListScoreboardData = EmptyUserInput(difficulty, category, ListScoreboardData);
            }
            else
            {
                DateTime now = DateTime.Now;
                DateTime startDate = now;
                switch (timeSpan)
                {
                    case "Pastweek":
                        startDate = now.AddDays(-7);
                        break;
                    case "PastMonth":
                        startDate = now.AddDays(-30);
                        break;
                    case "AllTime":
                        startDate = now.AddYears(-40);
                        break;
                }
                string startString = startDate.ToString("yyyy-MM-dd HH:mm:ss");
                MySqlCommand SelectQuestionIDCommand = new MySqlCommand("SELECT `id` FROM `scoreboard` WHERE `category` = @val1 AND `difficulty` LIKE @val2 AND `date` BETWEEN @val3 AND @val4 ORDER BY score DESC LIMIT 5");
                SelectQuestionIDCommand.Parameters.AddWithValue("@val1", category);
                SelectQuestionIDCommand.Parameters.AddWithValue("@val2", difficulty);
                SelectQuestionIDCommand.Parameters.AddWithValue("@val3", startString);
                SelectQuestionIDCommand.Parameters.AddWithValue("@val4", now.ToString("yyyy-MM-dd HH:mm:ss"));
                List<string> scoreboardID = DatabaseClass.GetData(SelectQuestionIDCommand, true);
                ListScoreboardData = ConvertToList(scoreboardID, ListScoreboardData);
            }
            return ListScoreboardData;
        }
        public List<ScoreboardDTO> EmptyUserInput(string difficulty, int category, List<ScoreboardDTO> Scoreboard_Data)
        {
            List<string> scoreboardID = new List<string>();
            if (difficulty == "0" && category == 0)
            {
                MySqlCommand command = new MySqlCommand("SELECT `id` FROM `scoreboard` ORDER BY score DESC LIMIT 5");
                scoreboardID = DatabaseClass.GetData(command);
            }
            else if (category == 0)
            {
                MySqlCommand command = new MySqlCommand("SELECT `id` FROM `scoreboard` WHERE `difficulty` = '" + difficulty + "' ORDER BY score DESC LIMIT 5");
                command.Parameters.AddWithValue("@val1", difficulty);
                scoreboardID = DatabaseClass.GetData(command, true);
            }
            else if (difficulty == "0")
            {
                MySqlCommand command = new MySqlCommand("SELECT `id` FROM `scoreboard` WHERE `category` = " + category + " ORDER BY score DESC LIMIT 5");
                command.Parameters.AddWithValue("@val1", category);
                scoreboardID = DatabaseClass.GetData(command, true);
            }
            return ConvertToList(scoreboardID, Scoreboard_Data);
        }
        public List<ScoreboardDTO> ConvertToList(List<string> scoreboardID, List<ScoreboardDTO> Scoreboard_Data)
        {
            foreach (string ID in scoreboardID)
            {
                MySqlCommand Get_Question_ID = new MySqlCommand("SELECT * FROM `scoreboard` WHERE `id` = @val1");
                Get_Question_ID.Parameters.AddWithValue("@val1", ID);
                var results = DatabaseClass.GetData(Get_Question_ID, true);
                Scoreboard_Data.Add(new ScoreboardDTO(results[0], results[1], results[2], results[3], results[4], results[5], results[6], results[7]));
            }
            foreach (ScoreboardDTO user in Scoreboard_Data)
            {
                user.FirstName = GetNameFromUniqueID(Convert.ToString(user.UserID));
            }
            return Scoreboard_Data;
        }
        private static string GetNameFromUniqueID(string user_ID)
        {
            MySqlCommand Get_Question_ID = new MySqlCommand("SELECT `firstname` FROM `user` WHERE `unique_id` = @val1");
            Get_Question_ID.Parameters.AddWithValue("@val1", user_ID);
            List<string> results = DatabaseClass.GetData(Get_Question_ID, true);
            return results[0];
        }
    }
}
