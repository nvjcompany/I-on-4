using DAL.Database;
using DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace DAL.Helpers
{
    public class IdentityHelper : IIdentityHelper
    {
        private IDbContext context;

        public IdentityHelper(IDbContext context)
        {
            this.context = context;
        }

        public IdentityRole GetRoleByName(string roleName)
        {
            return this.context
                 .Roles
                 .Where(x => x.Name == roleName)
                 .FirstOrDefault();
        }
    }
}
