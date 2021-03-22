using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    public class CheckAnswerController : Controller
    {
        public void PrepareNextQuiz()
        {
            TempData["finalScore"] = TempData["score"];
            TempData["Current_Question"] = 0;
            TempData["Category"] = null;
        }

        public ActionResult CheckAnswer(string chosen)
        {
            string correct = (string)TempData.Peek("correct");
            TempData["Current_Question"] = 1 + (int)TempData.Peek("Current_Question");
            if (chosen == correct)
            {
                TimeSpan timeUsed = DateTime.Now - (DateTime)TempData["currentTime"];
                ScoreModel scoreModel = CalculateScore.Calculator(timeUsed.TotalSeconds);
                double lastScore = (double)TempData["score"];
                TempData["score"] = lastScore + scoreModel.Score;
            }
            if ((int)TempData.Peek("Current_Question") > 10)
            {
                //add a scorepage
                PrepareNextQuiz();
                return RedirectToAction("FinalScore", "Scoreboard");
            }
            return RedirectToAction("Category", "Quiz", new { category = (string)TempData.Peek("Category") });
        }
    }
}