using DAL.Database;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class ListingService : BaseService<Listing>, IListingService
    {
        ICampaignService campaignService;

        public ListingService(IDbContext db, ICampaignService campaignService) : base(db)
        {
            this.campaignService = campaignService;
        }

        public async Task<bool> Create(string userId, Listing listing)
        {
            var campaign = await this.campaignService.GetActiveCampaign();
            if (campaign == null)
            {
                return false;
            }

            listing.CampaignId = campaign.Id;
            //to do find company by userId

            return await base.Create(listing);
        }

        public async Task<bool> Update(string userId, Listing listing)
        {
            //to do find company by userId
            int companyId = 1;

            var isExistListing = await this.db.Listings
                .Where(l => l.Id == listing.Id && companyId == listing.CompanyId)
                .FirstOrDefaultAsync();

            if (isExistListing == null)
            {
                return false;
            }

            return await base.Update(listing);
        }
    }
}
