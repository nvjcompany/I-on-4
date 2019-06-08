using DAL.Database;
using DAL.Interfaces.Helpers;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Helpers
{
    public class IdentityHelper : IIdentityHelper
    {
        private readonly IDbContext context;

        public IdentityHelper(IDbContext context)
        {
            this.context = context;
        }

        public async Task<IdentityRole> GetRoleByUserId(string userId)
        {
            User u  = await this.context
                .Users
                .Where(x => x.Id.Equals(userId))
                .Include(x => x.Roles)
                .FirstOrDefaultAsync();

            var role = u.Roles.First() ;

            return await this.GetRoleById(role.RoleId);
        }

        public async Task<IdentityRole> GetRoleById(string roleId)
        {
            return await this.context
                .Roles
                .Where(x => x.Id == roleId)
                .FirstOrDefaultAsync();
        }

        public async Task<IdentityRole> GetRoleByName(string roleName)
        {
            return await this.context
                 .Roles
                 .Where(x => x.Name == roleName)
                 .FirstOrDefaultAsync();
        }
    }
}
