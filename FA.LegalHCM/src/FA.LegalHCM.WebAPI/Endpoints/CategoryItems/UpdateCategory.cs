using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.WebAPI.Endpoints.CategoryItems.UpdateCategory;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints
{
    public class UpdateCategory : BaseAsyncEndpoint<UpdateToCategoryRequest, CategoryResponse>
    {
        private readonly ICategoryService _categoryService;

        public UpdateCategory(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPut("/updatecategory")]
        [SwaggerOperation(
            Summary = "Updates a category",
            Description = "Updates a category with a longer description",
            OperationId = "Category.Update",
            Tags = new[] { "CategoryEndpoints" })
        ]
        public override async Task<ActionResult<CategoryResponse>> HandleAsync(UpdateToCategoryRequest request, CancellationToken cancellationToken)
        {
            var existingItem =  await _categoryService.GetCategoryById(request.Id);
            if (existingItem == null) return BadRequest();
            else
            {
                existingItem.Name = request.Name;
                existingItem.Status = request.Status;
                existingItem.UpdateAt = DateTime.Now;
            }

            await _categoryService.UpdateCategory(existingItem);

            return Ok(existingItem);
        }

    }
}
