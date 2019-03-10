using DAL.Database;
using DAL.Entities;
using DAL.Interfaces;
using DAL.JWT;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class LoginService : ILoginService
    {
        private IDbContext context;
        private IIdentityHelper identityHelper;

        public LoginService(IIdentityHelper identityHelper, IDbContext context)
        {
            this.context = context;
            this.identityHelper = identityHelper;
        }

        private async Task<List<Claim>> GetUserClaims(ICollection<IdentityUserRole> roles)
        {
            var roleNames = await this.context.Roles.ToListAsync();
            var claims = new List<Claim>();

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role,
                    roleNames.Find(r => r.Id == role.RoleId).Name));
            }

            claims.Add(new Claim("UserId", roles.First().UserId));

            return claims;
        }

        private async Task<JwtSecurityToken> GenerateToken(User u)
        {
            var signingCredentials = new SigningCredentials(JWTConfig.SymmetricKey,
                SecurityAlgorithms.HmacSha256Signature);
            //Claims
            List<Claim> claims = await this.GetUserClaims(u.Roles);
            var token = new JwtSecurityToken(
                issuer: "ies-is-awesome",
                audience: "readers",
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signingCredentials,
                claims: claims);

            return token;
        }

        public async Task<(string token, string message)> Attempt(string email, string password)
        {
            User u = await this.context.Users
                .Include(user => user.Roles)
                .Where(x => x.Email == email)
                .FirstOrDefaultAsync();

            if (u == null)
            {
                return (null, "not-existing-user");
            }

            var hash = new PasswordHasher();
            if (hash.VerifyHashedPassword(u.PasswordHash, password)
                == PasswordVerificationResult.Failed)
            {
                return (null, "wrong-password");
            }

            string token = new JwtSecurityTokenHandler().WriteToken(await this.GenerateToken(u));
            IdentityRole role = await this.identityHelper.GetRoleById(u.Roles.First().RoleId);
            string roleName = role.Name;

            return (token, roleName);
        }
    }
}
