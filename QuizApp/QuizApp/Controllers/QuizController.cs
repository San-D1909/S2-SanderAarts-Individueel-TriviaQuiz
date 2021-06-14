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
            QuestionContainer container = new QuestionContainer { };
            QuestionModel questionModel = container.FillQuestionModel(apiRequestModel);

            Session["questionModel"] = Utility.PrepareQuestion(questionModel);
            return questionModel;
        }
        public ActionResult PrepareQuestion()
        {
            APIRequestModel apiRequestModel = Session["apiRequestModel"] as APIRequestModel;
            QuestionModel questionmodel = CreateQuestion(apiRequestModel);
            Session["apiRequestModel"] = apiRequestModel;
            return View("~/Views/Quiz/QuizPage.cshtml", questionmodel);
        }
        public ActionResult PrepareQuiz(string category)
        {
            if (Session["Login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            APIRequestModel apiRequestModel = new APIRequestModel { };
            apiRequestModel.Category = category;
            Session["apiRequestModel"] = apiRequestModel; 
            return RedirectToAction("PrepareQuestion");
        }
    }
}