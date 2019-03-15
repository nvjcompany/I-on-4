using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace DAL.Interfaces.Services
{
    public interface ILoginService
    {
        /// <summary>
        ///  If users exists return current user with role. If user doesn't exists return
        ///  error message into message tupple
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>Tupple</returns>
        Task<(string token, string message)> Attempt(string email, string password);
    }
}
