using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.WebAPI.Endpoints.SubCategories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints
{
    public class DeleteSubCategory : BaseAsyncEndpoint<UpdateSubCategoryRequest, SubCategoryResponse>
    {
        private readonly ISubCategoryService _subCategoryService;

        public DeleteSubCategory(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        [HttpPut("/DeleteSubCategory")]
        [SwaggerOperation(
            Summary = "Delete a subcategory",
            Description = "Delete a subcategory with a longer description",
            OperationId = "SubCategory.Delete",
            Tags = new[] { "SubCategoryEndpoints" })
        ]
        public override  async Task<ActionResult<SubCategoryResponse>> HandleAsync(UpdateSubCategoryRequest request, CancellationToken cancellationToken)
        {
            var existingItem =  await _subCategoryService.GetSubCategoryById(request.Id);
            if (existingItem == null) return BadRequest();
            else
            {
                existingItem.IsDeleted = true;
            }

            await _subCategoryService.UpdateSubCategory(existingItem);

            return Ok(existingItem);
        }

    }
}
