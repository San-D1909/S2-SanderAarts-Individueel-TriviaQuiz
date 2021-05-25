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
    public class IntegrationTest
    {
        GetQuestionDatabaseContext question_Context = new GetQuestionDatabaseContext();
        [TestMethod]
        public void API_Is_Down()
        {
            QuestionDTO questionDTO = question_Context.SelectQuestionDatabase("medium", "15");
            Assert.IsTrue(questionDTO.Question.Length > 0);
        }
        [TestMethod]
        public void DBisWorking()
        {
            MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM `category`");
            Assert.IsTrue(DatabaseClass.GetData(mySqlCommand).Count > 0);
        }
    }
}
