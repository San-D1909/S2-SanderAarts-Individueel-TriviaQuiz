using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    public interface IScoreboardContext
    {
        IEnumerable<ScoreboardDTO> Get_Scoreboard_Data(string difficulty, int category, string timeSpan);
    }
}
