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

        public QuestionDTO SelectQuestionDatabase(string difficulty, string category)
        {
            databaseContext = new GetQuestionDatabaseContext();
            return databaseContext.SelectQuestionDatabase(difficulty, category);
        }

        public string SelectJSONFromAPI(string requestString)
        {
            apiContext = new GetQuestionAPIContext();
            return apiContext.SelectJSONFromAPI(requestString);
        }
        public bool InsertQuestionDatabase(string question, List<string> incorrect_Answers, string correct_Answer, string difficulty, string category)
        {
            QuestionDTO questionDTO = new QuestionDTO(question,incorrect_Answers,correct_Answer);
            apiContext = new GetQuestionAPIContext();
            return apiContext.InsertQuestionDatabase(questionDTO, difficulty, category);
        }
    }
}
