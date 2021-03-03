using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizApp.Controllers
{
    public class QuizController : Controller
    {
        public ActionResult Games()
        {
            ViewData["Category"] = 15;
            return View("~/Views/Quiz/QuizPage.cshtml");
        }
        public ActionResult ScienceNature()
        {
            ViewData["Category"] = 17;
            return View("~/Views/Quiz/QuizPage.cshtml");
        }
        public ActionResult History()
        {
            ViewData["Category"] = 23;
            return View("~/Views/Quiz/QuizPage.cshtml");
        }
    }
}