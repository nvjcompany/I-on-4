using DAL.Entities;
using System.Threading.Tasks;

namespace DAL.Interfaces.Services
{
    public interface IRegisterService
    {
        /// <summary>
        /// Register user into database with given role
        /// </summary>
        /// <param name="user"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        Task<string> Register(User user, string role);
    }
}
