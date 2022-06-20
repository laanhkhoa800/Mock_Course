using Ardalis.Result;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.Core.Specifications;
using FA.LegalHCM.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.LegalHCM.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Do Add new category with Name, status 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<Category> CreateCategory(Category category)
        {
            var NewItem = await _categoryRepository.AddAsync(category);
            return NewItem;
        }

        public Task<Category> DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List categories call from Repository
        /// </summary>
        /// <returns></returns>
        public async Task<List<Category>> GetAllCategory()
        {
            var incompleteSpec = new CategoryIncompleteIsDeleteSpecificationv();
            var items = await _categoryRepository.ListAsync(incompleteSpec);
            return items;
        }

        /// <summary>
        /// Get categories from Name, des when contain value in text, Id equal Text 
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public async Task<List<Category>> GetAllIncompleteItemsAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                var errors = new List<ValidationError>();
                errors.Add(new ValidationError()
                {
                    Identifier = nameof(searchString),
                    ErrorMessage = $"{nameof(searchString)} is required."
                });
                return Result<List<Category>>.Invalid(errors);
            }
            var incompleteSpec = new SearchCategorySpecification(searchString);
            try
            {
                var checkDelete = new CategoryIncompleteIsDeleteSpecificationv();
                var items = await _categoryRepository.ListAsync(incompleteSpec);
                return new Result<List<Category>>(items);
            }
            catch (Exception ex)
            {
                return Result<List<Category>>.Error(new[] { ex.Message });
            }
        }
        /// <summary>
        /// Get Category by Id and display for CategoryResponse
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Category> GetCategoryById(Guid id)
        {
            return await _categoryRepository.GetByIdAsync<Category>(id);
        }

        public Task<Category> GetNextIncompleteItemAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Check Name by Specifications after get Category By Name 
        /// </summary>
        /// <param name="catename"></param>
        /// <returns></returns>
        public async Task<bool> IsCategoryNameExisted(string catename)
        {
            var incompleteSpec = new CategoryIncompleteItemsSpecification(catename);
            var items = await _categoryRepository.ListAsync(incompleteSpec);
            var a = items.Count;
            if (a == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Uodate category with Name anh Status, UodateAt = Datetime.Now
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<Category> UpdateCategory(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
            return category;
        }
    }
}
