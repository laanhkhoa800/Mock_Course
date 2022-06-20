using Ardalis.ApiEndpoints;
using Ardalis.Result;
using AutoMapper;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.WebAPI.ApiModels.InstructorItemDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.InstructorItems
{
    public class UpdateProfile : BaseAsyncEndpoint<UpdateProfileRequest, object>
    {
        private readonly IInstructorService _instructorService;
        private readonly IMapper _mapper; 
    
        public UpdateProfile(IInstructorService instructorService, IMapper mapper)
        {
            _instructorService = instructorService;
            _mapper = mapper;    
        }

        [HttpPut("/instructor/edit-profile")]
        [SwaggerOperation(
            Summary = "Updates a ToDoItem",
            Description = "Updates a ToDoItem with a longer description",
            OperationId = "ToDoItem.Update",
            Tags = new[] { "InstructorItemEndpoints" })
        ]
        public override async Task<ActionResult<object>> HandleAsync([FromForm] UpdateProfileRequest request, CancellationToken cancellationToken)
        {

            
            Guid id = new Guid("d71c1ba2-a3d0-434a-ba3d-53c4faab51f8");
            //var userId = await _userManager.FindByIdAsync(User.Identity)
            var response = await _instructorService.UpdateProfileAsync(id, request.Email, request.UserName);

            if (response.Value != null)
            {
                var valueReturn = _mapper.Map<UpdateProfileResponse>(response.Value);
                var responseData = new Result<UpdateProfileResponse>(valueReturn);

                return Ok(responseData);
            }
          
            return Ok(Result<bool>.Error(response.Errors.First()));
        }

        /*public Guid GetLoggedUserId()
        {
            if (!User.Identity.IsAuthenticated)
                throw new AuthenticationException();

            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            return Guid.Parse(userId);
        }*/

    }
}
