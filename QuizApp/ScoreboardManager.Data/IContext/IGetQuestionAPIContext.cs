using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    public interface IGetQuestionAPIContext
    {
        string SelectJSONFromAPI(string requestString);
        bool InsertQuestionDatabase(QuestionDTO questionDTO, string difficulty, string category);
    }
}
