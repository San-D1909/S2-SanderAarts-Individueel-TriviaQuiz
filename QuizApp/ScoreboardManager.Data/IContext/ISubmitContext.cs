using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    public interface ISubmitContext
    {
        void Submit_To_Scoreboard(SubmitDTO submitDTO);

        SubmitDTO Get_Unique_Question_ID(SubmitDTO submitDTO);
    }
}
