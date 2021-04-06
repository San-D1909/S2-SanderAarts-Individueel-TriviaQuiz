using QuizApp.Classes;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace QuizApp.Controllers
{
    public class ScoreboardController : Controller
    {
        // GET: Scoreboard
        public ActionResult Scoreboard(/*int category, string difficulty, string timespan*/)
        {
            if (Session["Login"] != null)
            {
                int count = 0;
                string scoreboard = "";
                List<string> results = Load_Scoreboard.Get_ScoreBoard_Data("medium", 15);
                for (int i = 0; i < results.Count; i++)
                {
                    if(i <1)
                    {
                        scoreboard = (string)results[i]
                    }
                    scoreboard = scoreboard+","+(string)results[i];
                    count = i;
                }
                ViewData["scoreboard"] = scoreboard;
                ViewData["count"] = count;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
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