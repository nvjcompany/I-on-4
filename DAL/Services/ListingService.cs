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

namespace DAL.Services
{
    public class ListingService : BaseService<Listing>, IListingService
    {
        private readonly ICampaignService campaignService;
        private readonly ICompanyHelper companyHelper;

        public ListingService(IDbContext db,
            ICampaignService campaignService,
            ICompanyHelper companyHelper) : base(db)
        {
            this.campaignService = campaignService;
            this.companyHelper = companyHelper;
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

        public async Task<List<Listing>> GetListings(string userId, int page)
        {
            return await this.db.Listings
                .WhereOwnerIs(userId)
                .Paginate(10, page)
                .ToListAsync();
        }

        public async Task<CompanyListingListPageViewModel> GetListingPage(string userId, int page)
        {
            CompanyListingListPageViewModel model = new CompanyListingListPageViewModel();
            var listings = await this.GetListings(userId, page);

            model.Listings = listings.Select(l => new ListingViewModel()
            {
                Id = l.Id,
                Title = l.Title,
            }).ToList();

            model.Page = page;
            model.Total = await this.db
                .Listings
                .WhereOwnerIs(userId)
                .CountAsync();

            return model;
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
            int companyId = await this.companyHelper.GetCompanyIdByUserId(userId);

            var isExistListing = await this.db.Listings
                .Where(l => l.Id == listing.Id && companyId == listing.CompanyId)
                .FirstOrDefaultAsync();

            if (isExistListing == null)
            {
                return false;
            }

            listing.CompanyId = companyId;

            return await base.Update(listing);
        }
    }
}
