using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Services
{
    public interface IMaintanable<T>
    {
        /// <summary>
        /// Find single record from database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<T> Find(T obj);

        /// <summary>
        /// Create record into database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<bool> Create(T obj);

        /// <summary>
        /// Update existing record in database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<bool> Update(T obj);

        /// <summary>
        /// Delete record from database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<bool> Delete(T obj);
    }
}
