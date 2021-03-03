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
            if (TempData["unique_id"]!=null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login","Login");
            }
        }
    }
}