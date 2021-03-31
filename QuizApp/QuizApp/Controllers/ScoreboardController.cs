using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizApp.Controllers
{
    public class ScoreboardController : Controller
    {
        // GET: Scoreboard
        public ActionResult Scoreboard()
        {
            if (Session["Login"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult Submit_Score()
        {
            return RedirectToAction("Scoreboard");
        }
        public ActionResult FinalScore()
        {
            return View("FinalScorePage");
        }
    }
}