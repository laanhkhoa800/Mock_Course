using System.Threading;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using System;
using FA.LegalHCM.Core.Interfaces;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace FA.LegalHCM.Web.Endpoints.Courses
{
    public class Update : BaseAsyncEndpoint
    {
        private readonly ICourseService _courseService;

        public Update(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPut("/Courses/Reject")]
        [SwaggerOperation(
            Summary = "Updates a Course",
            Description = "Updates a Course with status as Draff",
            OperationId = "Course.Update",
            Tags = new[] { "CourseEndpoints" })
        ]
        public async Task<bool> RejectedAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _courseService.RejectedCourse(id);
        }
        
        [HttpPut("/Courses/BestSeller")]
        [SwaggerOperation(
            Summary = "Updates a Course",
            Description = "Updates a Course with IsBestSeller as true or false",
            OperationId = "Course.Update",
            Tags = new[] { "CourseEndpoints" })
        ]
        public async Task<bool> BestSellerAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _courseService.BestSeller(id);
        }
        
        [HttpPut("/Courses/BlockedCourse")]
        [SwaggerOperation(
            Summary = "Updates a Course",
            Description = "Updates a Course with status as blocked or last status",
            OperationId = "Course.Update",
            Tags = new[] { "CourseEndpoints" })
        ]
        public async Task<bool> BlockedCourseAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _courseService.BlockedCourse(id);
        }
        
        [HttpPut("/Courses/Approval")]
        [SwaggerOperation(
            Summary = "Updates a Course",
            Description = "Updates a Course with status as approval",
            OperationId = "Course.Update",
            Tags = new[] { "CourseEndpoints" })
        ]
        public async Task<bool> ApprovedAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _courseService.ApprovedCourse(id);
        }
        
        [HttpPut("/Courses/Feature")]
        [SwaggerOperation(
            Summary = "Updates a Course",
            Description = "Updates a Course to Feature",
            OperationId = "Course.Update",
            Tags = new[] { "CourseEndpoints" })
        ]
        public async Task<bool> FeatureAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _courseService.Feature(id);
        }

        [HttpPut("/Courses/CreateView")]
        [SwaggerOperation(
            Summary = "Updates a Course",
            Description = "Updates a Course to Feature",
            OperationId = "Course.Update",
            Tags = new[] { "CourseEndpoints" })
        ]
        public async Task<ActionResult> CreateViewAsync(Guid courseId, IFormFile image, IFormFile trailer, CancellationToken cancellationToken)
        {
            //check Course must be owned by User logged in
            if(await _courseService.CheckCourseOfUser(courseId, GetLoggedUserId()))
            {
                //check value of request
                if(image != null && trailer != null)
                {
                    return Ok(await _courseService.UpdateView(courseId, image, trailer));    
                }

                return BadRequest();
            }

            return Unauthorized();
        }

        [HttpPut("/Courses/Extra")]
        [SwaggerOperation(
            Summary = "Updates a Course",
            Description = "Updates a Course to waiting for approved or draff",
            OperationId = "Course.Update",
            Tags = new[] { "CourseEndpoints" })
        ]
        public async Task<ActionResult> UpdateExtraAsync(Guid courseId, string status, CancellationToken cancellationToken)
        {
            //check Course must be owned by User logged in
            if (await _courseService.CheckCourseOfUser(courseId, GetLoggedUserId()))
            {
                //check value of request
                if (ModelState.IsValid)
                {
                    return Ok(await _courseService.UpdateExtra(courseId, status));
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
