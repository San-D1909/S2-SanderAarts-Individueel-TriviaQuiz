using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
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
        public void InsertToScoreboard(SubmitDTO submitDTO)
        {
            context.InsertToScoreboard(submitDTO);
        }
    }
}
