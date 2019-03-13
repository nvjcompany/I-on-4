using DAL.Database;
using DAL.Entities;
using DAL.Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Helpers
{
    public class CompanyHelper : ICompanyHelper
    {
        private IDbContext db;

        public CompanyHelper(IDbContext db)
        {
            this.db = db;
        }

        public async Task<int> GetCompanyIdByUserId(string userId)
        {
            Company company = await this.db.Companies
                .Where(c => c.OwnerId == userId)
                .FirstOrDefaultAsync();

            if (company == null) { return -1; }

            return company.Id;
        }
    }
}
