using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.WebAPI.Endpoints.CategoryItems;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints
{
    public class DeleteCategory : BaseAsyncEndpoint<ChangeDelToCategoryRequest, CategoryResponse>
    {
        private readonly ICategoryService _categoryService;

        public DeleteCategory(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPut("/DeleteCategory")]
        [SwaggerOperation(
            Summary = "Delete a category",
            Description = "Delete a category with a longer description",
            OperationId = "Category.Delete",
            Tags = new[] { "CategoryEndpoints" })
        ]
        public override  async Task<ActionResult<CategoryResponse>> HandleAsync(ChangeDelToCategoryRequest request, CancellationToken cancellationToken)
        {
            var existingItem =  await _categoryService.GetCategoryById(request.Id);
            if (existingItem == null) return BadRequest();
            else
            {
                existingItem.IsDeleted = true;
            }
            await _categoryService.UpdateCategory(existingItem);

            return Ok(existingItem);
        }

    }
}
