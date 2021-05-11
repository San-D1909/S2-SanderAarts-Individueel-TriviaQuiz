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
    }
}
