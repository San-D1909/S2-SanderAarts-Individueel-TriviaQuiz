using QuizApp.Models;

namespace QuizApp
{
    public class CalculateScore
    {
        public static ScoreModel Calculation(double timeUsed, ScoreModel scoreModel)
        {
            double maxTime = scoreModel.MaxTime;
            scoreModel.Score = ((maxTime - timeUsed) / maxTime) * 100;
            if (timeUsed >= 5 && timeUsed <= 20)
            {
                scoreModel.Score = scoreModel.Score / 1.5;
            }
            if (timeUsed > 20)
            {
                scoreModel.Score = scoreModel.Score / 2;
            }
            return scoreModel;
        }
    }
}