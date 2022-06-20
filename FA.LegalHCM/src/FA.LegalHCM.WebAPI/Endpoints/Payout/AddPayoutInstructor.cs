using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;

using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Payout
{
    public class AddPayoutInstructor : BaseAsyncEndpoint
    {
        private readonly IPayoutService _payoutService;
        private readonly IUserServices _userServices;

        public AddPayoutInstructor(IPayoutService payoutService, IUserServices userServices)
        {
            _payoutService = payoutService;
            _userServices = userServices;
        }

        [HttpPost("/Payout/InsertPayout")]
        [SwaggerOperation(
            Summary = "instructor sends payout request to admin",
            Description = "instructor sends payout request to admin",
            OperationId = "Payout.Insert",
            Tags = new[] { "PayoutEndpoints" })
        ]
        public async Task<ActionResult<PayoutInstructorResponse>> GetAllAsync(double amount, CancellationToken cancellationToken = default)
        {
            if (ModelState.IsValid)
            {
                // Get id instructor for token
                if (!User.Identity.IsAuthenticated)
                    throw new AuthenticationException();

                string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

                var id = Guid.Parse(userId);

                var availableAmount = (await _userServices.GetById(id)).AvailableAmount;
                if (availableAmount >= Convert.ToDecimal(amount))
                {
                    Core.Entities.Payout newPayout = new Core.Entities.Payout()
                    {
                        InstructorId = id,
                        Price = amount,
                        CreateAt = DateTime.Now,
                        Update = DateTime.Now,
                        Status = "Panđing"
                    };

                    var result = await _payoutService.InsertPayout(newPayout);
                    if (result)
                    {
                        var response = new PayoutInstructorResponse()
                        {
                            Amount = newPayout.Price,
                            CreateAt = newPayout.CreateAt,
                            Status = newPayout.Status,
                            Remark = newPayout.Remark,
                            Update = newPayout.Update
                        };
                        return Ok(response);
                    }
                    else return Ok();
                }
                else return Ok();
            }
            return Ok();
        }
    }
}
