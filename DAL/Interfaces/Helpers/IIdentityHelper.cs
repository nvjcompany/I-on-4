using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace DAL.Interfaces.Helpers
{
    public interface IIdentityHelper
    {
        /// <summary>
        /// Get role by roleId
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns>Returns IdentityRole or null</returns>
        Task<IdentityRole> GetRoleById(string roleId);

        /// <summary>
        /// Get role by roleName
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns>Returns IdentityRole or null</returns>
        Task<IdentityRole> GetRoleByName(string roleName);
    }
}
