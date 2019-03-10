using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EndpointServices.Helpers
{
    public static class ClaimsHelper
    {
        public static string GetUserId(ClaimsPrincipal user)
        {
            return user.Claims.Where(x => x.Type == "UserId").First().Value;
        }

        public static string GetUserRole(ClaimsPrincipal user)
        {
            return user.Claims.Where(x => x.Type == ClaimTypes.Role).First().Value;
        }
    }
}
