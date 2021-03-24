using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizApp.Models;
using QuizApp;

namespace QuizApp.Controllers
{
    public class CheckAnswerController : Controller
    {
        public ActionResult CheckAnswer(string chosen)
        {
            ScoreModel scoreModel = new ScoreModel { };

            TimeSpan timeUsed = DateTime.Now - (DateTime)TempData["currentTime"];
            scoreModel = CompareAnswers.Checker(chosen, (string)TempData.Peek("correct"), scoreModel, timeUsed.TotalSeconds);
            int lastScore = (int)TempData["score"];

            TempData["Current_Question"] = 1 + (int)TempData.Peek("Current_Question");
            TempData["score"] = lastScore + (int)scoreModel.Score;
            if ((int)TempData.Peek("Current_Question") > scoreModel.Question_Amount)
            {//Check if the current questionnumber is bigger than the amount of questions.
                //add a scorepage
                PrepareNextQuiz();
                return RedirectToAction("FinalScore", "Scoreboard");
            }

            return RedirectToAction("Category", "Quiz", new { category = (string)TempData.Peek("Category") });
        }
        public void PrepareNextQuiz()
        {
            TempData["finalScore"] = TempData["score"];
            TempData["Current_Question"] = 0;
            TempData["Category"] = null;
        }
    }
}