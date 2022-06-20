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
    public class List : BaseAsyncEndpoint
    {
        private readonly IStatementService _statementService;

        public List(IStatementService statementService)
        {
            _statementService = statementService;
        }

        [HttpGet("/Statement")]
        [SwaggerOperation(
            Summary = "Gets a list of all Statement",
            Description = "Gets a list of all Statement",
            OperationId = "Statement.List",
            Tags = new[] { "StatementEndpoints" })
        ]
        public async Task<ActionResult<List<StatementResponse>>> GetAllAsync(int month, CancellationToken cancellationToken = default)
        {
            // Get id instructor for token
            if (!User.Identity.IsAuthenticated)
                throw new AuthenticationException();

            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var id = Guid.Parse(userId);

            var items = (await _statementService.GetAllByMonth(month, id))
                .Select(item => new StatementResponse
                {
                    UserId = item.UserId,
                    CourseId = item.CourseId,
                    Date = item.PurchasedDay.ToString("dd MMMM yyyy"),
                    Type = item.Type,
                    Title = item.Course.Title,
                    Amount = item.Price,
                    Fee = item.Course.Promotion.DiscountPercent
                });
            return Ok(items);
        }
    }
}
