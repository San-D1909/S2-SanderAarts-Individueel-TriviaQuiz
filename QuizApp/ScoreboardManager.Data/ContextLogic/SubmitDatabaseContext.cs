using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    public class SubmitDatabaseContext : ISubmitContext
    {
        public int SelectQuestionListID()
        {
            MySqlCommand SelectQuestionIDCommand = new MySqlCommand("SELECT MAX(`id`) FROM `question_list` WHERE 1");
            List<string> results = DatabaseClass.GetData(SelectQuestionIDCommand);
            return Convert.ToInt32(results[0]);
        }
        public bool InsertQuestionList(List<string> Question_List)
        {
            if (Question_List.Count() == 10)
            {
                MySqlCommand InsertQuestionListCommand = new MySqlCommand("INSERT INTO `question_list`(`1`, `2`, `3`, `4`, `5`, `6`, `7`, `8`, `9`, `10`) VALUES (@val1,@val2,@val3,@val4,@val5,@val6,@val7,@val8,@val9,@val10)");
                InsertQuestionListCommand.Parameters.AddWithValue("@val1", Question_List[0]);
                InsertQuestionListCommand.Parameters.AddWithValue("@val2", Question_List[1]);
                InsertQuestionListCommand.Parameters.AddWithValue("@val3", Question_List[2]);
                InsertQuestionListCommand.Parameters.AddWithValue("@val4", Question_List[3]);
                InsertQuestionListCommand.Parameters.AddWithValue("@val5", Question_List[4]);
                InsertQuestionListCommand.Parameters.AddWithValue("@val6", Question_List[5]);
                InsertQuestionListCommand.Parameters.AddWithValue("@val7", Question_List[6]);
                InsertQuestionListCommand.Parameters.AddWithValue("@val8", Question_List[7]);
                InsertQuestionListCommand.Parameters.AddWithValue("@val9", Question_List[8]);
                InsertQuestionListCommand.Parameters.AddWithValue("@val10", Question_List[9]);
                DatabaseClass.StoreData(InsertQuestionListCommand, true);
                return true;
            }
            return false;
        }
        public bool InsertToScoreboard(SubmitDTO submitDTO)
        {
            InsertQuestionList(submitDTO.QuestionList);
            MySqlCommand SelectQuestionIDCommand = new MySqlCommand("INSERT INTO `scoreboard` ( `user`, `category`, `difficulty`, `amount_of_questions`, `question_list`, `score`, `date`) VALUES(@val1,@val2,@val3,@val4,@val5,@val6, current_timestamp());");
            SelectQuestionIDCommand.Parameters.AddWithValue("@val1", submitDTO.UniqueID);
            SelectQuestionIDCommand.Parameters.AddWithValue("@val2", submitDTO.Category);
            SelectQuestionIDCommand.Parameters.AddWithValue("@val3", submitDTO.Difficulty);
            SelectQuestionIDCommand.Parameters.AddWithValue("@val4", submitDTO.QuestionAmount);
            SelectQuestionIDCommand.Parameters.AddWithValue("@val5", SelectQuestionListID());
            SelectQuestionIDCommand.Parameters.AddWithValue("@val6", submitDTO.Score);
            return DatabaseClass.StoreData(SelectQuestionIDCommand, true);
        }
    }
}
