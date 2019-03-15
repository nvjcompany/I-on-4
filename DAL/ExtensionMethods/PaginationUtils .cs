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
        /// <summary>
        /// LINQ extension method. Accept two parameters perPage and currentPage. Returns perPage objects.
        /// Skip and Take queries requires OrderBy, so generic T class might implements IEntityWithId 
        /// That means entity sould have Id used for Order
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="perPage"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int perPage, int page)
            where T : class, IEntityWithId
        {
            return query.OrderByDescending(item => item.Id)
                .Skip(perPage * (page - 1))
                .Take(perPage);
        }
    }
}
