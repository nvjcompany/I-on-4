using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Interfaces
{
    public interface IIdentityHelper
    {
        IdentityRole GetRoleByName(string roleName);
    }
}
