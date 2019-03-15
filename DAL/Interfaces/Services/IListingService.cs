using DAL.Entities;
using DAL.ViewModels.Listings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces.Services
{
    public interface IListingService : IMaintanable<Listing>
    {
        /// <summary>
        /// Create new listing and store it into database.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="listing"></param>
        /// <returns></returns>
        Task<bool> Create(string userId, Listing listing);

        /// <summary>
        /// Update listing and store it into dabatase.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="listing"></param>
        /// <returns></returns>
        Task<bool> Update(string userId, Listing listing);

        /// <summary>
        /// Get user listings by page
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<List<Listing>> GetListings(string userId, int page);

        /// <summary>
        /// Get company listing page view model.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        Task<CompanyListingListPageViewModel> GetListingPage(string userId, int page);
    }
}
