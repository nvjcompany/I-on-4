using DAL.Database;
using DAL.Interfaces.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject.Factory;

namespace UnitTestProject.Services
{
    [TestClass]
    public class StaticDataServiceTests
    {
        private readonly IStaticDataService service;

        public StaticDataServiceTests()
        {
            this.service = StaticDataServiceFactory.Create();
        }

        [TestMethod]
        public async Task GetAllCitiesTest()
        {
            var cities = await this.service.GetCities();
            Assert.IsTrue(cities.Count > 0);

        }
    }
}
