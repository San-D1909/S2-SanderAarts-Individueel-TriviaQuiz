using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    public class QuizController : Controller
    {
        public List<T> Shuffle<T>(List<T> list)
        {//Creates list with correct answer at random index
            
            Random random = new Random();
            var newList = list.OrderBy(x => random.Next(0,3)).ToList();
            return newList;
        }
        public QuestionModel CreateQuestion(APIRequestModel apiRequestModel)
        {
            QuestionModel questionmodel = APIRequest.JSON_To_Model(apiRequestModel);

            //Saves the correct answer to a TempData.
            TempData["correct"] = questionmodel.correct_answer;

            questionmodel.answers = questionmodel.incorrect_answers;
            questionmodel.answers.Add(questionmodel.correct_answer);
            questionmodel.answers = Shuffle(questionmodel.answers);
            

            //Sets the category to a tempdata.
            TempData["Category"] = apiRequestModel.Category;

            //Sets a maxtime to answer a question in a tempdata.
            ScoreModel scoreModel = new ScoreModel { };
            TempData["MaxTime"] = scoreModel.MaxTime;

            //Sets time to know how long it took to answer the question.
            System.DateTime currentTime = DateTime.Now;
            TempData["currentTime"] = currentTime;

            return questionmodel;
        }
        public ActionResult Category(string category)
        {
            APIRequestModel apiRequestModel = new APIRequestModel { };
            apiRequestModel.Category = category;
            QuestionModel questionmodel = CreateQuestion(apiRequestModel);
            return View("~/Views/Quiz/QuizPage.cshtml", questionmodel);
        }
    }
}