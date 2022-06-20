using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Payout
{
    public class List : BaseAsyncEndpoint
    {
        private readonly IPayoutService _payoutService;

        public List(IPayoutService payoutService)
        {
            _payoutService = payoutService;
        }

        [HttpGet("/Payout")]
        [SwaggerOperation(
            Summary = "Gets a list of all Payout",
            Description = "Gets a list of all Payout",
            OperationId = "Payout.List",
            Tags = new[] { "PayoutEndpoints" })
        ]
        public async Task<ActionResult<List<PayoutResponse>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var items = (await _payoutService.GetAllPayout())
                .Select(item => new PayoutResponse
                {
                    Id = item.Id,
                    Name = item.Instructor.UserName,
                    Amount = item.Price,
                    CreateAt = item.CreateAt,
                    Remark = item.Remark,
                    Update = item.Update,
                    Status = item.Status
                });
            return Ok(items);
        }
    }
}
