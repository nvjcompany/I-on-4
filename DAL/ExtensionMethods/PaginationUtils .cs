using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.ExtensionMethods
{
    public static class PaginationUtils
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int perPage, int page)
            where T : class, IEntityWithId
        {
            return query.OrderByDescending(item => item.Id)
                .Skip(perPage * (page - 1))
                .Take(perPage);
        }
    }
}
