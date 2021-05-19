using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManager.Data;

namespace BusinessManager.Business
{
    public class QuestionContainer
    {
        public static QuestionModel FillQuestionModel(APIRequestModel apiRequestModel)
        {
            GetQuestionDataRepository repo = new GetQuestionDataRepository();
            //Creates a variable URL based on user input.
            string requestString = "" + apiRequestModel.BaseURL + "amount=" + apiRequestModel.Amount + "&category=" + apiRequestModel.Category + "&difficulty = medium" + "&type=" + apiRequestModel.Type + "";
            string rawJSON = repo.SelectJSONFromAPI(requestString);
            QuestionModel questionModel = JsonConvert.DeserializeObject<QuestionModel>(rawJSON);
            if (questionModel.Question != null)
            {
                repo.InsertQuestionDatabase(questionModel.Question,questionModel.Incorrect_Answers,questionModel.Correct_Answer, apiRequestModel.Difficulty,apiRequestModel.Category);
                return questionModel;
            }
            else
            {
                questionModel = new QuestionModel(repo.SelectQuestionDatabase(apiRequestModel.Difficulty, apiRequestModel.Category));
                return questionModel;
            }
        }
    }
}
