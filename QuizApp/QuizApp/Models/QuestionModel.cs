using System;
using System.Collections.Generic;

namespace QuizApp.Models
{
    public class QuestionModel
    {
        private static int current_Question = 1;
        private static int score = 0;

        public DateTime Time_Taken { get; set; }
        public string Question { get; set; }
        public List<string> Incorrect_Answers { get; set; }
        public string Correct_Answer { get; set; }
        public int Current_Question
        {
            get { return current_Question; }
            set { current_Question = value; }
        }
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        public List<string> Answers { get; set; }
    }
}