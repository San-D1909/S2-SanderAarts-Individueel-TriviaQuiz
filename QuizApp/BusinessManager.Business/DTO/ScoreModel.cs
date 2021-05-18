using System.Collections.Generic;

namespace BusinessManager.Business
{
    public class ScoreModel
    {
        private static int current_Question = 1;
        private static double maxTime = 30;
        private static int question_Amount = 10;
        public double MaxTime
        {
            get { return maxTime; }
            set { maxTime = value; }
        }
        public int Question_Amount
        {
            get { return question_Amount; }
            set { question_Amount = value; }
        }
        public int Current_Question
        {
            get { return current_Question; }
            set { current_Question = value; }
        }
        public int Score { get; set; }
        public bool Correct { get; set; }
        public List<string> Question_List { get; set; }
    }
}