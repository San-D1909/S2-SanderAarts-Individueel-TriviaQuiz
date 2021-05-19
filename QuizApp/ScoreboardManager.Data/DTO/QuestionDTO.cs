using System;
using System.Collections.Generic;

namespace DataManager.Data
{
    public class QuestionDTO
    {
        public QuestionDTO(string question,List<string> incorrectAnswers,string correctAnswer)
        {
            CorrectAnswer = correctAnswer;
            IncorrectAnswers = incorrectAnswers;
            Question = question;
        }

        public QuestionDTO()
        {

        }
        public string Question { get; set; }
        public List<string> IncorrectAnswers { get; set; }
        public string CorrectAnswer { get; set; }
    }
}