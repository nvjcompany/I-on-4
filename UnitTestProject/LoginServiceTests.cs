using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Interfaces;
using DAL.Services;
using DAL.Interfaces.Services;

namespace UnitTestProject
{
    [TestClass]
    public class LoginServiceTests
    {
        private ILoginService service;

        public LoginServiceTests(ILoginService service)
        {
            //this.service = new LoginService(DatabaseFactory.Create());
        }

        [TestMethod]
        public async void LoginAttemptWithRightDetails()
        {
            var result = await this.service.Attempt("test221@abv.bg", "test");
            Assert.IsNotNull(result.token);
            Assert.IsNotNull(result.message);
        }
    }
}
