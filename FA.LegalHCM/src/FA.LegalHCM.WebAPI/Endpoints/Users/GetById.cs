using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.WebAPI.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Users
{
    public class GetById : BaseAsyncEndpoint<Guid, UserResponse>
    {
        private readonly IUserServices _userServices;
        public GetById(IUserServices userServices)
        {
            this._userServices = userServices;
        }

        [HttpGet("/Users/{id:guid}")]
        [SwaggerOperation(
            Summary = "Gets a single User",
            Description = "Gets a User by Id",
            OperationId = "User.GetById",
            Tags = new[] { "UserEndpoints" })
        ]
        public override async  Task<ActionResult<UserResponse>> HandleAsync(Guid id, CancellationToken cancellationToken = default)
        {
            // Find user by Id if not existed then return Notfound
            var user = await _userServices.GetById(id);
            if(user == null)
            {
                return NotFound();
            }
            var response = new UserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                RoleName = _userServices.GetRoleNameByRoleId(user.RoleId)
            };
            return Ok(response);
        }
    }
}
