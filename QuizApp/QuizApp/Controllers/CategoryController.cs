using QuizApp.Models;
using System.Web.Mvc;

namespace QuizApp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult SelectCategory()
        {
            if (Session["Login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ScoreModel scoreModel = new ScoreModel { };
            scoreModel.Score = 0;
            Session["scoreModel"] = scoreModel;
            return View();
        }
    }
}