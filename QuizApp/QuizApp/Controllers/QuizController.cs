using BusinessManager.Business;
using QuizApp.Models;
using System;
using System.Web.Mvc;

namespace QuizApp.Controllers
{
    public class QuizController : Controller
    {
        public QuestionModel CreateQuestion(APIRequestModel apiRequestModel)
        {
            QuestionModel questionModel = QuestionContainer.Fill_QuestionModel(apiRequestModel);
            ScoreModel scoreModel = Session["scoreModel"] as ScoreModel;

            questionModel.Answers = questionModel.Incorrect_Answers;
            questionModel.Answers.Add(questionModel.Correct_Answer);
            questionModel.Answers = Utility.Shuffle(questionModel.Answers);

            //Sets a maxtime to answer a question in a tempdata.
            ViewData["MaxTime"] = scoreModel.MaxTime;

            //Sets time to know how long it took to answer the question.
            questionModel.Time_Taken = DateTime.Now;

            Session["scoreModel"] = scoreModel;
            Session["questionModel"] = questionModel;
            Session["apiRequestModel"] = apiRequestModel;
            return questionModel;
        }
        public ActionResult Prepare_Question(string category)
        {
            if (Session["Login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            APIRequestModel apiRequestModel = new APIRequestModel { };
            if (category != null)
            {
                apiRequestModel.Category = category;
            }
            else if (Session["apiRequestModel"] != null)
            {
                apiRequestModel = Session["apiRequestModel"] as APIRequestModel;
            }
            QuestionModel questionmodel = CreateQuestion(apiRequestModel);
            return View("~/Views/Quiz/QuizPage.cshtml", questionmodel);
        }
    }
}