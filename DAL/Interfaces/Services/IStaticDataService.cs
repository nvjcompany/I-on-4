using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Services
{
    public interface IStaticDataService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<City>> GetCities();
    }
}
