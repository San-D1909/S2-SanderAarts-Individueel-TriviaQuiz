using BusinessManager.Business;
using QuizApp.Classes;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace QuizApp.Controllers
{
    public class ScoreboardController : Controller
    {
        public ActionResult Scoreboard(ScoreboardInputModel scoreboardInputModel)
        {
            List<ScoreBoardModel> scoreboard = new List<ScoreBoardModel>();
            ScoreboardContainer container = new ScoreboardContainer();
            var scoreboardDTO = container.Get_Scoreboard_Data(Convert.ToString(scoreboardInputModel.selectedDifficulty), Convert.ToInt32(scoreboardInputModel.selectedCategory), Convert.ToString(scoreboardInputModel.selectedTimeSpan));
            foreach (var DTO in scoreboardDTO)
            {
                scoreboard.Add(new ScoreBoardModel(DTO));
            }
            Session["scoreboardList"] = scoreboard;
            return View();
        }
        public ActionResult Submit_Score_Action()
        {
            APIRequestModel apiRequestModel = Session["apiRequestModel"] as APIRequestModel;
            ScoreModel scoreModel = Session["scoreModel"] as ScoreModel;
            UserModel userModel = Session["Login"] as UserModel;
            ScoreboardContainer container = new ScoreboardContainer();
            container.Submit_To_Scoreboard(Convert.ToInt32(apiRequestModel.Category), apiRequestModel.Difficulty, scoreModel.Question_Amount, scoreModel.Question_List, Convert.ToInt32(userModel.Unique_id), (int)TempData["finalScore"]);
            return RedirectToAction("Scoreboard");
        }
        public ActionResult FinalScore()
        {
            if (Session["Login"] == null) { return RedirectToAction("Index", "Login"); }
            return View("FinalScorePage");
        }
    }
}