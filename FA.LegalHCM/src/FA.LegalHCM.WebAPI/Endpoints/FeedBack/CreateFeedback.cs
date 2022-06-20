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

namespace FA.LegalHCM.WebAPI.Endpoints.FeedBack
{
    public class CreateFeedback : BaseAsyncEndpoint
    {
        private readonly IFeedBackService _feedBackService;

        public CreateFeedback(IFeedBackService feedBackService)
        {
            this._feedBackService = feedBackService;
        }

        [HttpPost("/FeedBack")]
        [SwaggerOperation(
           Summary = "Create a new Feedback",
           Description = "Create a new Feedback",
           OperationId = "FeedBack.Create",
           Tags = new[] { "FeedBackEndpoints" })
        ]
        public async Task<ActionResult> CreateNewFeedbackAsync([FromForm] NewFeedbackRequest request, CancellationToken cancellationToken)
        {
            if (!User.Identity.IsAuthenticated)
                throw new System.Security.Authentication.AuthenticationException();

            string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            Guid id = Guid.Parse(userId);

            if (ModelState.IsValid)
            {
                Feedback item = new Feedback
                {
                    UserId = id,
                    Email = request.Email,
                    Content = request.Content,
                    Document = await _feedBackService.UploadFile( request.Document),
                    CreateAt = DateTime.Now
                };
                var feed = await _feedBackService.AddNewFeedback(item);
                return Ok(feed);
            }

            return BadRequest();
        }

    }
}
