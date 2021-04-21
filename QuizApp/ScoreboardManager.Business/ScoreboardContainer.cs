using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardManager.Business
{
    public class ScoreboardContainer
    {
        public List<ScoreboardDTO> Get_Scoreboard_Data(string difficulty, int category, string timeSpan)
        {
            List<ScoreboardDTO> scoreboard = new List<ScoreboardDTO>();
            ScoreboardManager.Data.ScoreboardRepository repo = new ScoreboardManager.Data.ScoreboardRepository();
            var scoreboardDTO = repo.Get_Scoreboard(difficulty, category, timeSpan);
            foreach(var DTO in scoreboardDTO)
            {
                scoreboard.Add(new ScoreboardDTO(DTO));
            }
            return scoreboard;
        }
    }
}
