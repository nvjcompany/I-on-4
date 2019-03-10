using DAL.Entities;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRegisterService
    {
        Task<string> Register(User user, string role);
    }
}
