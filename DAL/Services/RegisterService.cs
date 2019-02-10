using DAL.Database;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DAL.Services
{
    public class RegisterService : IRegisterService
    {
        //private IesDbContext db = new IesDbContext();
        private IDbContext context;

        public RegisterService(IDbContext context)
        {
            this.context = context;
        }

        public bool Register(User user, string role)
        {
            IdentityUserRole roleIdentity = new IdentityUserRole();
            //roleIdentity.
            user.Roles.Add(roleIdentity);
            return true;
        }

        public bool Register(User user)
        {
            return true;
        }
    }
}
