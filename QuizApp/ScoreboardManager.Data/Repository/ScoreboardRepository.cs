using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    public class ScoreboardRepository
    {
        private IScoreboardContext context;
        public ScoreboardRepository()
        {
            this.context = new ScoreboardDatabaseContext();
        }
        public List<ScoreboardDTO> SelectScoreboardData(string difficulty, int category, string timeSpan)
        {
            return context.SelectScoreboardData(difficulty, category, timeSpan).ToList();
        }
    }
}
