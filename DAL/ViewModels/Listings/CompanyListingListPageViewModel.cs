using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.ViewModels.Listings
{
    public class CompanyListingListPageViewModel
    {
        public List<ListingViewModel> Listings { get; set; }
        public int Page { get; set; }
        public int Total { get; set; }
    }
}
