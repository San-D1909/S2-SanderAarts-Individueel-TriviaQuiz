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
        public static void Shuffle<T>(IList<T> list)
        {
            Random random = new Random(0 - 3);
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        public ActionResult Category(string Id)
        {
            APIRequestModel apiRequestModel = new APIRequestModel { };
            apiRequestModel.Category = Id;
            QuestionModel questionmodel = APIRequest.GetQuestion(apiRequestModel);

            questionmodel.answers = questionmodel.incorrect_answers;
            questionmodel.answers.Add(questionmodel.correct_answer);
            Shuffle(questionmodel.answers);

            return View("~/Views/Quiz/QuizPage.cshtml", questionmodel);
        }

        public ActionResult GetQuestionModel()
        {
            APIRequestModel apiRequestModel = new APIRequestModel { };
            apiRequestModel.Category = "15";
            QuestionModel questionmodel = APIRequest.GetQuestion(apiRequestModel);

            questionmodel.answers = questionmodel.incorrect_answers;
            questionmodel.answers.Add(questionmodel.correct_answer);
            Shuffle(questionmodel.answers);

            return View("~/Views/Quiz/QuizPage.cshtml", questionmodel);
        }

        public ActionResult Games()
        {
            APIRequestModel apiRequestModel = new APIRequestModel { };
            apiRequestModel.Category = "15";
            QuestionModel questionmodel = APIRequest.GetQuestion(apiRequestModel);

            questionmodel.answers = questionmodel.incorrect_answers;
            questionmodel.answers.Add(questionmodel.correct_answer);
            Shuffle(questionmodel.answers);

            return View("~/Views/Quiz/QuizPage.cshtml", questionmodel);
        }

        public ActionResult ScienceNature()
        {
            APIRequestModel apiRequestModel = new APIRequestModel { };
            apiRequestModel.Category = "17";
            QuestionModel questionmodel = APIRequest.GetQuestion(apiRequestModel);

            questionmodel.answers = questionmodel.incorrect_answers;
            questionmodel.answers.Add(questionmodel.correct_answer);
            Shuffle(questionmodel.answers);

            return View("~/Views/Quiz/QuizPage.cshtml", questionmodel);
        }
        public ActionResult History()
        {
            APIRequestModel apiRequestModel = new APIRequestModel { };
            apiRequestModel.Category = "23";
            QuestionModel questionmodel = APIRequest.GetQuestion(apiRequestModel);

            questionmodel.answers = questionmodel.incorrect_answers;
            questionmodel.answers.Add(questionmodel.correct_answer);
            Shuffle(questionmodel.answers);

            return View("~/Views/Quiz/QuizPage.cshtml", questionmodel);
        }
    }
}