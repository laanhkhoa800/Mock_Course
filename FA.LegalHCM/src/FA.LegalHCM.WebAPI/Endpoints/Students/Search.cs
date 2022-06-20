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
    public class Search : BaseAsyncEndpoint
    {
        private readonly IStudentService _studentService;

        public Search(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("/Student/Search")]
        [SwaggerOperation(
            Summary = "Search a list of all Students",
            Description = "Search a list of all Students",
            OperationId = "Student.Search",
            Tags = new[] { "StudentEndpoints" })
        ]
        public async Task<ActionResult<List<StudentResponse>>> GetAllAsync(CancellationToken cancellationToken, string search)
        {
            var items = (await _studentService.GetAllIncompleteItemsAsync(search))
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
