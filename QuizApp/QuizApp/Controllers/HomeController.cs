using System.Web.Mvc;

namespace QuizApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Login"] == null)
            {
                return View();
            }
            return View("~/Views/Home/Index.cshtml");
        }
    }
}