using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Reviews
{
    public class ListAllRating:BaseAsyncEndpoint
    {
        private readonly IReviewService _reviewService;
        public ListAllRating(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpGet("/ListAllRating")]
        [SwaggerOperation(
              Summary = "Gets a list of all ListAllRating",
              Description = "Gets a list of all ListAllRating",
              OperationId = "ListAllRating.List",
              Tags = new[] { "ReviewEndpoints" })
          ]
        public async Task<ActionResult<List<AllRatingResponse>>> GetAllRating(CancellationToken cancellationToken)
        {

            var items = (await _reviewService.GetAllRating(GetLoggedUserId()));
            var startRating = new AllRatingResponse();
            startRating.AllRating = items;
            return Ok(startRating);
        }
        private Guid GetLoggedUserId()
        {
            if (!User.Identity.IsAuthenticated)
                throw new System.Security.Authentication.AuthenticationException();
            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return Guid.Parse(userId);
        }
    }
}
