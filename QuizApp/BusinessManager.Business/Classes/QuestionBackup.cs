using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace BusinessManager.Business
{
    public class QuestionBackup
    {

        public static bool Store_question(QuestionModel questionModel, APIRequestModel aPIRequestModel)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DB_Credentials.DbConnectionString);
            MySqlCommand checkQuestion = new MySqlCommand("SELECT * FROM question WHERE `question` = '" + questionModel.Question + "'", databaseConnection);
            List<string> results = Database.GetData(checkQuestion, databaseConnection);
            if (results == null || results.Count >= 1)
            {
                return false;
            }
            else
            {
                MySqlCommand insertQuestion = new MySqlCommand("INSERT INTO `question`(`question`, `category`,`incorrect_answer1`, `incorrect_answer2`, `incorrect_answer3`, `correct_answer`,`difficulty`) VALUES ('" + questionModel.Question + "','" + aPIRequestModel.Category + "','" + questionModel.Incorrect_Answers[0] + "','" + questionModel.Incorrect_Answers[1] + "','" + questionModel.Incorrect_Answers[2] + "','" + questionModel.Correct_Answer + "','" + aPIRequestModel.Difficulty + "')", databaseConnection);
                Boolean succes = Database.StoreData(insertQuestion, databaseConnection, false);
                if (succes == true)
                {
                    return true;
                }
                return false;
            }
        }

    }
}