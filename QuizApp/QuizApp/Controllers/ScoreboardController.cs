using BusinessManager.Business;
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
            List<ScoreboardDTO> scoreboardDTO = container.SelectScoreboardData(Convert.ToString(scoreboardInputModel.selectedDifficulty), Convert.ToInt32(scoreboardInputModel.selectedCategory), Convert.ToString(scoreboardInputModel.selectedTimeSpan));
            foreach (var DTO in scoreboardDTO)
            {
                scoreboard.Add(new ScoreBoardModel(DTO));
            }
            Session["scoreboardList"] = scoreboardDTO;
            return View();
        }
        public ActionResult SubmitScoreAction()
        {
            APIRequestModel apiRequestModel = Session["apiRequestModel"] as APIRequestModel;
            UserModel userModel = Session["Login"] as UserModel;
            ScoreModel scoreModel = Session["scoreModel"] as ScoreModel;
            ScoreboardContainer container = new ScoreboardContainer();
            ScoreboardDTO scoreboardDTO = new ScoreboardDTO { Category = Convert.ToInt32(apiRequestModel.Category), Difficulty = apiRequestModel.Difficulty, UserID = Convert.ToInt32(userModel.UniqueID), Score = (int)TempData["finalScore"],QuestionList = scoreModel.QuestionList};
            container.InsertToScoreboard(scoreboardDTO);
            return RedirectToAction("Scoreboard");
        }
        public ActionResult FinalScore()
        {
            if (Session["Login"] == null) { return RedirectToAction("Index", "Login"); }
            return View("FinalScorePage");
        }
    }
}