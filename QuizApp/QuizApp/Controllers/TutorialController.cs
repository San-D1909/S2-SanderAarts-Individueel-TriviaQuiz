using System.Web.Mvc;

namespace QuizApp.Controllers
{
    public class TutorialController : Controller
    {
        public ActionResult Tutorial()
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
    }
}