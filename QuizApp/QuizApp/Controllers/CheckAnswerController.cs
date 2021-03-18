using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    public class CheckAnswerController : Controller
    {
        public ActionResult CheckAnswer(string chosen)
        {
            string correct = (string)TempData.Peek("correct");
            TempData["Current_Question"] = 1 +(int)TempData.Peek("Current_Question");
            if((int)TempData.Peek("Current_Question")>10)
            {
                //add a scorepage
                return RedirectToAction("", "Home");
            }
            string current_Category = (string) TempData.Peek("Category");
            if(chosen == correct)
            {
                //add scoreincrease function
            }
            return RedirectToAction("Category", "Quiz", current_Category);
        }
    }
}