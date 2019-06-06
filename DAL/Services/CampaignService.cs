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
using DAL.ViewModels.Campaigns;
using DAL.ViewModels.Search;
using DAL.ExtensionMethods;

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

        public async Task<List<Campaign>> GetCampaigns(CampaignSearchViewModel search)
        {
            IQueryable<Campaign> query = this.db.Campaigns;            

            if (search.Title != null && search.Title != "undefined")
            {
                query = query.Where(c => c.Name.Contains(search.Title));
            }
            if (search.Active)
            {
                query = query.Where(c => c.IsActiveRegistration == true);
            }

            return await query
                .Paginate(10, search.Page != null ? search.Page.GetValueOrDefault() : 1)
                .ToListAsync();
        }

        public async Task<CampaignListPageViewModel> GetCampaignPage(CampaignSearchViewModel search)
        {
            CampaignListPageViewModel model = new CampaignListPageViewModel();
            var campaigns = await this.GetCampaigns(search);


            model.Campaigns = campaigns.Select(c => new CampaignViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                StartDate = c.StartDate.ToString("dd/MM/yyyy"),
                EndDate = c.EndDate.ToString("dd/MM/yyyy"),
                IsActiveRegistration = c.IsActiveRegistration
            }).ToList();

            model.Page = search.Page.GetValueOrDefault();
            model.Total = await this.db
                .Campaigns                
                .CountAsync();

            return model;
        }

        public async Task<Campaign> GetCampaignPreviewPage(int campaignId)
        {
            return await this.db.Campaigns
                .Where(x => x.Id.Equals(campaignId))
                .FirstOrDefaultAsync();
            //var campaign = new CampaignViewModel()
            //{
            //    Id = c.Id,
            //    Name = c.Name,
            //    StartDate = c.StartDate.ToString("dd/MM/yyyy"),
            //    EndDate = c.EndDate.ToString("dd/MM/yyyy"),
            //    IsActiveRegistration = c.IsActiveRegistration
            //};

            //return campaign;
        }
    }
}
