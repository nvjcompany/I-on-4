using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Interfaces;
using DAL.Services;

namespace UnitTestProject
{
    [TestClass]
    public class LoginServiceTests
    {
        private ILoginService service;

        public LoginServiceTests()
        {
            this.service = new LoginService(DatabaseFactory.Create());
        }

        [TestMethod]
        public void LoginAttemptWithRightDetails()
        {
            //this.service = DatabaseFactory.Create();
            var result = this.service.Attempt("test221@abv.bg", "test");
            //var result = "test";
            Assert.IsTrue(result != null);
        }
    }
}
