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
    public class RegisterUnitTests
    {
        private RegisterContainer container = new RegisterContainer { };
        [TestMethod]
        public void RegisterTest()
        {
            BusinessManager.Business.UserDTO userbus = new Mock<BusinessManager.Business.UserDTO>().Object;
            var Iface = new Mock<IRegisterDatabaseContext>();
            Iface.Setup(x => x.InsertUser(It.IsAny<DataManager.Data.UserDTO>())).Returns(true);
            container.registerRepository.Context = Iface.Object;
            Assert.IsTrue(container.InsertUser(userbus));
        }
    }
}
