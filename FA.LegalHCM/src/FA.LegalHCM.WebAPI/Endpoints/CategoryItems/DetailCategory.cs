using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.CategoryItems
{
    public class DetailCategory : BaseAsyncEndpoint<Guid, CategoryResponse>
    {
        private readonly ICategoryService _categoryService;

        public DetailCategory(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("/category/{id}")]
        [SwaggerOperation(
            Summary = "Gets a single Category",
            Description = "Gets a single Category by Id",
            OperationId = "Category.DetailCategory",
            Tags = new[] { "CategoryEndpoints" })
        ]
        public override async Task<ActionResult<CategoryResponse>> HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await _categoryService.GetCategoryById(id);

            var response = new CategoryResponse
            {
                Id = item.Id,
                Name = item.Name,
                Status = item.Status,
            };
            return Ok(response);
        }
    }
}
