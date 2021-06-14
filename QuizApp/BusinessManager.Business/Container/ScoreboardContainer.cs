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
        public ScoreboardRepository ScoreboardRepository
        {
            get
            {
                return scoreboardRepository;
            }
            set
            {
                scoreboardRepository = value;
            }
        }
        public SubmitRepository SubmitRepository
        {
            get
            {
                return submitRepository;
            }
            set
            {
                submitRepository = value;
            }
        }
        private ScoreboardRepository scoreboardRepository = new ScoreboardRepository();
        private SubmitRepository submitRepository = new SubmitRepository();
        public List<ScoreboardDTO> SelectScoreboardData(string difficulty, int category, string timeSpan)
        {
            List<ScoreboardDTO> scoreboard = new List<ScoreboardDTO>();
            var scoreboardDTO = ScoreboardRepository.SelectScoreboardData(difficulty, category, timeSpan);
            foreach (var DTO in scoreboardDTO)
            {
                scoreboard.Add(new ScoreboardDTO(DTO));
            }
            return scoreboard;
        }
        public bool InsertToScoreboard(ScoreboardDTO scoreboardDTO)
        {
            SubmitDTO submitDTO = new SubmitDTO { Category = scoreboardDTO.Category, Difficulty = scoreboardDTO.Difficulty, UniqueID = scoreboardDTO.UserID, Score = scoreboardDTO.Score ,QuestionList = scoreboardDTO.QuestionList};
            return SubmitRepository.InsertToScoreboard(submitDTO);
        }
    }
}

