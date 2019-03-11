using DAL.Database;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class StaticDataService : IStaticDataService
    {
        private IDbContext db;

        public StaticDataService(IDbContext db)
        {
            this.db = db;
        }

        public async Task<List<City>> GetCities()
        {
            return await this.db.Cities.ToListAsync();
        }
    }
}
