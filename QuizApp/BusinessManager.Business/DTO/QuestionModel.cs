using System;
using System.Collections.Generic;

namespace BusinessManager.Business
{
    public class QuestionModel
    {
        public QuestionModel(DataManager.Data.QuestionDTO dto)
        {
            Correct_Answer = dto.CorrectAnswer;
            Incorrect_Answers = dto.IncorrectAnswers;
            Question = dto.Question;
        }
        public QuestionModel()
        {
        }
        public DateTime TimeTaken { get; set; }
        public string Question { get; set; }
        public List<string> Incorrect_Answers { get; set; }//Has to be with an underscore, otherwise the JSON deserialiser cant fill it in.
        public string Correct_Answer { get; set; }//Has to be with an underscore, otherwise the JSON deserialiser cant fill it in.
        public List<string> Answers { get; set; }
    }
}