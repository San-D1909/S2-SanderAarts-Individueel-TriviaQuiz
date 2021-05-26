using DataManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Business
{
    public class ScoreboardContainer
    {

        public List<ScoreboardDTO> SelectScoreboardData(string difficulty, int category, string timeSpan)
        {
            List<ScoreboardDTO> scoreboard = new List<ScoreboardDTO>();
            ScoreboardRepository repo = new ScoreboardRepository();
            var scoreboardDTO = repo.SelectScoreboardData(difficulty, category, timeSpan);
            foreach (var DTO in scoreboardDTO)
            {
                scoreboard.Add(new ScoreboardDTO(DTO));
            }
            return scoreboard;
        }
        public bool InsertToScoreboard(int category, string difficulty, int questionAmount, List<string> questionList, int uniqueID, int finalScore)
        {
            SubmitDTO submitDTO = new SubmitDTO { Category = category, Difficulty = difficulty, QuestionAmount = questionAmount, QuestionList = questionList, UniqueID = uniqueID, Score = finalScore };
            SubmitRepository repo = new SubmitRepository();
            if(repo.InsertToScoreboard(submitDTO))
            {
                return true;
            }
            return false;
        }
    }
}

