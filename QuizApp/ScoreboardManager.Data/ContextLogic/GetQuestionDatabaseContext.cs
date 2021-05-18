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
        public int Get_Random_Question_ID(string difficulty, string category)
        {
            MySqlCommand getMaxId = new MySqlCommand("SELECT `id` FROM `question` WHERE `category` = " + category + " AND `difficulty` LIKE '" + difficulty + "' ORDER BY `id` DESC");
            List<string> Id = Utility.GetData(getMaxId);
            int index = random.Next(0,Convert.ToInt32(Id[0]));
            return index;
        }
        public QuestionDTO Get_Question_From_Database(string difficulty, string category)
        {
            QuestionDTO questionDTO = new QuestionDTO { };
            MySqlCommand getQuestionData = new MySqlCommand("SELECT * FROM `question` WHERE `id`= " + Get_Random_Question_ID(difficulty, category) + "");
            List<string> results = Utility.GetData(getQuestionData);
            questionDTO.Question = results[2];
            List<string> incorrect_Answers = new List<string> { results[3], results[4], results[5] };
            questionDTO.Incorrect_Answers = incorrect_Answers;
            questionDTO.Correct_Answer = results[6];
            return questionDTO;
        }
    }
}
