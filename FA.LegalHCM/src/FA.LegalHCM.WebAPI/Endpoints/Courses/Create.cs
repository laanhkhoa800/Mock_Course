using System.Threading;
using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using FA.LegalHCM.Core.Interfaces;
using System;
using System.Linq;
using System.Security.Claims;
using FA.LegalHCM.Class;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace FA.LegalHCM.WebAPI.Endpoints.Courses
{
    public class Create : BaseAsyncEndpoint
    {
        private readonly ICourseService _courseService;

        public Create(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost("/Courses/Information")]
        [SwaggerOperation(
            Summary = "Creates a new Course",
            Description = "Creates a new Course",
            OperationId = "Course.Create",
            Tags = new[] { "CourseEndpoints" })
        ]
        public async Task<ActionResult<Guid>> CreateGenaralInformationAsync(CourseRequest request, CancellationToken cancellationToken)
        {
           
            if (ModelState.IsValid)
            {
                var item = new Course
                {
                    UserId = GetLoggedUserId(),
                    Title = request.Title,
                    Description = request.Description,
                    LanguageId = request.LanguageId,
                    SubCategoryId = request.SubCategoryId,
                };

                //determine origin price
                if (!request.IsFree)
                {
                    item.OriginPrice = request.Price * await _courseService.GetDiscount(request.PromotionId);

                    item.PromotionId = request.PromotionId;
                }
                else
                    item.OriginPrice = request.Price;

                //create course
                var createdItem = await _courseService.CreateCourse(item);

                return Ok(createdItem.Id);
            }

            return BadRequest();
        }

        [HttpPost("/Courses/Content")]
        [SwaggerOperation(
            Summary = "Creates a Course Content",
            Description = "Creates the Sections and Lessons",
            OperationId = "CourseContent.Create",
            Tags = new[] { "CourseEndpoints" })
        ]
        public async Task<ActionResult<Guid>> CreateCourseContentAsync([FromForm] CourseContent request, CancellationToken cancellationToken)
        {
            //check Course must be owned by User logged in
            if (await _courseService.CheckCourseOfUser(request.CourseId, GetLoggedUserId()))
            {
                //check value of request
                if (ModelState.IsValid)
                {
                    //create and return to result of that
                    return Ok(await _courseService.CreateCourseContent(request));
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
