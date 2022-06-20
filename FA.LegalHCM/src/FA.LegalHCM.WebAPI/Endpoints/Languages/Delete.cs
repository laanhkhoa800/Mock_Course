using Ardalis.ApiEndpoints;
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
    public class Delete : BaseAsyncEndpoint
    {
        private readonly ILanguageService _service;

        public Delete(ILanguageService service)
        {
            _service = service;
        }

        [HttpDelete("/Languages/{id}")]
        [SwaggerOperation(
            Summary = "Deletes a Language",
            Description = "Deletes a Language",
            OperationId = "Language.Delete",
            Tags = new[] { "LanguageEndpoints" })
        ]
        public async Task<ActionResult> HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            if (await _service.DeleteLanguage(id))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
