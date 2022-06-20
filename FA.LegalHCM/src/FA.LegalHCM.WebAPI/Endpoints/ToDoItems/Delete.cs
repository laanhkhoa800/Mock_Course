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
    public class Delete : BaseAsyncEndpoint<Guid,ToDoItemResponse>
    {
        private readonly IRepository _repository;

        public Delete(IRepository repository)
        {
            _repository = repository;
        }

        [HttpDelete("/ToDoItems/{id:int}")]
        [SwaggerOperation(
            Summary = "Deletes a ToDoItem",
            Description = "Deletes a ToDoItem",
            OperationId = "ToDoItem.Delete",
            Tags = new[] { "ToDoItemEndpoints" })
        ]
        public override async Task<ActionResult<ToDoItemResponse>> HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            var itemToDelete = await _repository.GetByIdAsync<ToDoItem>(id);
            if (itemToDelete == null) return NotFound();

            await _repository.DeleteAsync<ToDoItem>(itemToDelete);

            return NoContent();
        }
    }
}
