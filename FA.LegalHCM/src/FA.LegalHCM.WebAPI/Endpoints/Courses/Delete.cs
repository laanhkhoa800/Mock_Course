using System.Threading;
using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using System;
using FA.LegalHCM.Core.Interfaces;
using System.Linq;
using System.Security.Claims;

namespace FA.LegalHCM.WebAPI.Endpoints.Courses
{
    public class Delete : BaseAsyncEndpoint
    {
        private readonly ICourseService _courseService;

        public Delete(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpDelete("/Courses/Section")]
        [SwaggerOperation(
            Summary = "Delete a Section of a Course",
            Description = "Delete a Section of a Course by SectionId",
            OperationId = "Course.Delete",
            Tags = new[] { "CourseEndpoints" })
        ]
        public async Task<ActionResult<bool>> SectionByIdAsync(Guid sectionId, CancellationToken cancellationToken)
        {
            //check Section must be owned by User logged in
            if (GetLoggedUserId() == await _courseService.GetUserIdBySectionId(sectionId))
            {
                //check value of request
                if (ModelState.IsValid)
                {
                    return Ok( await _courseService.DeleteSection(sectionId));
                }

                return BadRequest();
            }

            return Unauthorized();
        }

        private Guid GetLoggedUserId()
        {
            if (!User.Identity.IsAuthenticated)
                throw new System.Security.Authentication.AuthenticationException();

            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            return Guid.Parse(userId);
        }
    }
}
