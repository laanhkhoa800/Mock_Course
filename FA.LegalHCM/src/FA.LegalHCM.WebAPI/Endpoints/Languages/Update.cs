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
    public class Update : BaseAsyncEndpoint
    {
        private readonly ILanguageService _service;

        public Update(ILanguageService service)
        {
            _service = service;
        }

        [HttpPut("/Languages")]
        [SwaggerOperation(
            Summary = "Updates a Language",
            Description = "Updates a Language with a longer description",
            OperationId = "Language.Update",
            Tags = new[] { "LanguageEndpoints" })
        ]
        public async Task<ActionResult<UpdateLanguageRequest>> HandleAsync(UpdateLanguageRequest request, CancellationToken cancellationToken)
        {
            Language languageRequest = new Language
            {
                Id = request.Id,
                Name = request.Name,
                Status = request.Status
            };
            if (await _service.EditLanguage(request.Id, languageRequest))
            {
                return Ok(request);
            }
            return BadRequest();
        }
    }
}