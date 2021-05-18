using System;
using System.Collections.Generic;

namespace BusinessManager.Business
{
    public class QuestionModel
    {
        public QuestionModel(DataManager.Data.QuestionDTO dto)
        {
            Correct_Answer = dto.Correct_Answer;
            Incorrect_Answers = dto.Incorrect_Answers;
            Question = dto.Question;
        }

        public QuestionModel()
        {

        }

        public DateTime Time_Taken { get; set; }
        public string Question { get; set; }
        public List<string> Incorrect_Answers { get; set; }
        public string Correct_Answer { get; set; }
        public List<string> Answers { get; set; }
    }
}