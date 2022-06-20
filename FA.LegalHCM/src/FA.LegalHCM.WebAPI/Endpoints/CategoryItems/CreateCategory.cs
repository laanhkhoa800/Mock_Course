using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.CategoryItems
{
    public class CreateCategory : BaseAsyncEndpoint<NewCategory, CategoryResponse>
    {
        private readonly ICategoryService _categoryService;

        public CreateCategory(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("/AddCategory")]
        [SwaggerOperation(
            Summary = "Creates a new Category",
            Description = "Creates a new Category",
            OperationId = "Category.Create",
            Tags = new[] { "CategoryEndpoints" })
        ]
        public override async Task<ActionResult<CategoryResponse>> HandleAsync(NewCategory request, CancellationToken cancellationToken)
        {
            //Check value Name already exists in the data
            var checkName = await _categoryService.IsCategoryNameExisted(request.Name);
            if(checkName == true)
            {
                return Ok("Name already exists in the data!");
            }    
            var item = new Category
            {
                Name = request.Name,
                Status = request.Status,
                CreateAt =  DateTime.Now
            };
            var createdItem = await _categoryService.CreateCategory(item);

            return Ok(createdItem);
        }
    }
}
