using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ILoginService
    {
        string Attempt(string email, string password);
    }
}
