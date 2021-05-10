using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessManager.Business
{
    public class Utility
    {
        public static List<T> Shuffle<T>(List<T> list)
        {//Creates list with correct answer at random index
            Random random = new Random();
            var newList = list.OrderBy(x => random.Next(0, 3)).ToList();
            return newList;
        }
        public static ScoreModel Get_Unique_Question_ID_And_Add_To_QuestionList(QuestionModel questionModel, ScoreModel scoreModel)
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
    }
}