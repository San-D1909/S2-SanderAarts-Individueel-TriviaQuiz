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
        public IEnumerable<ScoreboardDTO> Get_Empty_Input()
        {
            List<ScoreboardDTO> Scoreboard_Data = new List<ScoreboardDTO>();
            MySqlConnection databaseConnection = new MySqlConnection(QuizApp.Models.DB_Credentials.DbConnectionString);
            string command = "SELECT * FROM `scoreboard` ORDER BY score DESC LIMIT 5";
            MySqlCommand Get_Question_ID = new MySqlCommand(command, databaseConnection);
            List<string> results = Database.GetData(Get_Question_ID, databaseConnection);

                if(results.Count() > 7 )
                {
                    ScoreboardDTO scoreboardDTO = new ScoreboardDTO(results[0], results[1], results[2], results[3], results[4], results[5], results[6], Convert.ToDateTime(results[7]));
                    Scoreboard_Data.Add(scoreboardDTO);
                }
                if (results.Count() > 15)
                {
                    ScoreboardDTO scoreboardDTO = new ScoreboardDTO(results[8], results[9], results[10], results[11], results[12], results[13], results[14], Convert.ToDateTime(results[15]));
                    Scoreboard_Data.Add(scoreboardDTO);
                }
            if (results.Count() > 23)
            {
                ScoreboardDTO scoreboardDTO = new ScoreboardDTO(results[16], results[17], results[18], results[19], results[20], results[21], results[22], Convert.ToDateTime(results[23]));
                Scoreboard_Data.Add(scoreboardDTO);
            }
            if (results.Count() > 31)
            {
                ScoreboardDTO scoreboardDTO = new ScoreboardDTO(results[24], results[25], results[26], results[27], results[28], results[29], results[30], Convert.ToDateTime(results[31]));
                Scoreboard_Data.Add(scoreboardDTO);
            }
            if (results.Count() > 39)
            {
                ScoreboardDTO scoreboardDTO = new ScoreboardDTO(results[32], results[33], results[34], results[35], results[36], results[37], results[38], Convert.ToDateTime(results[39]));
                Scoreboard_Data.Add(scoreboardDTO);
            }
            return Scoreboard_Data;
        }

        public IEnumerable<ScoreboardDTO> Get_Scoreboard_Data()
        {
            throw new NotImplementedException();
        }
    }
}
