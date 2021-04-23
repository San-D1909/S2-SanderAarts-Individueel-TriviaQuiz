using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreboardManager.Data
{
    public class SubmitDatabaseContext: ISubmitContext
    {
        public static int Get_QuestionList_ID()
        {
            MySqlConnection databaseConnection = new MySqlConnection("Datasource=127.0.0.1;port=3306;username=root;password=;database= quizapp;");
            MySqlCommand Get_Question_ID = new MySqlCommand("SELECT MAX(`id`) FROM `question_list` WHERE 1", databaseConnection);
            List<string> results = ScoreboardDatabaseContext.GetData(Get_Question_ID, databaseConnection);
            return Convert.ToInt32(results[0]);
        }
        public static bool Save_Question_List(List<string> Question_List)
        {
            MySqlConnection databaseConnection = new MySqlConnection("Datasource=127.0.0.1;port=3306;username=root;password=;database= quizapp;");
            if (Question_List.Count() == 10)
            {
                MySqlCommand Store_QuestionList = new MySqlCommand("INSERT INTO `question_list`(`1`, `2`, `3`, `4`, `5`, `6`, `7`, `8`, `9`, `10`) VALUES (" + Question_List[0] + "," + Question_List[1] + "," + Question_List[2] + "," + Question_List[3] + "," + Question_List[4] + "," + Question_List[5] + "," +Question_List[6] + "," + Question_List[7] + "," + Question_List[8] + "," + Question_List[9] + ")", databaseConnection);
                StoreData(Store_QuestionList, databaseConnection, false);
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
            StoreData(Get_Question_ID, databaseConnection, false);
        }
        public static bool StoreData(MySqlCommand storeData, MySqlConnection databaseConnection, bool prepare)
        {
            ScoreboardDatabaseContext.Check_databaseConnectionState(databaseConnection);
            try
            {
                databaseConnection.Open();
                if (prepare == true)
                {
                    storeData.Prepare();
                }
                MySqlDataReader executeString = storeData.ExecuteReader();
                databaseConnection.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e.Message);
                return false;
            }
        }
        public SubmitDTO Get_Unique_Question_ID(SubmitDTO submitDTO)
        {
            throw new NotImplementedException();
        }
    }
}
