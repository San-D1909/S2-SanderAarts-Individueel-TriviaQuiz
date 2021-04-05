using MySql.Data.MySqlClient;
using QuizApp.Models;
using System;
using System.Collections.Generic;

namespace QuizApp.Classes
{
    public class QuestionBackup
    {
        public static QuestionModel Get_Question_Database(string difficulty, string category, QuestionModel questionModel)
        {
            MySqlConnection databaseConnection = new MySqlConnection(DB_Credentials.DbConnectionString);
            MySqlCommand getQuestionData = new MySqlCommand("SELECT* FROM `question` WHERE `category`= " + category + " AND `difficulty`= '" + difficulty + "'", databaseConnection);
            List<string> results = Database.GetData(getQuestionData, databaseConnection);
            questionModel.Question = results[2];
            List<string> incorrect_Answers = new List<string> { results[3], results[4], results[5] };
            questionModel.Incorrect_Answers = incorrect_Answers;
            questionModel.Correct_Answer = results[6];
            return questionModel;
        }
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