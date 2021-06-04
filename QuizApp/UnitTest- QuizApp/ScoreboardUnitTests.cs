using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using QuizApp;
using System.Collections.Generic;
using BusinessManager.Business;
using MySql.Data.MySqlClient;
using DataManager.Data;
using Moq;

namespace UnitTestQuizApp
{
    [TestClass]
    public class ScoreboardUnitTests
    {
        private ScoreboardContainer container = new ScoreboardContainer();
        [TestMethod]
        public void LeaveInputEmptyScoreboard()
        {
            var Iface = new Mock<IScoreboardContext>();
            Iface.Setup(x => x.SelectScoreboardData("0", 0, "AllTime")).Returns(new List<DataManager.Data.ScoreboardDTO>());
            container.ScoreboardRepository.Context = Iface.Object;
            var results = container.SelectScoreboardData("0", 0, "AllTime");
            Assert.IsTrue(results!=null);
        }
        [TestMethod]
        public void SubmitAScore()
        { 
            var Iface = new Mock<ISubmitContext>();
            Iface.Setup(x => x.InsertToScoreboard(It.IsAny<SubmitDTO>())).Returns(true);
            container.SubmitRepository.Context = Iface.Object;
            Assert.IsTrue(container.InsertToScoreboard(15, "easy",  10, It.IsAny<List<string>>(), 8,  0));
        }
    }
}
