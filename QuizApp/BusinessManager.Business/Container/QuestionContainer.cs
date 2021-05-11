using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManager.Business
{
    class QuestionContainer
    {
        public static QuestionModel Fill_QuestionModel(APIRequestModel apiRequestModel)
        {
            //Creates a variable URL based on user input.
            string requestString = "" + apiRequestModel.BaseURL + "amount=" + apiRequestModel.Amount + "&category=" + apiRequestModel.Category + "&difficulty = medium" + "&type=" + apiRequestModel.Type + "";
            string rawJSON = DataManager.Data.GetQuestionDataRepository.Get_JSON_From_API(requestString);
            QuestionModel questionModel = JsonConvert.DeserializeObject<QuestionModel>(rawJSON);
            if (questionModel.Question != null)
            {
                QuestionBackup.Store_question(questionModel, apiRequestModel);
                return questionModel;
            }
            else
            {
                questionModel = QuestionBackup.Get_Question_Database(apiRequestModel.Difficulty, apiRequestModel.Category, questionModel);
                return questionModel;
            }
        }
    }
}
