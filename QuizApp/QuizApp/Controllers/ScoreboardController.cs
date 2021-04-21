using QuizApp.Classes;
using QuizApp.Models;
using ScoreboardManager.Business;
using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace QuizApp.Controllers
{
    public class ScoreboardController : Controller
    {
        // GET: Scoreboard
        public ActionResult Scoreboard(ScoreboardInputModel scoreboardInputModel)
        {
            /*            List<string> results = Load_Scoreboard.Get_ScoreBoard_Data(Convert.ToString(scoreBoardModel.difficulty), (int)scoreBoardModel.category, Convert.ToString(scoreBoardModel.timeSpan));
                        string scoreboard = (string)results[1];
                        for (int i = 1; i < results.Count; i++)
                        {
                            scoreboard = scoreboard + "," + (string)results[i];
                            ViewData["count"] = i;
                        }
                        ViewData["scoreboard"] = scoreboard;*/
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
            Submit_Score.Submit_To_Scoreboard(scoreModel, apiRequestModel, userModel, (int)TempData["finalScore"]);
            Session["Login"] = userModel;
            return RedirectToAction("Scoreboard");
        }
        public ActionResult FinalScore()
        {
            return View("FinalScorePage");
        }
    }
}