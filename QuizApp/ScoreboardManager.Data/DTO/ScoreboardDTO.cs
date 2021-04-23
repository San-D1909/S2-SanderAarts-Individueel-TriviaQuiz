using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardManager.Data
{
    public class ScoreboardDTO
    {
        public ScoreboardDTO(string iD, string user_ID, string category, string difficulty, string question_Amount, string question_List, string score, string date)
        {
            ID = Convert.ToInt32(iD);
            User_ID = Convert.ToInt32(user_ID);
            Category = Convert.ToInt32(category);
            Difficulty = difficulty;
            Question_Amount = Convert.ToInt32(question_Amount);
            Question_List = Convert.ToInt32(question_List);
            Score = Convert.ToInt32(score);
            Date = Convert.ToDateTime(date);
        }
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
