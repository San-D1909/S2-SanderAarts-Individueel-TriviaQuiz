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
        public ISubmitContext Context
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
        public SubmitRepository(ISubmitContext context)
        {
            this.Context = context;
        }
        public SubmitRepository()
        {
            this.Context = new SubmitDatabaseContext();
        }
        public bool InsertToScoreboard(SubmitDTO submitDTO)
        {
            return Context.InsertToScoreboard(submitDTO);
        }
    }
}
