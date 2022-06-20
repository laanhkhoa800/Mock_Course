using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FA.LegalHCM.Core.Interfaces
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRole<Role>();

        Task<List<RolePermission>> GetRolePermissionById<RolePermission>(Guid Id);

        Task<Role> GetById(Guid id);

        Task Update(Role role);

        Task Delete(Role role);

        Task DeletePermission(Guid id);

        Task<RolePermission> UpdateRolePermission(Guid RoleId, Guid PermissionId);

        Task<Role> AddRole(string roleName);

        Task<RolePermission> AddRolePermission(Guid RoleId, string name);
        bool IsRoleNameExisted(string userName);
        Guid GetRoleIdByRoleName(string roleName);
    }

}