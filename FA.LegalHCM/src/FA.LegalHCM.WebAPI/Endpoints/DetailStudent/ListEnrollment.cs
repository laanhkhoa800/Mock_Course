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
    public class ListEnrollment : BaseAsyncEndpoint
    {
        private readonly IStudentService _studentService;

        public ListEnrollment(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("/DetailStudent/Enrollment")]
        [SwaggerOperation(
            Summary = "Get Enrollment list from student id",
            Description = "Get Enrollment list from student id",
            OperationId = "DetailStudent.Enrollment",
            Tags = new[] { "DetailStudentEndpoints" })
        ]

        //get Enrollment list from student id
        public async Task<ActionResult<List<EnrollmentResponse>>> GetAllEnrollmentAsync(Guid id, CancellationToken cancellationToken)
        {
            var items = (await _studentService.GetAllEnrollmentAsync(id))
                .Select(x => new EnrollmentResponse
                {
                    Id = x.Id,
                    Title = x.Course.Title,
                    InstructorName = x.Course.User.UserName,
                    Price = x.Course.OriginPrice,
                    DateBuy = x.CreateAt
                });

            return Ok(items);
        }
    }
}
