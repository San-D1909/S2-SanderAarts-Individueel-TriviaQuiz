using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    public class SubmitDatabaseContext: ISubmitContext
    {
        public int SelectQuestionListID()
        {
            MySqlCommand SelectQuestionIDCommand = new MySqlCommand("SELECT MAX(`id`) FROM `question_list` WHERE 1");
            List<string> results = Utility.GetData(SelectQuestionIDCommand);
            return Convert.ToInt32(results[0]);
        }
        public bool InsertQuestionList(List<string> Question_List)
        {
            if (Question_List.Count() == 10)
            {
                MySqlCommand InsertQuestionListCommand = new MySqlCommand("INSERT INTO `question_list`(`1`, `2`, `3`, `4`, `5`, `6`, `7`, `8`, `9`, `10`) VALUES (" + Question_List[0] + "," + Question_List[1] + "," + Question_List[2] + "," + Question_List[3] + "," + Question_List[4] + "," + Question_List[5] + "," +Question_List[6] + "," + Question_List[7] + "," + Question_List[8] + "," + Question_List[9] + ")");
                Utility.StoreData(InsertQuestionListCommand, false);
                return true;
            }
            return false;
        }
        public void InsertToScoreboard(SubmitDTO submitDTO)
        {
            InsertQuestionList(submitDTO.QuestionList);
            MySqlCommand SelectQuestionIDCommand = new MySqlCommand("INSERT INTO `scoreboard` ( `user`, `category`, `difficulty`, `amount_of_questions`, `question_list`, `score`, `date`) VALUES('" + submitDTO.UniqueID + "', '" + submitDTO.Category + "', '" + submitDTO.Difficulty + "', '" + submitDTO.QuestionAmount + "', '" + SelectQuestionListID() + "', '" + submitDTO.Score + "', current_timestamp());");
            Utility.StoreData(SelectQuestionIDCommand, false);
        }
    }
}
