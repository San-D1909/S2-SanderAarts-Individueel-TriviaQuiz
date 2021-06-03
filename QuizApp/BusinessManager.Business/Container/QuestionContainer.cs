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
        public GetQuestionDataRepository getQuestionDataRepository = new GetQuestionDataRepository();
        public GetQuestionIDRepository getQuestionIDRepository = new GetQuestionIDRepository();
        public QuestionModel FillQuestionModel(APIRequestModel apiRequestModel)
        {
            //Creates a variable URL based on user input.
            string requestString = "" + apiRequestModel.BaseURL + "amount=" + apiRequestModel.Amount + "&category=" + apiRequestModel.Category + "&difficulty = medium" + "&type=" + apiRequestModel.Type + "";
            string rawJSON = getQuestionDataRepository.SelectJSONFromAPI(requestString);
            QuestionModel questionModel = JsonConvert.DeserializeObject<QuestionModel>(rawJSON);
            if (questionModel.Question != null)
            {
                getQuestionDataRepository.InsertQuestionDatabase(questionModel.Question, questionModel.Incorrect_Answers, questionModel.Correct_Answer, apiRequestModel.Difficulty, apiRequestModel.Category);
                return questionModel;
            }
            else
            {
                questionModel = new QuestionModel(getQuestionDataRepository.SelectQuestionDatabase(apiRequestModel.Difficulty, apiRequestModel.Category));
                return questionModel;
            }
        }
        public ScoreModel SelectQuestionIDAddToQuestionList(QuestionModel questionModel, ScoreModel scoreModel)
        {
            GetQuestionIDRepository getQuestionIDRepository = new GetQuestionIDRepository();
            int ID = getQuestionIDRepository.SelectQuestionIDAddToQuestionList(questionModel.Question);
            if (scoreModel.QuestionList == null)
            {
                scoreModel.QuestionList  = new List<string> { ID.ToString() };
            }
            else
            {
                scoreModel.QuestionList.Add(ID.ToString());
            }
            return scoreModel;
        }
    }
}
