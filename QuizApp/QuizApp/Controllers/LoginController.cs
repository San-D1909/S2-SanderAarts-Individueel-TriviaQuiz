using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizApp.Models;
using QuizApp.Services.Business;

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
            if(ModelState.IsValid)
            {
                SecurityService security = new SecurityService();
                userModel = security.Authenticate(userModel);
                if (userModel.Unique_id != "0" && userModel.Unique_id != null)
                {
                    TempData["unique_id"] = userModel.Unique_id;
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