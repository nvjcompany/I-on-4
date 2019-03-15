using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Helpers
{
    public interface ICompanyHelper
    {
        /// <summary>
        /// Get user company by userId async.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<int> GetCompanyIdByUserId(string userId);
    }
}
