using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ILoginService
    {
        Task<(string token, string message)> Attempt(string email, string password);
    }
}
