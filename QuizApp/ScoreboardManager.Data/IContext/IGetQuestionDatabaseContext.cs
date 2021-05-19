using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    public interface IGetQuestionDatabaseContext
    {
        QuestionDTO SelectQuestionDatabase(string difficulty, string category);
    }
}
