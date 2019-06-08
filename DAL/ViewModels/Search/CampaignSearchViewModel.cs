using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels.Search
{
    public class CampaignSearchViewModel
    {
        public string Title { get; set; }        
        public int? Page { get; set; }
        public bool Active { get; set; }
    }
}
