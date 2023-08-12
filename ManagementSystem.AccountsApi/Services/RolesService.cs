using ManagementSystem.AccountsApi.Models;
using ManagementSystem.AccountsApi.Repositories.UnitOfWork;
using ManagementSystem.Common.Entities;
using ManagementSystem.Common.Models;
using ManagementSystem.EmployeesApi.Data;

namespace ManagementSystem.AccountsApi.Services
{
    public class RolesService : IRolesService
    {
        private readonly UnitOfWork _unitOfWork;

        public RolesService(AccountsDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public List<RoleModels> GetAllRoles()
        {
            var roles = _unitOfWork.RoleRepository.GetAll().Where(x => x.Status == ActiveStatus.Active).ToList();
            var roleRes = new List<RoleModels>();
            if (roles.Any())
                foreach (var role in roles)
                {
                    roleRes.Add(new RoleModels
                    {
                        RoleId = role.RoleId,
                        RoleCode = role.RoleCode,
                        RoleName = role.RoleName,
                    });
                };
                return roleRes;
            return null;
        }

        public int CreateRole(string roleName)
        {
            try
            {
                Role roleInfo = _unitOfWork.RoleRepository.Get(u => u.RoleName == roleName);
                if (roleInfo != null)
                {
                    return -2;
                }
                Role newRole = new Role
                {
                    RoleName = roleName,
                    RoleCode = roleName.Trim(),
                };
                _unitOfWork.RoleRepository.Insert(newRole);
                _unitOfWork.Save();
                Role role = _unitOfWork.RoleRepository.Get(u => u.RoleName == roleName);
                if (role != null)
                {
                    return role.RoleId;
                } else { return -1; }
                
            }
            catch(Exception ex)
            {
                return -1;
            }
        }

        public bool UpdateRole(RoleModels roleInfo)
        {
            if (roleInfo.RoleId < 1 || roleInfo.RoleId == null)
            {
                return false;
            }
            Role isExistName = _unitOfWork.RoleRepository.GetFirst(x => x.RoleName == roleInfo.RoleName);
            if(isExistName != null)
            {
                return false;
            }

            Role role = _unitOfWork.RoleRepository.GetFirst(u => u.RoleId == roleInfo.RoleId);
            if (role != null)
            {
                role.RoleName = roleInfo.RoleName;
                role.RoleCode = roleInfo.RoleCode;
                role.Status = roleInfo.Status;

                _unitOfWork.RoleRepository.Update(role);
                _unitOfWork.Save();
                return true;
            }
            return false;
        }
    }
}
