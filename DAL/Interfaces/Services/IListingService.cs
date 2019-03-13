using DAL.Entities;
using DAL.ViewModels.Listings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces.Services
{
    public interface IListingService : IMaintanable<Listing>
    {
        Task<bool> Create(string userId, Listing listing);
        Task<bool> Update(string userId, Listing listing);
        Task<List<Listing>> GetListings(string userId, int page);
        Task<CompanyListingListPageViewModel> GetListingPage(string userId, int page);
    }
}
