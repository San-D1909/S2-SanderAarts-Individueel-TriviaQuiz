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
            if (TempData.Peek("unique_id") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}