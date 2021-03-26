using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizApp.Models;

namespace QuizApp
{
    public class CalculateScore
    {
        public static ScoreModel Calculation(double timeUsed)
        {
            ScoreModel scoreModel = new ScoreModel { };
            double maxTime = scoreModel.MaxTime;
            scoreModel.Score = ((maxTime - timeUsed) / maxTime) * 100;
            if(timeUsed>=5&&timeUsed<=20)
            {
                scoreModel.Score = scoreModel.Score / 2;
            }
            if (timeUsed > 20)
            {
                scoreModel.Score = scoreModel.Score / 3;
            }
            return scoreModel;
        }
    }
}