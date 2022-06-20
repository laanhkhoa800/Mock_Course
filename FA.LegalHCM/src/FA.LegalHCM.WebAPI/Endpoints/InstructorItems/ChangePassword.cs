using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.SharedKernel.Interfaces;
using FA.LegalHCM.WebAPI.ApiModels.InstructorItemDTO;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.InstructorItems
{
    public class ChangePassword : BaseAsyncEndpoint<UpdatePasswordRequest, bool>
    {
        private readonly IInstructorService _instructorService;

        public ChangePassword(IInstructorService instructorService)
        {
            _instructorService = instructorService ;
        }

        [HttpPut("/instructor/change-password")]
        [SwaggerOperation(
            Summary = "Updates a ToDoItem",
            Description = "Updates a ToDoItem with a longer description",
            OperationId = "ToDoItem.Update",
            Tags = new[] { "InstructorItemEndpoints" })
        ]
        public override async Task<ActionResult<bool>> HandleAsync([FromForm]UpdatePasswordRequest request, CancellationToken cancellationToken)
        {
            var response = await _instructorService.ChangePasswordAsync(request.Id, request.CurrentPassword, request.NewPassword, request.ConfirmPassword);
            return Ok(response);
        }
    }
}

