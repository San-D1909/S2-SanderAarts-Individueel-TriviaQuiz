using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApp.Models
{
    public class QuestionModel
    {
        public string question { get; set; }
        public List<string> incorrect_answers { get; set; }
        public string correct_answer { get; set; }

        public List<string> answers { get; set; }
    }
}