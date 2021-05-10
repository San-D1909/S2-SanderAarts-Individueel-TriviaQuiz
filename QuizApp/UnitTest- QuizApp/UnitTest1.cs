using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using QuizApp;
using System.Collections.Generic;
using BusinessManager.Business;

namespace UnitTest__QuizApp
{
    [TestClass]
    public class UnitTest1
    {
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
            QuestionModel questionModel = new QuestionModel { };
            questionModel = QuizApp.Classes.QuestionBackup.Get_Question_Database("medium", "15", questionModel);
            Assert.IsTrue(questionModel.Question.Length>0);
        }
    }
}
