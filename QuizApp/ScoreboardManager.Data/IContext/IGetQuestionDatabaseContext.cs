using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    public interface IGetQuestionDatabaseContext
    {
        QuestionDTO Get_Question_From_Database(string difficulty, string category);
    }
}
