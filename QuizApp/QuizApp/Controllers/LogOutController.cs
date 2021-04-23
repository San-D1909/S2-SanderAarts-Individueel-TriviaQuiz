using QuizApp.Models;
using System.Web.Mvc;

namespace QuizApp.Controllers
{
    public class LogOutController : Controller
    {
        public ActionResult Index()
        {
            TempData.Clear();
            ViewData.Clear();
            Session.Clear();
            Session.Abandon();
            Response.Cookies.Clear();
            return View("LogOutPage");
        }
    }
}