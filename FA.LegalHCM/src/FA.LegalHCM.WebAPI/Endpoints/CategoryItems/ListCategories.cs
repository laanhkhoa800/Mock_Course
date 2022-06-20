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

namespace FA.LegalHCM.WebAPI.Endpoints.CategoryItems
{
    public class ListCategories : BaseAsyncEndpoint<List<CategoryResponse>>
    { 
        private readonly ICategoryService _categoryService;

        public ListCategories(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("/Category")]
        [SwaggerOperation(
             Summary = "Gets a list of all Category",
             Description = "Gets a list of all Category",
             OperationId = "Category.List",
             Tags = new[] { "CategoryEndpoints" })
        ]
        public override async Task<ActionResult<List<CategoryResponse>>> HandleAsync(CancellationToken cancellationToken)
        {
            var items = (await _categoryService.GetAllCategory())
               .Select(item => new CategoryResponse
               {
                   Id = item.Id,
                   Name = item.Name,
                   Status = item.Status
               });

            return Ok(items);
        }
    }
}
