using System;

namespace BusinessManager.Business
{
    public class CompareAnswers
    {
        public static ScoreModel Checker(string chosen, QuestionModel questionModel, ScoreModel scoreModel)
        {
            QuestionContainer container = new QuestionContainer();
            scoreModel.QuestionList = container.SelectQuestionIDAddToQuestionList(questionModel.Question, scoreModel.QuestionList);
            scoreModel.CurrentQuestion += 1;
            if (chosen == questionModel.Correct_Answer)
            {            
                TimeSpan timeUsed = DateTime.Now - questionModel.TimeTaken;//Calculates the time that is used.
                scoreModel.Score += CalculateScore.Calculation(timeUsed.TotalSeconds, scoreModel.MaxTime);
                scoreModel.Correct = true;
            }
            return scoreModel;
        }
    }
}