using System;
using System.Collections.Generic;

namespace DataManager.Data
{
    public class QuestionDTO
    {
        public QuestionDTO(string question,List<string> incorrect_Answers,string correct_Answer)
        {
            Correct_Answer = correct_Answer;
            Incorrect_Answers = incorrect_Answers;
            Question = question;
        }

        public QuestionDTO()
        {

        }
        public string Question { get; set; }
        public List<string> Incorrect_Answers { get; set; }
        public string Correct_Answer { get; set; }
    }
}