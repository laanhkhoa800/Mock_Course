using Ardalis.ApiEndpoints;
using Ardalis.Result;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.Web.Endpoints.ToDoItems;
using FA.LegalHCM.WebAPI.ApiModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Users
{
    public class Create : BaseAsyncEndpoint<NewUserRequest, UserResponse>
    {
        public readonly IUserServices _userServices;
        public Create(IUserServices userServices)
        {
            this._userServices = userServices;
        }
        [HttpPost("/Users")]
        [SwaggerOperation(
            Summary = "Create a new User",
            Description = "Create a new User",
            OperationId = "User.Create",
            Tags = new[] { "UserEndpoints" })
         ]
        public override async Task<ActionResult<UserResponse>> HandleAsync([FromForm] NewUserRequest request, CancellationToken cancellationToken = default)
        {
            if (_userServices.IsUserNameExisted(request.UserName) == true)
            {
                return BadRequest("UserName is Already existed");
            }   

            if(_userServices.IsEmailExisted(request.Email) == true)
            {
                return BadRequest("Email is Already existed");
            }

            var user = new User
            {
                UserName = request.UserName,
                RoleId = _userServices.GetRoleIdByRoleName(request.RoleName),
                Email = request.Email,
                PasswordHash = request.PassWord,
                CreateAt = DateTime.Now,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0
            };

            PasswordHasher<User> passHasher = new PasswordHasher<User>();
            user.PasswordHash = passHasher.HashPassword(user, user.PasswordHash);

            try
            {
                var userAdd = await _userServices.AddUser(user);
            }
            catch(Exception e)
            {
                return Result<ActionResult<UserResponse>>.Error(new[] {e.Message});
                
            }

            var createUser = new UserResponse
            {
                Id = _userServices.GetUserIdJustAdded(request.UserName),
                UserName = request.UserName,
                RoleName =  request.RoleName
            };
            return Ok(createUser);
        }
    }
}
