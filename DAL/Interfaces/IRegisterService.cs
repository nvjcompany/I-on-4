using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IRegisterService
    {
        string Register(User user, string role);
    }
}
