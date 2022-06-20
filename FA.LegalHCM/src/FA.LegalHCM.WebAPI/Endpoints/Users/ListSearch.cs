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
    public class ListSearch : BaseAsyncEndpoint
    {
        private readonly IUserServices _userServices;
        public ListSearch(IUserServices userServices)
        {
            this._userServices = userServices;
        }

        [HttpGet("/SearchUsers")]
        [SwaggerOperation(
           Summary = "Search a list Users Search By Text",
           Description = "Gets a list Users Search By Text",
           OperationId = "User.ListSearch",
           Tags = new[] { "UserEndpoints" })
       ]
        public async Task<ActionResult<List<UserResponse>>> HandleAsync(string keyword, CancellationToken cancellationToken = default)
        {
            // Get List User Search by text
            var items = (await _userServices.SearchUser(keyword))
                .Select(item => new UserResponse
                {
                    Id = item.Id,
                    UserName = item.UserName,
                    RoleName = item.Role.Name
                });
            return Ok(items);
        }
    }
}
