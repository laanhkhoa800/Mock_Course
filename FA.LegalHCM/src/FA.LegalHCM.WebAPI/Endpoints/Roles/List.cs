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
    public class List : BaseAsyncEndpoint<List<RoleResponse>>
    {
        private readonly IRoleService _RoleService;

        public List(IRoleService RoleService)
        {
            _RoleService = RoleService;
        }

        [HttpGet("/Role")]
        [SwaggerOperation(
            Summary = "Gets a list of all Role",
            Description = "Gets a list of all Role",
            OperationId = "Role.List",
            Tags = new[] { "RoleEndpoints" })
        ]
        public override async Task<ActionResult<List<RoleResponse>>> HandleAsync(CancellationToken cancellationToken)
        {
            var items = (await _RoleService.GetAllRole<Core.Entities.Role>())
                .Select(item => new RoleResponse
                {
                    Id = item.Id,
                    Name = item.Name,
                    Permission = item.RolePermissions.Select(x=>x.Permission.Name),
                });

            return Ok(items);
        }


    }
}
