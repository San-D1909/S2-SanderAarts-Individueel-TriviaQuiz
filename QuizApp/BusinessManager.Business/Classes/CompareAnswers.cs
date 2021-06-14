using System;

namespace BusinessManager.Business
{
    public class CompareAnswers
    {
        public static ScoreModel Checker(DateTime time, ScoreModel scoreModel)
        {
            //Adds 1 to the question count.
            scoreModel.CurrentQuestion += 1;

            //Calculates the time that is used.
            TimeSpan timeUsed = DateTime.Now - time;

            scoreModel.Score += CalculateScore.Calculation(timeUsed.TotalSeconds, scoreModel.MaxTime);
            scoreModel.Correct = true;
            return scoreModel;
        }
    }
}