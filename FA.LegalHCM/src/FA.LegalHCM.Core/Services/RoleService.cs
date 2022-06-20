using Ardalis.Result;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.Core.Specifications;
using FA.LegalHCM.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.Core.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
            
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<List<Role>> GetAllRole<Role>()
        {
            var incompleteSpec = new GetAllRoleItem();
            try
            {
                var items = await _roleRepository.ListAsync(incompleteSpec);

                return new List<Role>((IEnumerable<Role>)items);
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<List<Role>>.Error(new[] { ex.Message });
            }
        }

        public async Task<List<RolePermission>> GetRolePermissionById<RolePermission>(Guid Id)
        {
            var incompleteSpec = new GetRoleItemById(Id);
            try
            {
                var items = await _roleRepository.ListAsync(incompleteSpec);

                return new List<RolePermission>((IEnumerable<RolePermission>)items);
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<List<RolePermission>>.Error(new[] { ex.Message });
            }
        }
        public Guid GetRoleIdByRoleName(string roleName)
        {
            var roleId = _roleRepository.List<Permission>(permission => permission.Name == roleName).SingleOrDefault().Id;
            return roleId;
        }
        public bool IsRoleNameExisted(string Name)
        {
            bool result = false;
            var user = _roleRepository.List<Permission>().Where(u => u.Name == Name ).SingleOrDefault();
            if (user == null)
            {
                result = true;
            }
            return result;
        }

        public async Task<RolePermission> UpdateRolePermission(Guid RoleId, Guid PermissionId)
        {
            var per = new RolePermission
            {
                RoleId = RoleId,
                PermissionId = PermissionId
            };
            return await _roleRepository.AddAsync<RolePermission>(per);
        }

        public async Task<Role> GetById(Guid id)
        {
            return await _roleRepository.GetByIdAsync<Role>(id);
        }

        public async Task Update(Role role)
        {
            await _roleRepository.UpdateAsync(role);
        }

        public async Task Delete(Role role)
        {
            await _roleRepository.DeleteAsync(role);
        }

        public async Task DeletePermission(Guid id)
        {
            await _roleRepository.DeletePermissionAsync<RolePermission>(await GetRolePermissionById<RolePermission>(id));
        }

        public async Task<Role> AddRole(string roleName)
        {

            var item = new Role
            {
                Name = roleName,
            };

            return await _roleRepository.AddAsync<Role>(item);
        }

        public async Task<RolePermission> AddRolePermission(Guid RoleId, string name)
        {
            var per = new RolePermission
            {
                RoleId = RoleId,

                PermissionId = GetRoleIdByRoleName(name)
            };         

            return await _roleRepository.AddAsync<RolePermission>(per);
        }
    }
}
