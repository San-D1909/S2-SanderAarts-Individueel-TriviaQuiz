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
    public class QuestionUnitTests
    {
        public QuestionContainer questionContainer = new QuestionContainer { };
        public QuestionModel questionModel = new Mock<QuestionModel>().Object;
        public ScoreModel scoreModel = new Mock<ScoreModel>().Object;
        public QuestionDTO questionDTO = new Mock<QuestionDTO>().Object;

        [TestMethod]
        public void InsertQuestion()
        {
            var Iface = new Mock<IGetQuestionAPIContext>();
            Iface.Setup(x => x.InsertQuestionDatabase(It.IsAny<QuestionDTO>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            questionContainer.getQuestionDataRepository.ApiContext = Iface.Object;
            Assert.IsTrue(questionContainer.getQuestionDataRepository.ApiContext.InsertQuestionDatabase(questionDTO, "test", "test"));
        }
        [TestMethod]
        public void GetQuestionID()
        {
            var Iface = new Mock<IGetQuestionID>();
            Iface.Setup(x => x.SelectQuestionIDAddToQuestionList(It.IsAny<string>())).Returns(718);
            questionContainer.getQuestionIDRepository.Context = Iface.Object;
            questionModel.Question = "test string";
            scoreModel = questionContainer.SelectQuestionIDAddToQuestionList(questionModel, scoreModel);
            Assert.IsTrue(scoreModel.QuestionList[0]=="718");
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
