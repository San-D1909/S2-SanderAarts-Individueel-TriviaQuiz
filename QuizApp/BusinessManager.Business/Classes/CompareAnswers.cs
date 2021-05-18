using System;

namespace BusinessManager.Business
{
    public class CompareAnswers
    {
        public static ScoreModel Checker(string chosen, QuestionModel questionModel, ScoreModel scoreModel)
        {
            //Adds 1 to the question count.
            scoreModel.Current_Question += 1;

            //Calculates the time that is used.
            TimeSpan timeUsed = DateTime.Now - questionModel.Time_Taken;

            if (chosen == questionModel.Correct_Answer)
            {
                scoreModel = CalculateScore.Calculation(timeUsed.TotalSeconds, scoreModel);
                scoreModel.Correct = true;
                return scoreModel;
            }
            scoreModel.Correct = false;
            return scoreModel;
        }
    }
}