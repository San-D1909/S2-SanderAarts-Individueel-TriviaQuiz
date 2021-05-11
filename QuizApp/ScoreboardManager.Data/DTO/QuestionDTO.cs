using System;
using System.Collections.Generic;

namespace DataManager.Data
{
    public class QuestionDTO
    {
        public string Question { get; set; }
        public List<string> Incorrect_Answers { get; set; }
        public string Correct_Answer { get; set; }
    }
}