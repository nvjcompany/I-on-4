using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DAL.JWT;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace IES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            var signingCredentials = new SigningCredentials(JWTConfig.SymmetricKey, SecurityAlgorithms.HmacSha256Signature);
            //Claims
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            var token = new JwtSecurityToken(
                issuer: "ies-is-awesome",
                audience: "readers",
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signingCredentials,
                claims: claims);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}