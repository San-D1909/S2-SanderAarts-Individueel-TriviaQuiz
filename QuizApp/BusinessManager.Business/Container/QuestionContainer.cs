﻿using Newtonsoft.Json;
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
        public GetQuestionIDRepository getQuestionIDRepository
        {
            get
            {
                return QuestionIDRepository;
            }
            set
            {
                QuestionIDRepository = value;
            }
        }
        public GetQuestionDataRepository getQuestionDataRepository
        {
            get
            {
                return QuestionDataRepository;
            }
            set
            {
                QuestionDataRepository = value;
            }
        }
        private GetQuestionDataRepository QuestionDataRepository = new GetQuestionDataRepository();
        private GetQuestionIDRepository QuestionIDRepository = new GetQuestionIDRepository();
        public QuestionModel FillQuestionModel(APIRequestModel apiRequestModel)
        {//Get question from API or DB
            QuestionModel questionModel = FetchQuestionFromAPI(apiRequestModel);
            if (questionModel.Question == null)
            {//Checks if API responded with a question otherwise uses code below to get one from the DB.
                questionModel = new QuestionModel(getQuestionDataRepository.SelectQuestionDatabase(apiRequestModel.Difficulty, apiRequestModel.Category));
            }
            return questionModel;
        }
        public QuestionModel FetchQuestionFromAPI(APIRequestModel apiRequestModel)
        {
            //Creates a variable URL based on user input.
            string requestString = "" + apiRequestModel.BaseURL + "amount=" + apiRequestModel.Amount + "&category=" + apiRequestModel.Category + "&difficulty = medium" + "&type=" + apiRequestModel.Type + "";
            string rawJSON = getQuestionDataRepository.SelectJSONFromAPI(requestString);
            QuestionModel questionModel = JsonConvert.DeserializeObject<QuestionModel>(rawJSON);
            getQuestionDataRepository.InsertQuestionDatabase(questionModel.Question, questionModel.Incorrect_Answers, questionModel.Correct_Answer, apiRequestModel.Difficulty, apiRequestModel.Category);
            return questionModel;
        }
        public List<string> SelectQuestionIDAddToQuestionList(string question, List<string> list)
        {//Searches in the DB for the ID of the current question and adds it to the list
            list.Add(getQuestionIDRepository.SelectQuestionIDAddToQuestionList(question).ToString());
            return list;
        }
    }
}
