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
        public static int Get_QuestionList_ID()
        {
            MySqlCommand Get_Question_ID = new MySqlCommand("SELECT MAX(`id`) FROM `question_list` WHERE 1");
            List<string> results = Utility.GetData(Get_Question_ID);
            return Convert.ToInt32(results[0]);
        }
        public static bool Save_Question_List(List<string> Question_List)
        {
            if (Question_List.Count() == 10)
            {
                MySqlCommand Store_QuestionList = new MySqlCommand("INSERT INTO `question_list`(`1`, `2`, `3`, `4`, `5`, `6`, `7`, `8`, `9`, `10`) VALUES (" + Question_List[0] + "," + Question_List[1] + "," + Question_List[2] + "," + Question_List[3] + "," + Question_List[4] + "," + Question_List[5] + "," +Question_List[6] + "," + Question_List[7] + "," + Question_List[8] + "," + Question_List[9] + ")");
                Utility.StoreData(Store_QuestionList, false);
                return true;
            }
            return false;
        }
        public void Submit_To_Scoreboard(SubmitDTO submitDTO)
        {
            Save_Question_List(submitDTO.Question_List);
            int question_List_ID = Get_QuestionList_ID();
            MySqlConnection databaseConnection = new MySqlConnection("Datasource=127.0.0.1;port=3306;username=root;password=;database= quizapp;");
            MySqlCommand Get_Question_ID = new MySqlCommand("INSERT INTO `scoreboard` ( `user`, `category`, `difficulty`, `amount_of_questions`, `question_list`, `score`, `date`) VALUES('" + submitDTO.Unique_ID + "', '" + submitDTO.Category + "', '" + submitDTO.Difficulty + "', '" + submitDTO.Question_Amount + "', '" + question_List_ID + "', '" + submitDTO.Score + "', current_timestamp());", databaseConnection);
            Utility.StoreData(Get_Question_ID, false);
        }
    }
}
