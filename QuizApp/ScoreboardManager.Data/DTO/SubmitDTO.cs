using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardManager.Data
{
    public class SubmitDTO
    {
/*        public SubmitDTO(int category, string difficulty, int question_Amount, List<string> question_List, int unique_ID, int finalScore)
        {
            Category = category;
            Difficulty = difficulty;
            Question_Amount = question_Amount;
            Question_List = question_List;
            Score = finalScore;
            Unique_ID = unique_ID;
        }*/
        public int Unique_ID { get; set; }
        public int Category { get; set; }
        public string Difficulty { get; set; }
        public int Score { get; set; }
        public int Question_Amount { get; set; }
        public List<string> Question_List { get; set; }
    }
}
