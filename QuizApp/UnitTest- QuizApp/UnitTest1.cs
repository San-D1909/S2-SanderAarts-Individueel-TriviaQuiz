using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using QuizApp;
using System.Collections.Generic;
using BusinessManager.Business;
using MySql.Data.MySqlClient;
using DataManager.Data;


namespace UnitTest__QuizApp
{
    [TestClass]
    public class UnitTest1
    {
        GetQuestionDatabaseContext question_Context = new GetQuestionDatabaseContext();
        MySqlConnection databaseConnection = new MySqlConnection(DB_Credentials.DbConnectionString);
        [TestMethod]
        public void Leave_Input_Empty_Scoreboard()
        {
            ScoreboardContainer container = new ScoreboardContainer();
            var results = container.Get_Scoreboard_Data("0", 0, "AllTime");
            Assert.IsTrue(results.Count > 0);
        }
        [TestMethod]
        public void API_Is_Down()
        {
            QuestionDTO questionDTO = question_Context.Get_Question_From_Database("medium", "15", DB_Credentials.DbConnectionString);
            Assert.IsTrue(questionDTO.Question.Length > 0);
        }
        [TestMethod]
        public void Random_is_random()
        {
            GetQuestionDatabaseContext context = new GetQuestionDatabaseContext();
            List<int> list = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                int result = question_Context.Get_Random_Question_ID("medium", "15", databaseConnection);
                list.Add(result);
            }
            foreach (int result in list)
            {
                int x = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (result == list[i])
                    {
                        x++;
                    }
                }
                Assert.IsFalse(x == 2);
            }
        }
        [TestMethod]
        public void Insert_Question()
        {
            GetQuestionDataRepository repo = new GetQuestionDataRepository();
            List<string> incorrect = new List<string> { "fout1", "fout2", "fout3" };
            Assert.IsTrue(repo.Store_question("Dit is een unit_test", incorrect, "Juist", "Hard", "15"));
        }
    }
}
