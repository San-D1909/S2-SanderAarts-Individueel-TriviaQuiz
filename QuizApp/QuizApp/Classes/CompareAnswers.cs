using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizApp.Models;
using System.Web.Mvc;

namespace QuizApp
{
    public class CompareAnswers
    {
        public static ScoreModel Checker(string chosen,string correct,ScoreModel scoreModel,double timeUsed)
        {
            if(chosen == correct)
            {
            scoreModel = CalculateScore.Calculation(timeUsed);
            }
            else
            {
                scoreModel.Score = 0;
            }
            return scoreModel;
        }
    }
}