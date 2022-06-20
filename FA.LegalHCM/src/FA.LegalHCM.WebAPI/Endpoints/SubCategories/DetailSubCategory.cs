using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.SubCategories
{
    public class DetailSubCategory : BaseAsyncEndpoint<Guid, SubCategoryResponse>
    {
        private readonly ISubCategoryService _subCategoryService;

        public DetailSubCategory(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        [HttpGet("/subcategory/{id}")]
        [SwaggerOperation(
            Summary = "Gets a single subCategory",
            Description = "Gets a single SubCategory by Id",
            OperationId = "SubCategory.DetailSubCategory",
            Tags = new[] { "SubCategoryEndpoints" })
        ]
        public override async Task<ActionResult<SubCategoryResponse>> HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await _subCategoryService.GetSubCategoryById(id);

            var response = new SubCategoryResponse
            {
                Id = item.Id,
                CategoryId = item.CategoryId,
                Name = item.Name,
                Status = item.Status,
            };
            return Ok(response);
        }
    }
}
