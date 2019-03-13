using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace DAL.Interfaces.Services
{
    public interface ILoginService
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>Tupple</returns>
        Task<(string token, string message)> Attempt(string email, string password);
    }
}
