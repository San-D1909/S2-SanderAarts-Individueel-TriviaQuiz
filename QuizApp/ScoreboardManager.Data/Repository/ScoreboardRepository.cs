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
        public IScoreboardContext Context
        {
            get
            {
                return context;
            }
            set
            {
                context = value;
            }
        }
        public ScoreboardRepository()
        {
            this.Context = new ScoreboardDatabaseContext();
        }
        public List<ScoreboardDTO> SelectScoreboardData(string difficulty, int category, string timeSpan)
        {
            return Context.SelectScoreboardData(difficulty, category, timeSpan).ToList();
        }
    }
}
