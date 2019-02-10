using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Services;

namespace UnitTestProject
{
    [TestClass]
    public class LoginServiceTests
    {
        private LoginService service = new LoginService();

        [TestMethod]
        public void LoginAttemptWithRightDetails()
        {
            //var result = this.service.Attempt("gosho", "123321");
            var result = "test";
            Assert.AreEqual("correct", result);
        }
    }
}
