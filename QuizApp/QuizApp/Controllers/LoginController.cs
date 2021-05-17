using QuizApp.Models;
using BusinessManager.Business;
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
                LoginContainer container = new LoginContainer { };
                userModel = new UserModel(container.Login(userModel.Email, userModel.Password));
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
            return View("Login");
        }

        public ActionResult NoAccount()
        {
            return View("~/Views/register/register.cshtml");
        }

    }
}