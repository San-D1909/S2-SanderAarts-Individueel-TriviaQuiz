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
        [TestMethod]
        public void APIIsWorking()
        {
            GetQuestionAPIContext aPIContext = new GetQuestionAPIContext();
            Assert.IsTrue(aPIContext.SelectJSONFromAPI("https://opentdb.com/api.php?amount=10").Length > 0);
        }
        [TestMethod]
        public void DBisWorking()
        {
            MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM `category`");
            Assert.IsTrue(DatabaseClass.GetData(mySqlCommand).Count > 0);
        }
    }
}
