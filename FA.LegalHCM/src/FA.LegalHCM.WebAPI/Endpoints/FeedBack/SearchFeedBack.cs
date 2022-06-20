using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.FeedBack
{
    public class SeachFeedBack : BaseAsyncEndpoint
    {
        private readonly IFeedBackSearchService _feedBackSearchService;
        public SeachFeedBack(IFeedBackSearchService feedBackSearchService)
        {
            _feedBackSearchService = feedBackSearchService;
        }
        [HttpGet("/Search/input")]
        [SwaggerOperation(Summary = "Search a feedback all FeedBack",
            Description = "Gets a list of all FeedBack",
            OperationId = "FeedBack.SearchFeedBack",
            Tags = new[] { "FeedBackEndpoints" })]
        //search feedback by text
        public async Task<ActionResult<List<Feedback>>> SearchFeedBack(string input, CancellationToken cancellationToken = default)
        {
            var items = (await _feedBackSearchService.SearchFeedBack(input))
                .Select(item => new FeedBackReponse
                {
                    FullName = item.User.FirstName + item.User.LastName,
                    Email = item.Email,
                    CreateAt = item.CreateAt,
                    Content = item.Content,
                    Document=item.Document
                });
            return Ok(items);
        }
    }
}
