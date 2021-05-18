using QuizApp.Models;
using System;
using System.Web.Mvc;
using BusinessManager.Business;

namespace QuizApp.Controllers
{
    public class CheckAnswerController : Controller
    {
        public ActionResult CheckAnswer(string chosen)
        {
            ScoreModel scoreModel = Session["scoreModel"] as ScoreModel;
            QuestionModel questionModel = Session["questionModel"] as QuestionModel;

            //Calculates the score based on how much time is used.
            scoreModel = CompareAnswers.Checker(chosen, questionModel ,scoreModel);

            scoreModel = Utility.Get_Unique_Question_ID_And_Add_To_QuestionList(questionModel, scoreModel);

            Session["questionModel"] = questionModel;
            Session["scoreModel"] = scoreModel;

            return View("~/Views/Quiz/AnswerResults.cshtml", scoreModel);
        }

        public ActionResult Next_Question()
        {
            ScoreModel scoreModel = Session["scoreModel"] as ScoreModel;
            Session["scoreModel"] = scoreModel;

            if (scoreModel.Current_Question > scoreModel.Question_Amount)
            {//Check if the current questionnumber is bigger than the amount of questions.
                PrepareNextQuiz(scoreModel);
                return RedirectToAction("FinalScore", "Scoreboard");
            }
            else
            {
                return RedirectToAction("Prepare_Question", "Quiz");
            }
        }

        public void PrepareNextQuiz(ScoreModel scoreModel)
        {
            TempData["finalScore"] = scoreModel.Score;
            scoreModel.Score = 0;
            scoreModel.Current_Question = 1;
            Session["questionModel"] = scoreModel;
        }
    }
}