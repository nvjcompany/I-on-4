using DAL.Database;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class ListingService<Listing> : BaseService<Listing> where Listing : class, IEntityWithId, IListingService<Listing>
    {
        public ListingService(IDbContext db) : base(db)
        {

        }
    }
}
