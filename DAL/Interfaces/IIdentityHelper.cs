using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IIdentityHelper
    {
        Task<IdentityRole> GetRoleById(string roleId);
        Task<IdentityRole> GetRoleByName(string roleName);
    }
}
