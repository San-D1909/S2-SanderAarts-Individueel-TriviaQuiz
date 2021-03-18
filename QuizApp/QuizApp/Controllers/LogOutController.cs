using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizApp.Controllers
{
    public class LogOutController : Controller
    {
        public ActionResult Index()
        {
            _ = TempData["unique_id"];
            return View("LogOutPage");
        }
    }
}