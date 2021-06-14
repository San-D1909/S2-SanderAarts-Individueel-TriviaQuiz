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
        BusinessManager.Business.ScoreboardDTO DTO = new Mock<BusinessManager.Business.ScoreboardDTO>().Object;
        private ScoreboardContainer container = new ScoreboardContainer();
        [TestMethod]
        public void LeaveInputEmptyScoreboard()
        {//even if the input on the scoreboard page is empty it still returns the highest scores.
            var Iface = new Mock<IScoreboardContext>();
            Iface.Setup(x => x.SelectScoreboardData("0", 0, "AllTime")).Returns(new List<DataManager.Data.ScoreboardDTO>());
            container.ScoreboardRepository.Context = Iface.Object;
            var results = container.SelectScoreboardData("0", 0, "AllTime");
            Assert.IsTrue(results!=null);
        }
        [TestMethod]
        public void SubmitAScore()
        { //Tests the container code for submitting a score
            var Iface = new Mock<ISubmitContext>();
            Iface.Setup(x => x.InsertToScoreboard(It.IsAny<SubmitDTO>())).Returns(true);
            container.SubmitRepository.Context = Iface.Object;
            Assert.IsTrue(container.InsertToScoreboard(DTO));
        }
    }
}
