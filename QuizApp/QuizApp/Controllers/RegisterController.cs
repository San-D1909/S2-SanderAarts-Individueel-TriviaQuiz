using QuizApp.Models;
using BusinessManager.Business;
using System;
using System.Web.Mvc;


namespace QuizApp.Controllers
{
    public class RegisterController : Controller
    {
        public ActionResult Index()
        {
            return View("Register");
        }
        public ActionResult Register(RegisterModel registerModel)
        {
            if (!ModelState.IsValid) { return View("Register"); }
            RegisterContainer registerContainer = new RegisterContainer();
            if (registerContainer.StoreUser(registerModel.First_Name, registerModel.Last_Name, registerModel.Email, registerModel.Birth_Day, registerModel.Password))
            {
                return RedirectToAction("", "Home");
            }
            return View("RegisterError");
        }
    }
}