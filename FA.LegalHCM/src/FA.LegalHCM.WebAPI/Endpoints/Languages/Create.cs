using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Languages
{
    public class Create : BaseAsyncEndpoint
    {
        private readonly ILanguageService _service;

        public Create(ILanguageService service)
        {
            _service = service;
        }

        [HttpPost("/Languages")]
        [SwaggerOperation(
            Summary = "Creates a new Language",
            Description = "Creates a new Language",
            OperationId = "Language.Create",
            Tags = new[] { "LanguageEndpoints" })
        ]
        public async Task<ActionResult<Language>> HandleAsync(LanguageRequest language, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                Language newLanguage = new Language
                {
                    Name = language.Name,
                    Status = language.Status
                };

                var createdLanguage = await _service.AddLanguage(newLanguage);

                if (createdLanguage != null)
                {
                    return Ok(newLanguage);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }          
        }
    }
}
