using DAL.Database;
using DAL.Entities;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using DAL.Interfaces.Services;
using DAL.Interfaces.Helpers;
using System.Collections.Generic;
using DAL.ExtensionMethods;
using DAL.ViewModels.Listings;
using DAL.ViewModels.Search;
using System;

namespace DAL.Services
{
    public class ListingService : BaseService<Listing>, IListingService
    {
        private readonly ICampaignService campaignService;
        private readonly ICompanyHelper companyHelper;
        private readonly IIdentityHelper identityHelper;

        private async Task<bool> UserHasAcces(string userId, Listing listing)
        {
            int companyId = await this.companyHelper.GetCompanyIdByUserId(userId);

            var isExistListing = await this.db.Listings
                .Where(l => l.Id == listing.Id && companyId == l.CompanyId)
                .FirstOrDefaultAsync();

            if (isExistListing == null)
            {
                return false;
            }

            return true;
        }

        private IQueryable<Listing> GetListingsQuery(string userId, ListingSearchViewModel search)
        {
            IQueryable<Listing> query = this.db.Listings;

            var role = this.identityHelper.GetRoleByUserId(userId);

            if (userId != null && role.Result.Name != "Student")
            {
                query = query.WhereOwnerIs(userId);
            }

            if (search.Title != null)
            {
                query = query.Where(l => l.Title.Contains(search.Title));
            }

            if (search.CityId != null)
            {
                int cityId = search.CityId.GetValueOrDefault();
                query = query.Where(l => l.CityId == cityId);
            }

            return query;
        }

        private async Task<bool> CheckIsApplied(string userId, int listingId)
        {
            var isAlreadyApplied = await this.db
               .Applications.Where(x => x.UserId.Equals(userId) && x.ListingId.Equals(listingId))
               .FirstOrDefaultAsync();

            if (isAlreadyApplied == null)
            {
                return false;
            }

            return true;
        }

        public ListingService(IDbContext db,
            ICampaignService campaignService,
            ICompanyHelper companyHelper,
            IIdentityHelper identityHelper
            ) : base(db)
        {
            this.campaignService = campaignService;
            this.companyHelper = companyHelper;
            this.identityHelper = identityHelper;
        }

        public async Task<bool> Create(string userId, Listing listing)
        {
            var campaign = await this.campaignService
                .GetActiveCampaign();

            if (campaign == null)
            {
                return false;
            }

            listing.CampaignId = campaign.Id;
            listing.CompanyId = await this.companyHelper.GetCompanyIdByUserId(userId);

            return await base.Create(listing);
        }

        public async Task<CompanyListingListPageViewModel> GetListingPage(string userId, ListingSearchViewModel search)
        {
            CompanyListingListPageViewModel model = new CompanyListingListPageViewModel();
            var listings = await this.GetListingsQuery(userId, search)
                .Paginate(10, search.Page != null ? search.Page.GetValueOrDefault() : 1)
                .ToListAsync();

            model.Listings = listings.Select(l => new ListingViewModel()
            {
                Id = l.Id,
                Title = l.Title,
            }).ToList();

            model.Page = search.Page.GetValueOrDefault();
            model.Total = await this.GetListingsQuery(userId, search).CountAsync();

            return model;
        }

        public async Task<bool> Apply(string userId, int listingId, string linkedinUrl)
        {

            bool isApplied = await this.CheckIsApplied(userId, listingId);

            if (isApplied)
            {
                return false;
            }

            this.db.Applications.Add(new Application() { ListingId = listingId,
                UserId = userId, CreatedAt = DateTime.Now,
                LinkedinUrl = linkedinUrl,
                IsApproved = 0
            });
            int result = await this.db.SaveChangesAsync();

            return result == 1 ? true : false;
        }


        public async Task<bool> IsApplied(string userId, int listingId)
        {
            return await this.CheckIsApplied(userId, listingId);
        }

        public async Task<Listing> GetListingPreviewPage(int listingId)
        {
            return await this.db.Listings
                .Where(l => l.Id.Equals(listingId))
                .Include(x => x.Company)
                .Include(x => x.City)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Update(string userId, Listing listing)
        {
            if (!await this.UserHasAcces(userId, listing))
            {
                return false;
            }

            return await base.Update(listing);
        }

        public async Task<bool> Delete(string userId, Listing listing)
        {
            if (!await this.UserHasAcces(userId, listing))
            {
                return false;
            }

            return await this.Delete(listing);
        }

        public async Task<List<Listing>> GetListings(string userId, ListingSearchViewModel search)
        {
            return await this.GetListingsQuery(userId, search).ToListAsync();
        }
    }
}
