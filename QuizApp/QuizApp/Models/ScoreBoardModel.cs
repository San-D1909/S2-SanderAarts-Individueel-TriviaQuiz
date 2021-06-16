using BusinessManager.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApp.Models
{
    public class ScoreBoardModel
    {
        public ScoreBoardModel(ScoreboardDTO dto)
        {
            ID = dto.ID;
            UserID = dto.UserID;
            Category = dto.Category;
            Difficulty = dto.Difficulty;
            QuestionAmount = dto.Question_Amount;
            QuestionListID = dto.QuestionListID;
            Score = dto.Score;
            Date = dto.Date;
            FirstName = dto.FirstName;
        }
        public int ID { get; set; }
        public int UserID { get; set; }
        public int Category { get; set; }
        public string Difficulty { get; set; }
        public int QuestionAmount { get; set; }
        public string QuestionListID { get; set; }
        public int Score { get; set; }
        public string Date { get; set; }
        public string FirstName { get; set; }
    }
}