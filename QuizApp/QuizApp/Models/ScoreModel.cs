using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApp.Models
{
    public class ScoreModel
    {
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
        public double Score { get; set; }
        public int Last_Score { get; set; }

    }
}