using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Entities;
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
    public class Delete : BaseAsyncEndpoint<Guid, UserResponse>
    {
        public readonly IUserServices _userServices;
        public Delete(IUserServices userServices)
        {
            this._userServices = userServices;
        }

        [HttpDelete("/Users/{id:guid}")]
        [SwaggerOperation(
            Summary = "Deletes an User",
            Description = "Deletes an User",
            OperationId = "User.Delete",
            Tags = new[] { "UserEndpoints" })
        ]
        public override async Task<ActionResult<UserResponse>> HandleAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var itemToDelete = await _userServices.GetById(id);

            if (itemToDelete == null) return NotFound();

            await _userServices.Delete(itemToDelete);

            return NoContent();

        }
    }
}
