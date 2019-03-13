using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace DAL.Interfaces.Helpers
{
    public interface IIdentityHelper
    {
        Task<IdentityRole> GetRoleById(string roleId);
        Task<IdentityRole> GetRoleByName(string roleName);
    }
}
