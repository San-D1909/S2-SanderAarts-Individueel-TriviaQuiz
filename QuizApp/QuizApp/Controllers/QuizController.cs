using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizApp.Models;
using QuizApp.Classes;

namespace QuizApp.Controllers
{
    public class QuizController : Controller
    {
        public QuestionModel CreateQuestion(APIRequestModel apiRequestModel)
        {
            QuestionModel questionModel = Get_Question_Data.Fill_QuestionModel(apiRequestModel);
            ScoreModel scoreModel = new ScoreModel { };

            questionModel.Answers = questionModel.Incorrect_Answers;
            questionModel.Answers.Add(questionModel.Correct_Answer);
            questionModel.Answers = Utility.Shuffle(questionModel.Answers);

            //Sets a maxtime to answer a question in a tempdata.
            ViewData["MaxTime"] = scoreModel.MaxTime;

            //Sets time to know how long it took to answer the question.
            questionModel.Time_Taken = DateTime.Now;

            Session["questionModel"] = questionModel;
            Session["apiRequestModel"] = apiRequestModel;
            return questionModel;
        }
        public ActionResult Prepare_Question(string category)
        {
            if (Session["Login"] != null)
            {
                APIRequestModel apiRequestModel = new APIRequestModel { };
                if (Session["apiRequestModel"] != null)
                {
                    apiRequestModel = Session["apiRequestModel"] as APIRequestModel;
                }
                else
                {
                    apiRequestModel.Category = category;
                }
                QuestionModel questionmodel = CreateQuestion(apiRequestModel);
                return View("~/Views/Quiz/QuizPage.cshtml", questionmodel);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
    }
}