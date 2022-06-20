using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.WebAPI.ApiModels.InstructorItemDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Security.Authentication;
using System.Security.Claims;

namespace FA.LegalHCM.WebAPI.Endpoints.InstructorItems
{
    public class UploadAvatar : BaseAsyncEndpoint<UploadAvatarRequest, bool>
    {
        private readonly IInstructorService _instructorService;    
        public UploadAvatar (IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpPut("/instructor/change-avatar")]
        [SwaggerOperation(
            Summary = "Updates a ToDoItem",
            Description = "Updates a ToDoItem with a longer description",
            OperationId = "ToDoItem.Update",
            Tags = new[] { "InstructorItemEndpoints" })
        ]
        public override async Task<ActionResult<bool>> HandleAsync([FromForm] UploadAvatarRequest request, CancellationToken cancellationToken)
        {
            var response = await _instructorService.UploadAvatarAsync(request.Id, request.file);
            return Ok(response);
        }

     /*   private Guid GetLoggedUserId()
        {
            if (!User.Identity.IsAuthenticated)
                throw new AuthenticationException();

            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            return Guid.Parse(userId);
        }*/
    }
}
