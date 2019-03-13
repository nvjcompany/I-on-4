using DAL.Database;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using DAL.Interfaces.Services;

namespace DAL.Services
{
    public class CampaignService : BaseService<Campaign>, ICampaignService
    {
        public CampaignService(IDbContext db) : base(db)
        {
        }

        public async Task<Campaign> GetActiveCampaign()
        {
            return await base.db.Campaigns
                .Where(c => c.IsActiveRegistration)
                .Where(c => c.StartDate <= DateTime.Now && c.EndDate >= DateTime.Now)
                .FirstOrDefaultAsync();
        }
    }
}
