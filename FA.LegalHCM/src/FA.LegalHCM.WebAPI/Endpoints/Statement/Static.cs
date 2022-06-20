using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Statement
{
    public class Static : BaseAsyncEndpoint
    {
        private readonly IStatementService _statementService;

        public Static(IStatementService statementService)
        {
            _statementService = statementService;
        }

        [HttpGet("/Statement/Static")]
        [SwaggerOperation(
            Summary = "Instructor's income statistics",
            Description = "Instructor's income statistics",
            OperationId = "Statement.Static",
            Tags = new[] { "StatementEndpoints" })
        ]
        public async Task<ActionResult<StaticResponse>> GetAllAsync(int month, CancellationToken cancellationToken = default)
        {
            if (!User.Identity.IsAuthenticated)
                throw new AuthenticationException();

            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var id = Guid.Parse(userId);
            var items = (await _statementService.GetAllByMonth(month, id));
            var response = new StaticResponse();
            response.Fund = items.Sum(x => x.Course.OriginPrice);
            response.Earning = items.Sum(x => x.Price);
            response.CursusFee = items.Sum(x => x.Course.OriginPrice * x.Course.Promotion.DiscountPercent);
            return Ok(response);
        }
    }
}
