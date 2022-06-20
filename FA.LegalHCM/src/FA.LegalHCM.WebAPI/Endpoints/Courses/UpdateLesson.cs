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
    public class UpdateLesson : BaseAsyncEndpoint
    {
        private readonly ICourseService _courseService;

        public UpdateLesson(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPut("/Course/Lesson/Update")]
        [SwaggerOperation(
            Summary = "Updates a ToDoItem",
            Description = "Updates a ToDoItem with a longer description",
            OperationId = "Course.UpdateLesson",
            Tags = new[] { "CourseEndpoints" })
        ]
        public async Task<ActionResult<Lesson>> UpdateLessonAsync(UpdateLessonRequest request, CancellationToken cancellationToken = default)
        {
            Lesson item = new Lesson()
            {
                Id = request.Id,
                Title = request.Title,
                TotalTime = request.TimeTotal,
                Volume = request.Volume,
                Duration = request.Duration,
                UpdateAt = request.UpdateAt,

            };

            await _courseService.UpdateLesson(item, request.File);
            return Ok(item);
        }
    }
}
