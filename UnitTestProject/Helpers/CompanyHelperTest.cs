using System;
using System.Threading.Tasks;
using DAL.Interfaces.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject.Factory;

namespace UnitTestProject.Helpers
{
    [TestClass]
    public class CompanyHelperTest
    {
        private readonly ICompanyHelper helper;

        public CompanyHelperTest()
        {
            this.helper = CompanyHelperFactory.Create();
        }

        [TestMethod]
        public async Task GetCompanyIdWithIncorrectUserId()
        {
            var result = await this.helper.GetCompanyIdByUserId("incorrect-id");

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public async Task GetCompanyIdWithCorrectUserId()
        {
            var result = await this.helper.GetCompanyIdByUserId("ee41436f-6702-48cc-b99a-50502825e6f8");

            Assert.IsTrue(result > 0);
        }
    }
}
