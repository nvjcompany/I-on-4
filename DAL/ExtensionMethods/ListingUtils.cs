using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ExtensionMethods
{
    public static class ListingUtils
    {
        public static IQueryable<Listing> WhereOwnerIs(this IQueryable<Listing> query, string userId)
        {
            return query.Where(l => l.Company.OwnerId.Equals(userId));
        }
    }
}
