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
    public class QuestionUnitTests
    {
        [TestMethod]
        public void InsertQuestion()
        {
            GetQuestionDataRepository repo = new GetQuestionDataRepository();
            List<string> incorrect = new List<string> { "fout1", "fout2", "fout3" };
            Assert.IsTrue(repo.InsertQuestionDatabase("Dit is een unit_test", incorrect, "Juist", "Hard", "15"));
        }
        [TestMethod]
        public void GetQuestionID()
        {
            GetQuestionIDRepository repo = new GetQuestionIDRepository();
            Assert.IsTrue(repo.SelectQuestionIDAddToQuestionList("How fast is USB 3.1 Gen 2 theoretically?") > 0);
        }
        [TestMethod]
        public void QuestionsAreRandom()
        {
            GetQuestionDatabaseContext question_Context = new GetQuestionDatabaseContext();
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
    }
}
