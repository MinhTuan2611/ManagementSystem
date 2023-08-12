using ManagementSystem.AccountsApi.Models;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;

namespace ManagementSystem.AccountsApi.Services
{
    public interface IRolesService
    {
        List<RoleModels> GetAllRoles();
        int CreateRole(string roleName);
        bool UpdateRole(RoleModels roleInfomation);
    }
}
