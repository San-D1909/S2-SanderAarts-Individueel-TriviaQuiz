using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    public interface ISubmitContext
    {
        bool InsertToScoreboard(SubmitDTO submitDTO);
    }
}
