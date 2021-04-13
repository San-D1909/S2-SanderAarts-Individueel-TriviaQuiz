using System.Web.Mvc;

namespace QuizApp.Controllers
{
    public class TutorialController : Controller
    {
        public ActionResult Tutorial()
        {
            if (Session["Login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}