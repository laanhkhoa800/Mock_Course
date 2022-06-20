using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Roles
{
    public class Update : BaseAsyncEndpoint<UpdateRoleRequest, RoleResponse>
    {
        private readonly IRoleService _roleService;

        public Update(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPut("/UpdateRole")]
        [SwaggerOperation(
            Summary = "Updates a Role",
            Description = "Updates a Role with a longer description",
            OperationId = "Role.Update",
            Tags = new[] { "RoleEndpoints" })
        ]
        public override async Task<ActionResult<RoleResponse>> HandleAsync(UpdateRoleRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingItem = await _roleService.GetById(request.Id);
                existingItem.Name = request.Name;

                await _roleService.DeletePermission(request.Id);

                foreach (Guid value in request.PermissionIds)
                {
                    var rolePer = await _roleService.UpdateRolePermission(request.Id, value);
                }

                return Ok(existingItem);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}
