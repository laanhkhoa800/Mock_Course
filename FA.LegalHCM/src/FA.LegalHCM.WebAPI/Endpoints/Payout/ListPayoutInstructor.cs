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

namespace FA.LegalHCM.WebAPI.Endpoints.Payout
{
    public class ListPayoutInstructor : BaseAsyncEndpoint
    {
        private readonly IPayoutService _payoutService;
        public readonly IUserServices _userService;

        public ListPayoutInstructor(IPayoutService payoutService, IUserServices userService)
        {
            _payoutService = payoutService;
            _userService = userService;
        }

        [HttpGet("/Payout/AvailableAmount")]
        [SwaggerOperation(
            Summary = "Get Available Amount of instructor",
            Description = "Get Available Amount of instructor",
            OperationId = "AvailableAmount.Value",
            Tags = new[] { "PayoutEndpoints" })
        ]
        //Get Available Amount of instructor
        public async Task<ActionResult<decimal>> GetAvailableAmountAsync(CancellationToken cancellationToken = default)
        {
            //get id usser
            if (!User.Identity.IsAuthenticated)
                throw new AuthenticationException();

            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var id = Guid.Parse(userId);
            
            return Ok((await _userService.GetById(id)).AvailableAmount);
        }
        [HttpGet("/Payout/Instructor")]
        [SwaggerOperation(
            Summary = "Gets a list of all Payout",
            Description = "Gets a list of all Payout",
            OperationId = "Payout.ListPayoutInstructor",
            Tags = new[] { "PayoutEndpoints" })
        ]
        public async Task<ActionResult<List<PayoutInstructorResponse>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            // Get id instructor for token
            if (!User.Identity.IsAuthenticated)
                throw new AuthenticationException();

            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            var id = Guid.Parse(userId);

            var items = (await _payoutService.GetByInstructor(id))
                .Select(item => new PayoutInstructorResponse
                {
                    Amount = item.Price,
                    CreateAt = item.CreateAt,
                    Remark = item.Remark,
                    Update = item.Update,
                    Status = (item.Status == "Pandding")? "Processing":item.Status
                });
            return Ok(items);
        }
        
    }
}
