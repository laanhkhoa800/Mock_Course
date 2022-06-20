using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Entities;
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
    public class Create: BaseAsyncEndpoint
    {
        private readonly IReviewService _reviewService;
        public Create(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [HttpPost("/Create")]
        [SwaggerOperation(
            Summary = "Creates a new Review",
            Description = "Creates a new Review",
            OperationId = "Review.Create",
            Tags = new[] { "ReviewEndpoints" })
        ]
        public async Task<ActionResult<Review>> CreateGenaralInformationAsync(ReviewRequest request, CancellationToken cancellationToken)
        {
            
            if (ModelState.IsValid)
            {
                var item = new Review
                {
                    UserId = GetLoggedUserId(),
                    Content = request.Content,
                    EnrollmentId = request.EnrollmentId,
                    Rating = request.Rating
                };

                
                //create course
                var createdItem = await _reviewService.CreateReview(item);

                return Ok(createdItem.Id);
            }

            return BadRequest();
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
