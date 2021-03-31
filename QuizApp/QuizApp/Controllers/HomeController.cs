using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Login"] != null)
            {
                return View("~/Views/Home/Index.cshtml" );
            }
            else
            {
                return View();
            }
        }
    }
}