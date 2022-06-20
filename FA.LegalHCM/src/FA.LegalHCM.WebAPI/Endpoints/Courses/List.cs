using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Courses
{
    public class List : BaseAsyncEndpoint<List<ListResponse>>
    {
        private readonly ICourseService _courseService;

        public List(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("/Course")]
        [SwaggerOperation(
            Summary = "Gets a list of all Course",
            Description = "Gets a list of all Course",
            OperationId = "Course.List",
            Tags = new[] { "CourseEndpoints" })
        ]
        public override async Task<ActionResult<List<ListResponse>>> HandleAsync(CancellationToken cancellationToken)
        {
            var items = (await _courseService.GetAllCourse<Course>())
                .Select(item => new ListResponse
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
