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
    public class ScoreboardUnitTests
    {
        private ScoreboardContainer container = new ScoreboardContainer();
        [TestMethod]
        public void LeaveInputEmptyScoreboard()
        {        
            var results = container.SelectScoreboardData("0", 0, "AllTime");
            Assert.IsTrue(results.Count > 0);
        }
        [TestMethod]
        public void SubmitAScore()
        {
            List<string> questionList = new List<string> { "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" };
            Assert.IsTrue(container.InsertToScoreboard(15, "easy",  10, questionList, 8,  0)==true);
        }
    }
}
