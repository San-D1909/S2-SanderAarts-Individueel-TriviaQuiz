using System.Collections.Generic;

namespace BusinessManager.Business
{
    public class ScoreModel
    {
        private static int currentQuestion = 1;
        private static double maxTime = 30;
        private static int questionAmount = 10;
        public double MaxTime
        {
            get { return maxTime; }
            set { maxTime = value; }
        }
        public int QuestionAmount
        {
            get { return questionAmount; }
            set { questionAmount = value; }
        }
        public int CurrentQuestion
        {
            get { return currentQuestion; }
            set { currentQuestion = value; }
        }
        public List<string> QuestionList
        {
            get { return questionList; }
            set { questionList = value; }
        }
        public int Score { get; set; }
        public bool Correct { get; set; }
        private List<string> questionList = new List<string>();
    }
}