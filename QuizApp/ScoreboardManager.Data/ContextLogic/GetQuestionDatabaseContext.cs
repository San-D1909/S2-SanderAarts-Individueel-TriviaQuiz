using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    public class GetQuestionDatabaseContext : IGetQuestionDatabaseContext
    {
        private Random random = new Random { };
        public int SelectQuestionID(string difficulty, string category)
        {
            MySqlCommand getMaxId = new MySqlCommand("SELECT `id` FROM `question` WHERE `category` = @val1 AND `difficulty` LIKE @val2 ORDER BY `id` DESC");
            getMaxId.Parameters.AddWithValue("@val1", category);
            getMaxId.Parameters.AddWithValue("@val2", difficulty);
            List<string> Id = Utility.GetData(getMaxId,true);
            int index = random.Next(0,Convert.ToInt32(Id[0]));
            return index;
        }
        public QuestionDTO SelectQuestionDatabase(string difficulty, string category)
        {
            QuestionDTO questionDTO = new QuestionDTO { };
            MySqlCommand getQuestionData = new MySqlCommand("SELECT * FROM `question` WHERE `id`= @val1");
            getQuestionData.Parameters.AddWithValue("@val1", SelectQuestionID(difficulty, category));
            List<string> results = Utility.GetData(getQuestionData,true);
            questionDTO.Question = results[2];
            List<string> incorrect_Answers = new List<string> { results[3], results[4], results[5] };
            questionDTO.IncorrectAnswers = incorrect_Answers;
            questionDTO.CorrectAnswer = results[6];
            return questionDTO;
        }
    }
}
