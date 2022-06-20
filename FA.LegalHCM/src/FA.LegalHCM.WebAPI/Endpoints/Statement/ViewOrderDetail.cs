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
    public class ViewOrderDetail : BaseAsyncEndpoint
    {
        private readonly IStatementService _statementService;

        public ViewOrderDetail(IStatementService statementService)
        {
            _statementService = statementService;
        }

        [HttpGet("/Statement/ViewOrderDetail")]
        [SwaggerOperation(
            Summary = "Gets a OrderDetail",
            Description = "Gets a OrderDetail",
            OperationId = "Statement.ViewDetail",
            Tags = new[] { "StatementEndpoints" })
        ]
        public async Task<ActionResult<OrderDetailResponse>> GetAllAsync(Guid userId, Guid courseId, CancellationToken cancellationToken = default)
        {
            
            var items = (await _statementService.GetOrderById(userId, courseId));
            var response = new OrderDetailResponse()
            {
                Name = items.User.UserName,
                Email = items.User.Email,
                Title = items.Course.Title,
                PaymentToken = items.Course.PromotionId,
                Price = items.Course.OriginPrice,
                TotalAmount = items.Price,
                Day = items.PurchasedDay.ToString("dd MMMM yyyy")
            };
               
            return Ok(response);
        }

    }
}
