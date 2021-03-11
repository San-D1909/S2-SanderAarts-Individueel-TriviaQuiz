using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizApp.Models;
using QuizApp.Services.Business;


namespace QuizApp.Controllers
{
    public class RegisterController : Controller
    {
        public ActionResult Index()
        {
            return View("Register");
        }
        public ActionResult Register(RegisterModel RegistrationModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Register");
            }
            else
            {
                SecurityService security = new SecurityService();
                Boolean Registration = security.Registrate(RegistrationModel);
                if (Registration)
                {
                    return RedirectToAction("", "Home");
                }
                else
                {
                    return View("RegisterError");
                }
            }
        }
    }
}