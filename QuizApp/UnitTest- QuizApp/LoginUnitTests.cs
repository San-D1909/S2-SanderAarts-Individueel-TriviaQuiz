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
    public class LoginUnitTests
    {
        private LoginContainer container = new LoginContainer { };
        private DataManager.Data.UserDTO userDTO = new Mock<DataManager.Data.UserDTO>().Object;
        [TestMethod]
        public void CorrectCredentialsLoginTest()
        {
            var Iface = new Mock<ILoginDatabaseContext>();
            Iface.Setup(x => x.GetLoginData("t@t", "t")).Returns(userDTO);
            container.LoginRepository.Context = Iface.Object;
            Assert.IsTrue(container.Login("t@t", "t") != null);
        }
        [TestMethod]
        public void InvalidCredentialsLoginTest()
        {
            var Iface = new Mock<ILoginDatabaseContext>();
            Iface.Setup(x => x.GetLoginData("t@t", "t")).Returns(userDTO);
            container.LoginRepository.Context = Iface.Object;
            Assert.IsFalse(container.Login("test@t", "test") != null);
        }
    }
}
