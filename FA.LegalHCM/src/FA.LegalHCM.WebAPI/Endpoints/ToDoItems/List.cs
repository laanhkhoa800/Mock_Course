using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.Web.Endpoints.ToDoItems
{
    //[Authorize]
    public class List : BaseAsyncEndpoint<List<ToDoItemResponse>>
    {
        private readonly IRepository _repository;

        public List(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("/ToDoItems")]
        [SwaggerOperation(
            Summary = "Gets a list of all ToDoItems",
            Description = "Gets a list of all ToDoItems",
            OperationId = "ToDoItem.List",
            Tags = new[] { "ToDoItemEndpoints" })
        ]
        public override async Task<ActionResult<List<ToDoItemResponse>>> HandleAsync(CancellationToken cancellationToken)
        {
            //Guid userId = GetLoggedUserId();
            var items = (await _repository.ListAsync<ToDoItem>())
                .Select(item => new ToDoItemResponse
                {
                    Id = item.Id,
                    Description = item.Description,
                    IsDone = item.IsDone,
                    Title = item.Title
                });

            return Ok(items);
        }

        // Test getCurrentUser
        //Guid GetLoggedUserId()
        //{
        //    if (!User.Identity.IsAuthenticated)
        //        throw new AuthenticationException();
        //    string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
        //    return Guid.Parse(userId);
        //}
    }
}
