using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessManager.Business
{
    public class Utility
    {
        public static List<T> Shuffle<T>(List<T> list)
        {//Creates list with correct answer at random index
            Random random = new Random();
            var newList = list.OrderBy(x => random.Next(0, 3)).ToList();
            return newList;
        }
        public static QuestionModel PrepareQuestion(QuestionModel questionModel)
        {
            //creates a list with the answers and then shuffles it.
            questionModel.Answers = questionModel.Incorrect_Answers;
            questionModel.Answers.Add(questionModel.Correct_Answer);
            questionModel.Answers = Utility.Shuffle(questionModel.Answers);

            //Sets time to know how long it took to answer the question.
            questionModel.TimeTaken = DateTime.Now;
            return questionModel;
        }
    }
}