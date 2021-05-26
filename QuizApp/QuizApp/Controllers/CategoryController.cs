using BusinessManager.Business;
using QuizApp.Models;
using System.Web.Mvc;

namespace QuizApp.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult SelectCategory(ScoreboardInputModel scoreboardInputModel)
        {
            if (Session["Login"] == null)
            {
                return RedirectToAction("", "Login");
            }
            PrepareNextQuiz(new ScoreModel { });          
            return View();
        }
        public void PrepareNextQuiz(ScoreModel scoreModel)
        {
            TempData["finalScore"] = scoreModel.Score;
            scoreModel.Score = 0;
            scoreModel.CurrentQuestion = 1;
            Session["scoreModel"] = scoreModel;
        }
    }
}