using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    class GetQuestionDatabaseContext : IGetQuestionDatabaseContext
    {
        private Random random = new Random { };
        public int Get_Random_Question_ID(string difficulty, string category, MySqlConnection databaseConnection)
        {
            MySqlCommand getMaxId = new MySqlCommand("SELECT `id` FROM `question` WHERE `category` = " + category + " AND `difficulty` LIKE '" + difficulty + "' ORDER BY `id` DESC", databaseConnection);
            List<string> Id = Utility.GetData(getMaxId, databaseConnection);
            int index = random.Next(0,Convert.ToInt32(Id[0]));
            return index;
        }
        public QuestionDTO Get_Question_From_Database(string difficulty, string category, string DbConnectionString)
        {
            QuestionDTO questionDTO = new QuestionDTO { };
            MySqlConnection databaseConnection = new MySqlConnection(DbConnectionString);
            MySqlCommand getQuestionData = new MySqlCommand("SELECT * FROM `question` WHERE `id`= " + Get_Random_Question_ID(difficulty, category, databaseConnection) + "", databaseConnection);
            List<string> results = Utility.GetData(getQuestionData, databaseConnection);
            questionDTO.Question = results[2];
            List<string> incorrect_Answers = new List<string> { results[3], results[4], results[5] };
            questionDTO.Incorrect_Answers = incorrect_Answers;
            questionDTO.Correct_Answer = results[6];
            return questionDTO;
        }
    }
}
