using ScoreboardManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreboardManager.Business
{
    public class ScoreboardDTO
    {

        public ScoreboardDTO(Data.ScoreboardDTO dto)
        {
            ID = dto.ID;
            User_ID = dto.User_ID;
            Category = dto.Category;
            Difficulty = dto.Difficulty;
            Question_Amount = dto.Question_Amount;
            Question_List = dto.Question_List;
            Score = dto.Score;
            Date = dto.Date;
            First_Name = dto.First_Name;
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