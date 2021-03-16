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

/*private string question = "Test test";
private List<string> answers = new List<string> { };
private int correctAnswer = 0;
private int questionNumber = 0;

public string Question
{
    get { return question; }
    set { question = value; }
}
public List<string> Answers
{
    get { return answers; }
    set 
    {
        string newItem = Convert.ToString(value);
        answers.Add(newItem); 
    }
}
public int CorrectAnswer
{
    get { return correctAnswer; }
    set { correctAnswer = value; }
}*/
//   }
