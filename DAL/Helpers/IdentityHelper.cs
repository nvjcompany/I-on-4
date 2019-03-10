using DAL.Database;
using DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DAL.Helpers
{
    public class IdentityHelper : IIdentityHelper
    {
        private IDbContext context;

        public IdentityHelper(IDbContext context)
        {
            this.context = context;
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
