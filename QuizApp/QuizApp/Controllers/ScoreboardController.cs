using QuizApp.Classes;
using QuizApp.Models;
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
        public ActionResult Submit_Score_Action()
        {
            APIRequestModel apiRequestModel = Session["apiRequestModel"] as APIRequestModel;
            ScoreModel scoreModel = Session["scoreModel"] as ScoreModel;
            UserModel userModel = Session["Login"] as UserModel;
            bool succes = Submit_Score.Submit_To_Scoreboard(scoreModel, apiRequestModel, userModel, (int)TempData["finalScore"]);
            Session["Login"] = userModel;
            return RedirectToAction("Scoreboard");
        }
        public ActionResult FinalScore()
        {
            return View("FinalScorePage");
        }
    }
}