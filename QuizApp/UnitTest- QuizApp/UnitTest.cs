using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using QuizApp;
using System.Collections.Generic;
using BusinessManager.Business;
using MySql.Data.MySqlClient;
using DataManager.Data;

namespace UnitTestQuizApp
{
    [TestClass]
    public class UnitTest
    {
        GetQuestionDatabaseContext question_Context = new GetQuestionDatabaseContext();
        [TestMethod]
        public void LeaveInputEmptyScoreboard()
        {
            ScoreboardContainer container = new ScoreboardContainer();
            var results = container.SelectScoreboardData("0", 0, "AllTime");
            Assert.IsTrue(results.Count > 0);
        }
        [TestMethod]
        public void RandomIsrandom()
        {
            GetQuestionDatabaseContext context = new GetQuestionDatabaseContext();
            List<int> list = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                int result = question_Context.SelectQuestionID("medium", "15");
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
        public void InsertQuestion()
        {
            GetQuestionDataRepository repo = new GetQuestionDataRepository();
            List<string> incorrect = new List<string> { "fout1", "fout2", "fout3" };
            Assert.IsTrue(repo.InsertQuestionDatabase("Dit is een unit_test", incorrect, "Juist", "Hard", "15"));
        }
        [TestMethod]
        public void LoginTest()
        {
            LoginContainer container = new LoginContainer { };
            var results = container.Login("t@t", "t");
            Assert.IsTrue(results.UniqueID != "" && results.UniqueID != null);
        }
        [TestMethod]
        public void GetQuestionID()
        {
            GetQuestionIDRepository repo = new GetQuestionIDRepository();
            Assert.IsTrue(repo.SelectQuestionIDAddToQuestionList("How fast is USB 3.1 Gen 2 theoretically?")>0);
        }
        [TestMethod]
        public void SubmitAScore()
        {
            List<string> questionList = new List<string> { "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
            SubmitDTO submitDTO = new SubmitDTO { Category = 15, Difficulty = "easy", QuestionAmount = 10, QuestionList = questionList, UniqueID = 8, Score = 0 };
            SubmitRepository repo = new SubmitRepository();
            repo.InsertToScoreboard(submitDTO);
        }
    }
}
