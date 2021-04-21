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
        public void Submit_To_Scoreboard(int category, string difficulty, int question_Amount, List<string> question_List, int unique_ID, int finalScore)
        {
            ScoreboardManager.Data.SubmitDTO submitDTO = new ScoreboardManager.Data.SubmitDTO{ Category = category,Difficulty = difficulty,Question_Amount = question_Amount,Question_List = question_List,Unique_ID = unique_ID,Score= finalScore };
            ScoreboardManager.Data.SubmitRepository repo = new ScoreboardManager.Data.SubmitRepository();
            repo.Submit_To_Scoreboard(submitDTO);
        }
    }
}
