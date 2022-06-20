using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.DetailStudent
{
    public class DetailStudent : BaseAsyncEndpoint
    {
        private readonly IStudentService _studentService;

        public DetailStudent(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("/DetailStudent")]
        [SwaggerOperation(
            Summary = "Get detail student from student id",
            Description = "get detail student from student id",
            OperationId = "DetailStudent.List",
            Tags = new[] { "DetailStudentEndpoints" })
        ]

        ////get detail student from student id
        public async Task<ActionResult<List<DetailStudentResponse>>> GetDetailStudent(Guid id, CancellationToken cancellationToken)
        {
            var existingItem = await _studentService.GetByIdAsync(id);
            var item = new DetailStudentResponse();
            item.Id = existingItem.Id;
            item.UserName = existingItem.UserName;
            item.Email = existingItem.Email;
            item.IsStatus = existingItem.IsStatus;
            item.CountSubcription = existingItem.Subscriptions.Count;
            item.CountEnroll = existingItem.Enrollments.Count;
            return Ok(item);
        }
    }
}
