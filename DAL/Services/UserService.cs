using DAL.Database;
using DAL.Entities;
using DAL.Interfaces.Services;
using DAL.ViewModels.User;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Services
{
    public class UserService : IUserService
    {
        private IDbContext db;
        public UserService(IDbContext db)
        {
            this.db = db;
        }

        public async Task<User> Find(string id)
        {
            return await this.db.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(UserViewModel userViewModel)
        {
            User user = await Find(userViewModel.Id);
            PasswordHasher hash = new PasswordHasher();            
            var verifyOldPassworrd = hash.VerifyHashedPassword(user.PasswordHash, userViewModel.OldPassword);

            if (verifyOldPassworrd == PasswordVerificationResult.Failed)
            {
                return false;
            }

            var newPasswordHash = hash.HashPassword(userViewModel.NewPassword);
            user.PasswordHash = newPasswordHash;

            this.db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            this.db.SaveChanges();

            return true;
        }
    }
}
