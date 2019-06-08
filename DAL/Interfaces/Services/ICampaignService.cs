using DAL.Entities;
using DAL.ViewModels.Campaigns;
using DAL.ViewModels.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Services
{
    public interface ICampaignService : IMaintanable<Campaign>
    {
        /// <summary>
        /// Get active campaign if exists. Else return null.
        /// </summary>
        /// <returns></returns>
        Task<Campaign> GetActiveCampaign();

        /// <summary>
        /// Get campaigns by page
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<List<Campaign>> GetCampaigns(CampaignSearchViewModel search);

        /// <summary>
        /// Get campaigns for listing from view model.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<CampaignListPageViewModel> GetCampaignPage(CampaignSearchViewModel search);

        /// <summary>
        /// Get campaign
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        Task<Campaign> GetCampaignPreviewPage(int campaignId);
        
    }
}
