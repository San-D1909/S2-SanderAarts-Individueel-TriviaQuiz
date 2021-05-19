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

            scoreModel = Utility.SelectQuestionIDAddToQuestionList(questionModel, scoreModel);

            Session["questionModel"] = questionModel;
            Session["scoreModel"] = scoreModel;

            return View("~/Views/Quiz/AnswerResults.cshtml", scoreModel);
        }

        public ActionResult NextQuestion()
        {
            ScoreModel scoreModel = Session["scoreModel"] as ScoreModel;
            Session["scoreModel"] = scoreModel;

            if (scoreModel.CurrentQuestion > scoreModel.QuestionAmount)
            {//Check if the current questionnumber is bigger than the amount of questions.
                PrepareNextQuiz(scoreModel);
                return RedirectToAction("FinalScore", "Scoreboard");
            }
            else
            {
                return RedirectToAction("PrepareQuestion", "Quiz");
            }
        }

        public void PrepareNextQuiz(ScoreModel scoreModel)
        {
            TempData["finalScore"] = scoreModel.Score;
            scoreModel.Score = 0;
            scoreModel.CurrentQuestion = 1;
            Session["questionModel"] = scoreModel;
        }
    }
}