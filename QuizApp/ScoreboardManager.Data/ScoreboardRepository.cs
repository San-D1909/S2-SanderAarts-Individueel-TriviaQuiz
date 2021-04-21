using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardManager.Data
{
    public class ScoreboardRepository
    {
        private IScoreboardContext context;
        public ScoreboardRepository(IScoreboardContext context)
        {
            this.context = context;
        }
        public List<ScoreboardDTO> Get_Scoreboard(string difficulty, int category, string timeSpan)
        {
            return context.Get_Scoreboard_Data(difficulty, category, timeSpan).ToList();
        }
    }
}
