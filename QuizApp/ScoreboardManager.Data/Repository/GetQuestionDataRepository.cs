using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    public class GetQuestionDataRepository
    {
        private IGetQuestionAPIContext apiContext;
        private IGetQuestionDatabaseContext databaseContext;

        public QuestionDTO Get_Question_From_Database(string difficulty, string category, string DbConnectionString)
        {
            databaseContext = new GetQuestionDatabaseContext();
            return databaseContext.Get_Question_From_Database(difficulty, category, DbConnectionString);
        }

        public string Get_JSON_From_API(string requestString)
        {
            apiContext = new GetQuestionAPIContext();
            return apiContext.Get_JSON_From_API(requestString);
        }
        public bool Store_question(string question, List<string> incorrect_Answers, string correct_Answer, string difficulty, string category)
        {
            QuestionDTO questionDTO = new QuestionDTO(question,incorrect_Answers,correct_Answer);
            apiContext = new GetQuestionAPIContext();
            return apiContext.Store_question(questionDTO, difficulty, category);
        }
    }
}
