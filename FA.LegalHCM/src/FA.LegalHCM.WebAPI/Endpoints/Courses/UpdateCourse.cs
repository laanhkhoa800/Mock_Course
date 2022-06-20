using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Courses
{
    public class UpdateCourse : BaseAsyncEndpoint
    {
        private readonly ICourseService _courseService;

        public UpdateCourse(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPut("/Course/Update")]
        [SwaggerOperation(
            Summary = "Updates a Course",
            Description = "Updates a ToDoItem with a longer description",
            OperationId = "Course.Update",
            Tags = new[] { "CourseEndpoints" })
        ]
        public async Task<ActionResult<Course>> HandleAsync(UpdateCourseRequest request, CancellationToken cancellationToken = default)
        {
            var item = await _courseService.GetDetailCourse(request.CourseId);
            item.Description = request.Description;
            item.Title = request.Title;
            item.Subtitle = request.Subtitle;
            item.OriginPrice = request.OriginPrice;
            item.Status = request.Status;
            item.TrailerUrl = request.TrailerUrl;
            item.ImageUrl = request.ImageUrl;
            
            await _courseService.UpdateCourse(item, request.Image, request.Video);
            return Ok(item);
        }
    }
}
