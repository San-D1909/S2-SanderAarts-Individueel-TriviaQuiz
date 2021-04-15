using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using QuizApp;
using System.Collections.Generic;

namespace UnitTest__QuizApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Leave_Input_Empty_Scoreboard()
        {
            List<string> results = QuizApp.Classes.Load_Scoreboard.Get_ScoreBoard_Data("0", 0, "AllTime");
            Assert.IsTrue(results.Count > 0);
        }
        [TestMethod]
        public void API_Is_Down()
        {
            QuizApp.Models.QuestionModel questionModel = new QuizApp.Models.QuestionModel { };
            questionModel = QuizApp.Classes.QuestionBackup.Get_Question_Database("medium", "15", questionModel);
            Assert.IsTrue(questionModel.Question.Length>0);
        }
    }
}
