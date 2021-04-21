using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApp.Models
{
    public class ScoreBoardModel
    {
        private TimeSpan timeSpan { get; set; }
        public enum TimeSpan
        {
            AllTime,
            PastWeek,
            PastMonth
        }
        private SelectedCategory selectedCategory { get; set; }
        public enum SelectedCategory
        {
            Games = 15,
            Science = 17,
            History = 23
        }
        private SelectedDifficulty selectedDifficulty { get; set; }
        public enum SelectedDifficulty
        {
            Easy = 1,
            Medium = 2,
            Hard = 3
        }
        public ScoreBoardModel(string iD, string user_ID, string category, string difficulty, string question_Amount, string question_List, string score, DateTime date)
        {
            ID = Convert.ToInt32(iD);
            User_ID = Convert.ToInt32(user_ID);
            Category = Convert.ToInt32(category);
            Difficulty = difficulty;
            Question_Amount = Convert.ToInt32(question_Amount);
            Question_List = Convert.ToInt32(question_List);
            Score = Convert.ToInt32(score);
            Date = date;
        }
        public int ID { get; set; }
        public int User_ID { get; set; }
        public int Category { get; set; }
        public string Difficulty { get; set; }
        public int Question_Amount { get; set; }
        public int Question_List { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
        public string First_Name { get; set; }
    }
}