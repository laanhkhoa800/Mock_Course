using Ardalis.ApiEndpoints;
using Ardalis.Result;
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
    public class Update : BaseAsyncEndpoint<UpdateUserRequest, UserResponse>
    {
        private readonly IUserServices _userServices;
        public Update(IUserServices userServices)
        {
            this._userServices = userServices;
        }

        [HttpPut("/Users")]
        [SwaggerOperation(
            Summary = "Updates an User",
            Description = "Updates an User",
            OperationId = "User.Update",
            Tags = new[] { "UserEndpoints" })
        ]
        public override async Task<ActionResult<UserResponse>> HandleAsync([FromForm]UpdateUserRequest request, CancellationToken cancellationToken = default)
        {
            if (_userServices.IsUserNameExisted(request.UserName) == true)
            {
                return BadRequest("UserName is Already existed");
            }

            var existingUser = await _userServices.GetById(request.Id);

            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.UserName = request.UserName;

            existingUser.RoleId = _userServices.GetRoleIdByRoleName(request.Rolename);

            await _userServices.Update(existingUser);

            var response = new UserResponse
            {
                Id = existingUser.Id,
                UserName = existingUser.UserName,
                RoleName = _userServices.GetRoleNameByRoleId(existingUser.RoleId)
            };

            return Ok(response);
        }
    }
}
