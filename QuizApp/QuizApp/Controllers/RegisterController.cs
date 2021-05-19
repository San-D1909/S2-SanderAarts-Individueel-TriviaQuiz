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
            if (registerContainer.InsertUser(registerModel.FirstName, registerModel.LastName, registerModel.Email, registerModel.BirthDay, registerModel.Password))
            {
                return RedirectToAction("", "Login");
            }
            return View("RegisterError");
        }
    }
}