using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizApp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult SelectCategory()
        {
            if (TempData.Peek("unique_id")!=null)
            {
                TempData["score"] = 0;
                return View();
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }
    }
}