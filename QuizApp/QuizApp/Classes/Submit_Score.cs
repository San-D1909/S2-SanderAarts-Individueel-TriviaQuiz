using MySql.Data.MySqlClient;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizApp.Classes
{
    public class Submit_Score
    {
        public static ScoreModel Get_Unique_Question_ID(QuestionModel questionModel, ScoreModel scoreModel)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DB_Credentials.DbConnectionString);
            MySqlCommand Get_Question_ID = new MySqlCommand("SELECT * FROM question WHERE `question` = '" + questionModel.Question + "'", databaseConnection);
            List<string> results = Database.GetData(Get_Question_ID, databaseConnection);
            if (scoreModel.Question_List == null)
            {
                List<string> question1 = new List<string> { results[0] };
                scoreModel.Question_List = question1;
            }
            else
            {
                scoreModel.Question_List.Add(results[0]);
            }
            return scoreModel;
        }
        public static int Get_QuestionList_ID()
        {
            MySqlConnection databaseConnection = new MySqlConnection(DB_Credentials.DbConnectionString);
            MySqlCommand Get_Question_ID = new MySqlCommand("SELECT MAX(`id`) FROM `question_list` WHERE 1", databaseConnection);
            List<string> results = Database.GetData(Get_Question_ID, databaseConnection);
            return Convert.ToInt32(results[0]);
        }
        public static bool Save_Question_List(ScoreModel scoreModel)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DB_Credentials.DbConnectionString);
            if (scoreModel.Question_List.Count() == 10)
            {
                MySqlCommand Store_QuestionList = new MySqlCommand("INSERT INTO `question_list`(`1`, `2`, `3`, `4`, `5`, `6`, `7`, `8`, `9`, `10`) VALUES (" + scoreModel.Question_List[0] + "," + scoreModel.Question_List[1] + "," + scoreModel.Question_List[2] + "," + scoreModel.Question_List[3] + "," + scoreModel.Question_List[4] + "," + scoreModel.Question_List[5] + "," + scoreModel.Question_List[6] + "," + scoreModel.Question_List[7] + "," + scoreModel.Question_List[8] + "," + scoreModel.Question_List[9] + ")", databaseConnection);
                bool succes = Database.StoreData(Store_QuestionList, databaseConnection, false);
                return true;
            }
            return false;
        }
        public static bool Submit_To_Scoreboard(ScoreModel scoreModel, APIRequestModel apiRequestModel, UserModel userModel, int finalScore)
        {
            Save_Question_List(scoreModel);
            int question_List_ID = Get_QuestionList_ID();
            MySqlConnection databaseConnection = new MySqlConnection(DB_Credentials.DbConnectionString);
            MySqlCommand Get_Question_ID = new MySqlCommand("INSERT INTO `scoreboard` ( `user`, `category`, `difficulty`, `amount_of_questions`, `question_list`, `score`, `date`) VALUES('" + userModel.Unique_id + "', '" + apiRequestModel.Category + "', '" + apiRequestModel.Difficulty + "', '" + scoreModel.Question_Amount + "', '" + question_List_ID + "', '" + finalScore + "', current_timestamp());", databaseConnection);
            if (Database.StoreData(Get_Question_ID, databaseConnection, false))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}