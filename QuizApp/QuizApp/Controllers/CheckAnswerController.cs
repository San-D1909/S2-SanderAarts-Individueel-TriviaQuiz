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
            ScoreModel scoreModel = Session["scoreModel"] as ScoreModel;
            QuestionModel questionModel = Session["questionModel"] as QuestionModel;

            //Calculates the time that is used.
            TimeSpan timeUsed = DateTime.Now - questionModel.Time_Taken;
            //Calculates the score based on how much time is used.
            scoreModel = CompareAnswers.Checker(chosen, questionModel.Correct_Answer, scoreModel, timeUsed.TotalSeconds);

            //Adds score to previous score.
            scoreModel.Last_Score = questionModel.Score;
            questionModel.Score = scoreModel.Last_Score + (int)scoreModel.Score;

            //Adds 1 to the question count.
            questionModel.Current_Question = 1 + questionModel.Current_Question;

            
            if (questionModel.Current_Question > scoreModel.Question_Amount)
            {//Check if the current questionnumber is bigger than the amount of questions.
                PrepareNextQuiz(questionModel);
                return RedirectToAction("FinalScore", "Scoreboard");
            }

            Session["scoreModel"] = scoreModel;
            Session["questionModel"] = questionModel;
            return RedirectToAction("Category", "Quiz"/*, new { category = (string)TempData.Peek("Category") }*/);
        }
        public void PrepareNextQuiz(QuestionModel questionModel)
        {
            TempData["finalScore"] = questionModel.Score;
            questionModel.Score = 0;
            questionModel.Current_Question = 1;
            Session["questionModel"] = questionModel;
        }
    }
}