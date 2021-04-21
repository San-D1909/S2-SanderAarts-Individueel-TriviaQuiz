using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardManager.Data
{
    interface IScoreboardContext
    {
        IEnumerable<ScoreboardDTO> Get_Scoreboard_Data();
        IEnumerable<ScoreboardDTO> Get_Empty_Input();
    }
}
