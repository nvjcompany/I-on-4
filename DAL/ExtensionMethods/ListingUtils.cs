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
        /// <summary>
        /// LINQ extension method for Listing Entity. Return all listings on selected user
        /// </summary>
        /// <param name="query"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static IQueryable<Listing> WhereOwnerIs(this IQueryable<Listing> query, string userId)
        {
            return query.Where(l => l.Company.OwnerId.Equals(userId));
        }
    }
}
