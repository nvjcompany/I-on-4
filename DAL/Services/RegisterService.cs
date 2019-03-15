using DAL.Database;
using DAL.Entities;
using DAL.Interfaces.Services;
using DAL.Interfaces.Helpers;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IDbContext context;
        private readonly IIdentityHelper helper;

        private async Task<object> CheckExistingUser(User user)
        {
            return await this.context.Users
                .Select(x => new { x.Id, x.Email })
                .Where(x => x.Email == user.Email)
                .FirstOrDefaultAsync();
        }

        private async Task<bool> AssignRoleToUser(User user, string role)
        {
            var selectedRole = await this.helper.GetRoleByName(role);
            if (selectedRole == null) { throw new Exception("Not Existing Role"); }

            var roleIdentity = new IdentityUserRole()
            {
                UserId = user.Id,
                RoleId = selectedRole.Id
            };

            user.Roles.Add(roleIdentity);

            return await this.context.SaveChangesAsync() >= 1 ? true : false;
        }

        public RegisterService(IDbContext context, IIdentityHelper helper)
        {
            this.context = context;
            this.helper = helper;
        }

        public async Task<string> Register(User user, string role)
        {
            if (await this.CheckExistingUser(user) != null)
            {
                return "existing-email";
            }

            this.context.Users.Add(user);
            await this.context.SaveChangesAsync();

            if (await this.AssignRoleToUser(user, role))
            {
                return "success";
            }

            return "error";
        }
    }
}
