namespace BusinessManager.Business
{
    public class CompareAnswers
    { 
        public static ScoreModel Checker(string chosen, string correct, ScoreModel scoreModel, double timeUsed)
        {
            if (chosen == correct)
            {
                scoreModel = CalculateScore.Calculation(timeUsed, scoreModel);
            }
            else
            {
                scoreModel.Score = 0;
            }
            return scoreModel;
        }
    }
}