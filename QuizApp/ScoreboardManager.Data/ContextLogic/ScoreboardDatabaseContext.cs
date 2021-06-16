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
                category = 15;
                difficulty = "easy";
            }
            DateTime now = DateTime.Now;
            DateTime startDate = now;
            switch (timeSpan)
            {
                case "PastWeek":
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
            return ListScoreboardData;
        }
        public List<ScoreboardDTO> ConvertToList(List<string> scoreboardID, List<ScoreboardDTO> ScoreboardData)
        {
            foreach (string ID in scoreboardID)
            {
                MySqlCommand GetScoreboardID = new MySqlCommand("SELECT * FROM `scoreboard` WHERE `id` = @val1");
                GetScoreboardID.Parameters.AddWithValue("@val1", ID);
                var results = DatabaseClass.GetData(GetScoreboardID, true);
                ScoreboardData.Add(new ScoreboardDTO(results[0], results[1], results[2], results[3], results[4], results[5], results[6], Convert.ToDateTime(results[7])));
            }
            foreach (ScoreboardDTO user in ScoreboardData)
            {
                user.FirstName = GetNameFromUniqueID(Convert.ToString(user.UserID));
            }
            return ScoreboardData;
        }
        private static string GetNameFromUniqueID(string user_ID)
        {
            MySqlCommand GetFirstNameCommand = new MySqlCommand("SELECT `firstname` FROM `user` WHERE `unique_id` = @val1");
            GetFirstNameCommand.Parameters.AddWithValue("@val1", user_ID);
            List<string> results = DatabaseClass.GetData(GetFirstNameCommand, true);
            return results[0];
        }
    }
}
