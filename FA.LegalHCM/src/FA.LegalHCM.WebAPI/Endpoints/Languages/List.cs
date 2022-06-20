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

namespace FA.LegalHCM.WebAPI.Endpoints.Languages
{
    public class List : BaseAsyncEndpoint<List<LanguageResponse>>
    {
        private readonly ILanguageService _service;

        public List(ILanguageService service)
        {
            _service = service;
        }

        [HttpGet("/Languages")]
        [SwaggerOperation(
            Summary = "Gets a list of all Languages",
            Description = "Gets a list of all Languages",
            OperationId = "Language.List",
            Tags = new[] { "LanguageEndpoints" })
        ]
        public override async Task<ActionResult<List<LanguageResponse>>> HandleAsync(CancellationToken cancellationToken)
        {
            var items = (await _service.GetAllLanguages()).Select(item => new LanguageResponse
            {
                Id = item.Id,
                Name = item.Name,
                Status = item.Status,
                Courses = item.Courses
            }); 

            return Ok(items);
        }
    }
}
