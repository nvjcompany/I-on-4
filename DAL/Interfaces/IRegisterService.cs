using DAL.Entities;

namespace DAL.Interfaces
{
    interface IRegisterService
    {
        bool Register(User user);
        bool Register(User user, string role);
    }
}
