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
    public class Update : BaseAsyncEndpoint
    {
        private readonly IPayoutService _payoutService;
        private readonly IUserServices _userServices;

        public Update(IPayoutService payoutService, IUserServices userServices)
        {
            _payoutService = payoutService;
            _userServices = userServices;
        }

        [HttpPut("/Payout")]
        [SwaggerOperation(
            Summary ="Update a Payout",
            Description ="Update PAyout with remark and status",
            OperationId ="Payout.Update",
            Tags = new[] { "PayoutEndpoints" })
        ]
        public async Task<ActionResult<bool>> UpdatePayout(PayoutRequest payoutRequest, CancellationToken cancellationToken = default)
        {
            // Get Payout with Id
            var existingItem = await _payoutService.GetById(payoutRequest.Id);

            // Change status and add remark
            existingItem.Remark = payoutRequest.Remark;
            existingItem.Status = payoutRequest.Status;
            existingItem.Update = DateTime.Now;

            if(existingItem.Status == "Paid")
            {
                var exitInstructor = await _userServices.GetById(existingItem.InstructorId);
                exitInstructor.AvailableAmount -= Convert.ToDecimal(existingItem.Price);
                await _userServices.Update(exitInstructor);
            }
            return await _payoutService.UpdatePayout(existingItem);
        }
    }
}
