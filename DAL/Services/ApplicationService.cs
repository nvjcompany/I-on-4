using DAL.Database;
using DAL.Entities;
using DAL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Services
{
    public class ApplicationService : IApplicationService
    {
        private IDbContext db;

        public ApplicationService(IDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> ChangeApplicationStatus(int status, string userId, int applicationId)
        {
            var app = await this.db.Applications.Where(x =>
                x.Id.Equals(applicationId)
                &&
                x.Listing.Company.OwnerId.Equals(userId)
            ).FirstOrDefaultAsync();

            if (app == null) { return false; }

            app.IsApproved = status;
            this.db.Entry(app);
            await this.db.SaveChangesAsync();

            return true;
        }

        public Task<List<Application>> GetApplications(string userId, string role)
        {
            var q = this.db.Applications.AsQueryable();

            if (role == "Student")
            {
                q = q.Where(x => x.UserId.Equals(userId));
            }
            else if (role == "Company")
            {
                q = q.Where(x => x.Listing.Company.OwnerId.Equals(userId));
            }

            return q
                .Include(x => x.Listing)
                .Include(x => x.User)
                .ToListAsync();
        }
    }
}
