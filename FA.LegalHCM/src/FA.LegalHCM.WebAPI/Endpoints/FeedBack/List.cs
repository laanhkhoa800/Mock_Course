using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.Core.Services;
using FA.LegalHCM.SharedKernel.Interfaces;
using FA.LegalHCM.Web.Endpoints.ToDoItems;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.FeedBack
{
    public class List : BaseAsyncEndpoint<List<Feedback>>
    {

        private readonly IFeedBackService _feedBackService;

            public List(IFeedBackService feedBackService)
            {
                _feedBackService = feedBackService;
            }

            [HttpGet("/FeedBack")]
            [SwaggerOperation(
                Summary = "Gets a list of all FeedBacks",
                Description = "Gets a list of all FeedBacks",
                OperationId = "FeedBack.List",
                Tags = new[] { "FeedBackEndpoints" })
            ]
            //get all list of feed back
            public override async Task<ActionResult<List<Feedback>>> HandleAsync(CancellationToken cancellationToken)
            {
                var items = (await _feedBackService.GetAllFeedBacks())
                .Select(item => new ListRepository
                {
                    FullName = item.User.FirstName + item.User.LastName,
                    Email = item.User.Email,
                    Content = item.Content,
                    Document = item.Document,
                    CreateAt = item.CreateAt
                });

            return Ok(items);
        }
        
    }
}
