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

namespace FA.LegalHCM.WebAPI.Endpoints.SubCategories
{
    public class SearchCategory : BaseAsyncEndpoint
    {
        private readonly ISubCategoryService _subCategoryService;

        public SearchCategory(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        [HttpGet("/searchSubCategory")]
        [SwaggerOperation(
        Summary = "Gets a list of Search SubCategory",
        Description = "Gets a list of Search SubCategory",
        OperationId = "SubCategory.List",
        Tags = new[] { "SubCategoryEndpoints" })
        ]
        public  async Task<ActionResult<List<SubCategoryResponse>>> HandleAsync(string search)
        {
            var items = (await _subCategoryService.GetAllIncompleteItemsAsync(search))
                .Select(item => new SubCategoryResponse
                {
                    Name = item.Name,
                    CategoryId= item.CategoryId,
                    Status = item.Status
                });

            return Ok(items);
        }

    }
}
