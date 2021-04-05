using QuizApp.Models;
using QuizApp.Services.Business;
using System.Web.Mvc;

namespace QuizApp.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Login(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                SecurityService security = new SecurityService();
                userModel = security.Authenticate(userModel);
                if (userModel.Unique_id != "0" && userModel.Unique_id != null)
                {
                    Session["Login"] = userModel;
                    TempData["FirstName"] = userModel.First_Name;
                    return RedirectToAction("", "Home");
                }
                else
                {
                    return View("LoginError");
                }
            }
            else
            {
                return View("Login");
            }

        }

        public ActionResult NoAccount()
        {
            return View("~/Views/register/register.cshtml");
        }

    }
}