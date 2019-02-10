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

namespace DAL.Services
{
    public class LoginService : ILoginService
    {
        private IDbContext context;

        private List<Claim> GetUserClaims(ICollection<IdentityUserRole> roles)
        {
            var roleNames = this.context.Roles.ToList();
            var claims = new List<Claim>();

            foreach (var role in roles)
            {

                claims.Add(new Claim(ClaimTypes.Role,
                    roleNames.Find(r => r.Id == role.RoleId).Name));
            }

            claims.Add(new Claim("UserId", roles.First().UserId));

            return claims;
        }

        private JwtSecurityToken GenerateToken(User u)
        {
            var signingCredentials = new SigningCredentials(JWTConfig.SymmetricKey,
                SecurityAlgorithms.HmacSha256Signature);
            //Claims
            List<Claim> claims = this.GetUserClaims(u.Roles);

            var token = new JwtSecurityToken(
                issuer: "ies-is-awesome",
                audience: "readers",
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signingCredentials,
                claims: claims);

            return token;
        }

        public LoginService(IDbContext context)
        {
            this.context = context;
        }

        public JwtSecurityToken Attempt(string email, string password)
        {
            User u = this.context.Users
                .Include(user => user.Roles)
                .Where(x => x.Email == email)
                .FirstOrDefault();

            if (u == null)
            {
                return null;
            }

            var hash = new PasswordHasher();
            if (hash.VerifyHashedPassword(u.PasswordHash, password)
                == PasswordVerificationResult.Failed)
            {
                return null;
            }

            return this.GenerateToken(u);
        }
    }
}
