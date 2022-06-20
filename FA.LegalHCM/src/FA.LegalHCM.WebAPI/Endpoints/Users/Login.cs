using System.Threading;
using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using System;
using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.WebAPI.ApiModels;

namespace FA.LegalHCM.WebAPI.Endpoints.Users
{
    public class Login : BaseAsyncEndpoint<LoginRequest, UserResponse>
    {
        private readonly IUserServices _userservice;

        public Login(IUserServices userService)
        {
            _userservice = userService;
        }

        [HttpPost("/Login")]
        [SwaggerOperation(
            Summary = "Login with authentication",
            Description = "Login with authentication",
            OperationId = "User.Login",
            Tags = new[] { "UserEndpoints" })
        ]
        public override async Task<ActionResult<UserResponse>> HandleAsync(LoginRequest loginRequest, CancellationToken cancellationToken)
        {
            var user = await _userservice.Login(loginRequest.Email, loginRequest.Password);

            if (user != null)
            {
                var token = await _userservice.GenerateJSONWebToken(user, HttpContext);
                return Ok(token);
            }

            return Unauthorized();
        }
    }
}
