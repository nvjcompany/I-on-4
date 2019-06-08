using DAL.Entities;
using DAL.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> Find(string id);

        Task<bool> Update(UserViewModel userViewModel);
    }
}
