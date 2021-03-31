using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult SelectCategory()
        {
            if (Session["Login"]!=null)
            {
                ScoreModel scoreModel = new ScoreModel { };
                scoreModel.Score = 0;
                Session["scoreModel"] = scoreModel;
                return View();
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }
    }
}