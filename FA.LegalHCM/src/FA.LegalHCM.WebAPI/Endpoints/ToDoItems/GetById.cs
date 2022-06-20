using System.Threading;
using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using System;

namespace FA.LegalHCM.Web.Endpoints.ToDoItems
{
    public class GetById : BaseAsyncEndpoint<Guid, ToDoItemResponse>
    {
        private readonly IRepository _repository;

        public GetById(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("/ToDoItem/{id:Guid}")]
        [SwaggerOperation(
            Summary = "Gets a single ToDoItem",
            Description = "Gets a single ToDoItem by Id",
            OperationId = "ToDoItem.GetById",
            Tags = new[] { "ToDoItemEndpoints" })
        ]
        public override async Task<ActionResult<ToDoItemResponse>> HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await _repository.GetByIdAsync<ToDoItem>(id);

            var response = new ToDoItemResponse
            {
                Id = item.Id,
                Description = item.Description,
                IsDone = item.IsDone,
                Title = item.Title
            };
            return Ok(response);
        }
    }
}
