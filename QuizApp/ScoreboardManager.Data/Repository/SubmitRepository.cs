using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardManager.Data
{
    public class SubmitRepository
    {
        private ISubmitContext context;
        public SubmitRepository(ISubmitContext context)
        {
            this.context = context;
        }
        public SubmitRepository()
        {
            this.context = new SubmitDatabaseContext();
        }
        public void Submit_To_Scoreboard(SubmitDTO submitDTO)
        {
            context.Submit_To_Scoreboard(submitDTO);
        }
    }
}
