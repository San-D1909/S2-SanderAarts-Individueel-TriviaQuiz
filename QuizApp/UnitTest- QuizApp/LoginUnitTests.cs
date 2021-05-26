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
    public class LoginUnitTests
    {
        private LoginContainer container = new LoginContainer { };
        [TestMethod]
        public void LoginTest()
        {
            var results = container.Login("t@t", "t");
            Assert.IsTrue(results.UniqueID != "" && results.UniqueID != null);
        }
        [TestMethod]
        public void InvalidLoginForbidden()
        {
            var results = container.Login("test@t", "test");
            Assert.IsFalse(results.UniqueID != "" && results.UniqueID != null);
        }
    }
}
