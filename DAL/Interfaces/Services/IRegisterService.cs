using DAL.Entities;
using System.Threading.Tasks;

namespace DAL.Interfaces.Services
{
    public interface IRegisterService
    {
        Task<string> Register(User user, string role);
    }
}
