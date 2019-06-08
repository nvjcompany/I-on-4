using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Services
{
    public interface IApplicationService
    {
        Task<List<Application>> GetApplications(string userId, string role);
        Task<bool> ChangeApplicationStatus(int status, string userId, int applicationId);
    }
}
