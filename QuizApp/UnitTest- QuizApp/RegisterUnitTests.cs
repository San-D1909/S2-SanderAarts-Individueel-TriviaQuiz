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
        public BusinessManager.Business.UserDTO user = new Mock<BusinessManager.Business.UserDTO>().Object;
        [TestMethod]
        public void RegisterTest()
        {//Tries to run the container code for the Register function
            var Iface = new Mock<IRegisterDatabaseContext>();
            Iface.Setup(x => x.InsertUser(It.IsAny<DataManager.Data.UserDTO>())).Returns(true);
            container.registerRepository.Context = Iface.Object;
            Assert.IsTrue(container.InsertUser(user));
        }
    }
}
