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
    public class RegisterUnitTests
    {
        private RegisterContainer container = new RegisterContainer { };
        [TestMethod]
        public void RegisterTest()
        {
            Assert.IsTrue(container.InsertUser("unit", "test", "unit@test", "", "unittest")==true);
        }
    }
}
