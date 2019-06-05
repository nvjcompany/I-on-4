using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels.Campaigns
{
    public class CampaignListPageViewModel
    {
        public List<CampaignViewModel> Campaigns { get; set; }
        public int Page { get; set; }
        public int Total { get; set; }
    }
}
