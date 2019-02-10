using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Interfaces;

namespace UnitTestProject
{
    [TestClass]
    public class LoginServiceTests
    {
        private ILoginService service;

        [TestMethod]
        public void LoginAttemptWithRightDetails()
        {
            //var result = this.service.Attempt("gosho", "123321");
            var result = "test";
            Assert.AreEqual("correct", result);
        }
    }
}
