﻿using DataManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessManager.Business
{
    public class ScoreboardDTO
    {
        public ScoreboardDTO(DataManager.Data.ScoreboardDTO dto)
        {
            ID = dto.ID;
            UserID = dto.UserID;
            Category = dto.Category;
            Difficulty = dto.Difficulty;
            Question_Amount = dto.QuestionAmount;
            QuestionListID = dto.QuestionList;
            Score = dto.Score;
            Date = dto.Date;
            FirstName = dto.FirstName;
        }
        public ScoreboardDTO()
        {

        }
        public int ID { get; set; }
        public int UserID { get; set; }
        public int Category { get; set; }
        public string Difficulty { get; set; }
        public int Question_Amount { get; set; }
        public string QuestionListID { get; set; }
        public List<string> QuestionList { get; set; }
        public int Score { get; set; }
        public string Date { get; set; }
        public string FirstName { get; set; }
    }
}