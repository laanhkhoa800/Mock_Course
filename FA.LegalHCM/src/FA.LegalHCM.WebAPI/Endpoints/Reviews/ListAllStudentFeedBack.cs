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
    public class ListAllStudentFeedBack: BaseAsyncEndpoint
    {
        private readonly IReviewService _reviewService;
        public ListAllStudentFeedBack(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpGet("/ListAllStudentFeedBack")]
        [SwaggerOperation(
              Summary = "Gets a list of all ListAllStudentFeedBack",
              Description = "Gets a list of all ListAllStudentFeedBack",
              OperationId = "ListAllStudentFeedBack.List",
              Tags = new[] { "ReviewEndpoints" })
          ]
        public async Task<ActionResult<List<StarRatingResponse>>> GetAllReviews(CancellationToken cancellationToken)
        {

            var items = (await _reviewService.GetAVGRating(GetLoggedUserId()));
            var startRating = new StarRatingResponse();
            startRating.OneStar = items[0];
            startRating.TwoStar = items[1];
            startRating.ThreeStar = items[2];
            startRating.FourStar = items[3];
            startRating.FiveStar = items[4];
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
