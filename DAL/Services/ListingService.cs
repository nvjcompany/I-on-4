using DAL.Database;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            return await base.Create(listing);
        }
    }
}
