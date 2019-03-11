using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IListingService : IMaintanable<Listing>
    {
        Task<bool> Create(string userId, Listing listing);
        Task<bool> Update(string userId, Listing listing);
    }
}
