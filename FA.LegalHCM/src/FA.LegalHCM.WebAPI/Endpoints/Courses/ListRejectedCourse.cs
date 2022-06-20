using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Courses
{
    public class ListRejectedCourse : BaseAsyncEndpoint<List<ListRejectedCourseResponse>>
    {
        private readonly ICourseService _courseService;

        public ListRejectedCourse(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet("/RejectedCourse")]
        [SwaggerOperation(
            Summary = "Gets a list of Rejected Course",
            Description = "Gets a list of Rejected Course",
            OperationId = "Course.ListRejectedCourse",
            Tags = new[] { "CourseEndpoints" })
        ]
        public override async Task<ActionResult<List<ListRejectedCourseResponse>>> HandleAsync(CancellationToken cancellationToken)
        {
            var items = (await _courseService.GetRejectedCourse<Course>())
                .Select(item => new ListRejectedCourseResponse
                {
                    Id = item.Id,
                    Price = item.OriginPrice,
                    Title = item.Title,
                    Status = item.Status,
                    UpdateAt = item.UpdateAt,
                    Category = item.SubCategory.Name
                });

            return Ok(items);
        }
    }
}
