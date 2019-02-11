using DAL.Database;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;

namespace DAL.Services
{
    public class RegisterService : IRegisterService
    {
        private IDbContext context;
        private IIdentityHelper helper;

        private object CheckExistingUser(User user)
        {
            return this.context.Users
                .Select(x => new { x.Id, x.Email })
                .Where(x => x.Email == user.Email)
                .FirstOrDefault();
        }

        private bool AssignRoleToUser(User user, string role)
        {
            var selectedRole = this.helper.GetRoleByName(role);
            if (selectedRole == null) { throw new Exception("Not Existing Role"); }

            var roleIdentity = new IdentityUserRole()
            {
                UserId = user.Id,
                RoleId = selectedRole.Id
            };

            user.Roles.Add(roleIdentity);

            return this.context.SaveChanges() >= 1 ? true : false;
        }

        public RegisterService(IDbContext context, IIdentityHelper helper)
        {
            this.context = context;
            this.helper = helper;
        }

        public string Register(User user, string role)
        {
            if (this.CheckExistingUser(user) != null)
            {
                return "existing-email";
            }

            this.context.Users.Add(user);
            this.context.SaveChanges();

            if (this.AssignRoleToUser(user, role))
            {
                return "success";
            }

            return "error";
        }
    }
}
