using System;
using System.Collections.Generic;

namespace DataManager.Data
{
    public class ScoreboardDTO
    {
        public ScoreboardDTO(string iD, string userID, string category, string difficulty, string questionAmount, string questionListID, string score, DateTime date)
        {
            ID = Convert.ToInt32(iD);
            UserID = Convert.ToInt32(userID);
            Category = Convert.ToInt32(category);
            Difficulty = difficulty;
            QuestionAmount = Convert.ToInt32(questionAmount);
            QuestionList = questionListID;
            Score = Convert.ToInt32(score);
            Date = date.ToShortDateString();
            //Date = Convert.ToDateTime(date);
            
        }
        public int ID { get; set; }
        public int UserID { get; set; }   
        public int Category { get; set; }
        public string Difficulty { get; set; }
        public int QuestionAmount { get; set; }
        public string QuestionList { get; set; }
        public int Score { get; set; }
        public string Date { get; set; }
        public string FirstName { get; set; }
    }
}
