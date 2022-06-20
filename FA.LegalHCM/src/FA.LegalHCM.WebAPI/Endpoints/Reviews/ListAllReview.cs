using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.WebAPI.Endpoints.DetailStudent;
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
    public class ListAllReview: BaseAsyncEndpoint
    {
        private readonly IReviewService _reviewService;
        public ListAllReview(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }


        [HttpGet("/ListAllReview")]
        [SwaggerOperation(
               Summary = "Gets a list of all ListAllReview",
               Description = "Gets a list of all ListAllReview",
               OperationId = "ListAllReview.List",
               Tags = new[] { "ReviewEndpoints" })
           ]
        public  async Task<ActionResult<List<ReviewsReponse>>> GetAllReviews(CancellationToken cancellationToken)
        {
            var items = (await _reviewService.GetAllReviews(GetLoggedUserId()))
            .Select(item => new ReviewsReponse
            {
                Id = item.Id,
                UserId = item.UserId,
                Rating =item.Rating,
                Content =item.Content,
                CreateAt = item.CreateAt
            });
            return Ok(items);
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
