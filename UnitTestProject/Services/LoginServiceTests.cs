using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Interfaces;
using DAL.Services;
using DAL.Interfaces.Services;
using System.Threading.Tasks;
using UnitTestProject.Factory;

namespace UnitTestProject.Services
{
    [TestClass]
    public class LoginServiceTests
    {
        private readonly ILoginService service;

        public LoginServiceTests()
        {
            this.service = new LoginService(IdentityHelperFactory.Create(),
                DatabaseFactory.Create());
        }

        [TestMethod]
        public async Task LoginAttemptWithRightDetails()
        {
            var (token, message) = await this.service.Attempt("test221@abv.bg", "test");

            Assert.IsNotNull(message);
            Assert.IsNotNull(token);
        }

        [TestMethod]
        public async Task LoginAttemptWithNotExistingEmail()
        {
            var (token, message) = await this.service.Attempt("test335@abv.bg", "test");
            Assert.IsNotNull(message);
            Assert.AreEqual("not-existing-user", message);
            Assert.IsNull(token);
        }

        [TestMethod]
        public async Task LoginAttemptWithWrongPassword()
        {
            var (token, message) = await this.service.Attempt("test221@abv.bg", "test123");
            Assert.IsNotNull(message);
            Assert.AreEqual("wrong-password", message);
            Assert.IsNull(token);
           
        }
    }
}
