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
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        /// <summary>
        /// Do Add new category with pa category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public async Task<SubCategory> CreateSubCategory(SubCategory subCategory)
        {
            var NewItem = await _subCategoryRepository.AddAsync(subCategory);
            return NewItem;
        }

        public Task<SubCategory> DeleteSubCategory(SubCategory subCategory)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List categories call from Repository
        /// </summary>
        /// <returns></returns>
        public async Task<List<SubCategory>> GetAllSubCategory()
        {
            var incompleteSpec = new SubCategoryIncompleteIsDeleteSpecificationv();
            var items = await _subCategoryRepository.ListAsync(incompleteSpec);
            return items;
        }

        /// <summary>
        /// Get categories from Name, des when contain value in text, Id equal Text 
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public async Task<List<SubCategory>> GetAllIncompleteItemsAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                var errors = new List<ValidationError>();
                errors.Add(new ValidationError()
                {
                    Identifier = nameof(searchString),
                    ErrorMessage = $"{nameof(searchString)} is required."
                });
                return Result<List<SubCategory>>.Invalid(errors);
            }
            var incompleteSpec = new SearchSubCategorySpecification(searchString);
            try
            {
                var items = await _subCategoryRepository.ListAsync(incompleteSpec);
                return new Result<List<SubCategory>>(items);
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<List<SubCategory>>.Error(new[] { ex.Message });
            }
        }

        public async Task<SubCategory> GetSubCategoryById(Guid id)
        {
            return await _subCategoryRepository.GetByIdAsync<SubCategory>(id);
        }

        public Task<SubCategory> GetNextIncompleteItemAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsSubCategoryNameExisted(string catename)
        {
            var incompleteSpec = new SubCategoryIncompleteItemsSpecification(catename);
            var items = await _subCategoryRepository.ListAsync(incompleteSpec);
            var a = items.Count;
            if (a == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<SubCategory> UpdateSubCategory(SubCategory subCategory)
        {
            await _subCategoryRepository.UpdateAsync(subCategory);
            return subCategory;
        }
    }
}
