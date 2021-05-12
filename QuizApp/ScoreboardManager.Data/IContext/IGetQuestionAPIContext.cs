using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    public interface IGetQuestionAPIContext
    {
        string Get_JSON_From_API(string requestString);
        bool Store_question(QuestionDTO questionDTO, string difficulty, string category);
    }
}
