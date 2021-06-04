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
        public IGetQuestionAPIContext ApiContext
        {
            get
            {
                return apiContext;
            }
            set
            {
                apiContext = value;
            }
        }
        public IGetQuestionDatabaseContext DatabaseContext
        {
            get
            {
                return databaseContext;
            }
            set
            {
                databaseContext = value;
            }
        }

        public QuestionDTO SelectQuestionDatabase(string difficulty, string category)
        {
            DatabaseContext = new GetQuestionDatabaseContext();
            return DatabaseContext.SelectQuestionDatabase(difficulty, category);
        }

        public string SelectJSONFromAPI(string requestString)
        {
            ApiContext = new GetQuestionAPIContext();
            return ApiContext.SelectJSONFromAPI(requestString);
        }
        public bool InsertQuestionDatabase(string question, List<string> incorrect_Answers, string correct_Answer, string difficulty, string category)
        {
            QuestionDTO questionDTO = new QuestionDTO(question,incorrect_Answers,correct_Answer);
            ApiContext = new GetQuestionAPIContext();
            return ApiContext.InsertQuestionDatabase(questionDTO, difficulty, category);
        }
    }
}
