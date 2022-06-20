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
    public class Delete : BaseAsyncEndpoint<Guid, RoleResponse>
    {
        private readonly IRoleService _roleService;

        public Delete(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpDelete("/DeleteRole")]
        [SwaggerOperation(
            Summary = "Deletes an Role",
            Description = "Deletes an Role",
            OperationId = "Role.Delete",
            Tags = new[] { "RoleEndpoints" })
        ]
        public override async Task<ActionResult<RoleResponse>> HandleAsync(Guid request, CancellationToken cancellationToken = default)
        {
            var itemToDelete = await _roleService.GetById(request);

            if (itemToDelete == null) return NotFound();

            await _roleService.Delete(itemToDelete);

            return NoContent();
        }
    }
}
