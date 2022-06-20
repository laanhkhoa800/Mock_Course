using Ardalis.ApiEndpoints;
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
    public class BackToDraft : BaseAsyncEndpoint
    {
        private readonly ICourseService _courseService;

        public BackToDraft(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPut("/Courses/BackToDraft")]
        [SwaggerOperation(
            Summary = "Updates a Course",
            Description = "Updates a Course with status as blocked or last status",
            OperationId = "Course.BackToDraft",
            Tags = new[] { "CourseEndpoints" })
        ]
        public async Task<bool> HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _courseService.DraftCourse(id);
        }
    }
}
