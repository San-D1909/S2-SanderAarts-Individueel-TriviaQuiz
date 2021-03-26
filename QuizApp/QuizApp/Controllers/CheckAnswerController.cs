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

            //Calculates the time that is used.
            TimeSpan timeUsed = DateTime.Now - (DateTime)TempData["currentTime"];

            //Calculates the score based on how much time is used.
            scoreModel = CompareAnswers.Checker(chosen, (string)TempData.Peek("correct"), scoreModel, timeUsed.TotalSeconds);
            
            //Adds 1 to the question count.
            TempData["Current_Question"] = 1 + (int)TempData.Peek("Current_Question");

            //Adds score to previous score.
            int lastScore = (int)TempData["score"];
            TempData["score"] = lastScore + (int)scoreModel.Score;

            if ((int)TempData.Peek("Current_Question") > scoreModel.Question_Amount)//Check if the current questionnumber is bigger than the amount of questions.
            {
                //SCOREPAGE SAVE FUNCTIE TOEVOEGEN.
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