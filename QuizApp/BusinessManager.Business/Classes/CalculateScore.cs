namespace BusinessManager.Business
{
    public class CalculateScore
    {
        public static ScoreModel Calculation(double timeUsed, ScoreModel scoreModel)
        {
            double maxTime = scoreModel.MaxTime;
            double score = ((maxTime - timeUsed) / maxTime) * 100;
            if (timeUsed >= 5 && timeUsed <= 20)
            {
                score = score / 1.5;
            }
            if (timeUsed > 20)
            {
                score = score / 2;
            }
            //Adds score to previous score.
            scoreModel.Score += (int)score;

            return scoreModel;
        }
    }
}