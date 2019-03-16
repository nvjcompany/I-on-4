using System;
using System.Linq;
using System.Threading.Tasks;
using DAL.Database;
using DAL.Entities;
using DAL.Interfaces.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject.Factory;
using DAL.ViewModels.Search;

namespace UnitTestProject.Services
{
    [TestClass]
    public class ListingServiceTests
    {
        private readonly IListingService service;
        private readonly IDbContext db;
        private readonly User existingUserWithRoleCompany;
        private readonly Company existingUserCompany;

        private Listing GetRandomDataListing()
        {
            Random r = new Random();
            var l = new Listing();
            l.RegisterFrom = DateTime.Now;
            l.RegisterTo = DateTime.Now;
            l.Description = "1";
            l.CityId = 1;
            l.Title = $"{r.Next()} Title";

            return l;
        }

        public ListingServiceTests()
        {
            this.service = ListingServiceFactory.Create();
            this.db = DatabaseFactory.Create();
            this.existingUserWithRoleCompany = this.db.Users
                .Where(user => user.Email.Equals("test221@abv.bg"))
                .First();
            this.existingUserCompany = this.db.Companies
                .Where(c => c.OwnerId.Equals(existingUserWithRoleCompany.Id))
                .First();
        }

        [TestMethod]
        public async Task GetListingPageWithNotExistingUserIdAndPage()
        {
            string userId = "not-existingUserId";
            int page = 24;

            var result = await this.service.GetListingPage(userId, new ListingSearchViewModel() { Page = page });
            Assert.AreEqual(0, result.Total);
            Assert.AreEqual(0, result.Listings.Count);
            Assert.AreEqual(page, result.Page);
        }

        [TestMethod]
        public async Task GetListingPageWithExistingUserIdAndPage()
        {
            int page = 1;

            var result = await this.service.GetListingPage(existingUserWithRoleCompany.Id, new ListingSearchViewModel() { Page = page });
            Assert.IsTrue(result.Total > 0);
            Assert.IsTrue(result.Listings.Count > 0);
            Assert.AreEqual(page, result.Page);
        }

        [TestMethod]
        public async Task CreateListingWithCorrectDetails()
        {
            var result = await this.service.Create(existingUserWithRoleCompany.Id, this.GetRandomDataListing());
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task DeleteListing()
        {
            var l = this.GetRandomDataListing();
            l.Id = 9999;


            var result = await this.service.Create(existingUserWithRoleCompany.Id, l);
            Assert.IsTrue(result);

            l = this.db.Listings.Where(x => x.Id == l.Id).First();
            result = await this.service.Delete(this.existingUserWithRoleCompany.Id, l);
            Assert.IsTrue(result);
        }
    }
}
