using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Students
{
    public class List : BaseAsyncEndpoint
    {
        private readonly IStudentService _studentService;

        public List(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("/Student")]
        [SwaggerOperation(
            Summary = "Gets a list of all Students",
            Description = "Gets a list of all Students",
            OperationId = "Student.List",
            Tags = new[] { "StudentEndpoints" })
        ]
        public async Task<ActionResult<List<StudentResponse>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var items = (await _studentService.GetAllAsync())
                .Select(x => new StudentResponse
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Email = x.Email,
                    IsStatus = x.IsStatus
                });

            return Ok(items);
        }
    }
}
