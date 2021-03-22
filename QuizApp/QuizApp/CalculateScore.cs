using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizApp.Models;

namespace QuizApp
{
    public class CalculateScore
    {
        public static ScoreModel Calculator(double timeUsed)
        {
            ScoreModel scoreModel = new ScoreModel { };
            double maxTime = scoreModel.MaxTime;
            scoreModel.Score = ((maxTime - timeUsed) /maxTime) * 100;
            return scoreModel;
        }
    }
}