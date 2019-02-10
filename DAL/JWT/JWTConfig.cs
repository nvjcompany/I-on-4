using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.JWT
{
    public static class JWTConfig
    {
        private static string secureKey = "seciurityKey-hashed-smth-secret#@423$!#412";
        public static SymmetricSecurityKey SymmetricKey { get; } = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secureKey));
    }
}
