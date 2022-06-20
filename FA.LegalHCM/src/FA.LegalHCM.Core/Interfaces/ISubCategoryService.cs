using Ardalis.Result;
using FA.LegalHCM.Core.Entities;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FA.LegalHCM.Core.Interfaces
{
    public interface ISubCategoryService
    {
        Task<List<SubCategory>> GetAllSubCategory();
        Task<SubCategory> GetSubCategoryById(Guid id);
        Task<SubCategory> CreateSubCategory(SubCategory subCategory);
        Task<SubCategory> DeleteSubCategory(SubCategory subCategory);
        Task<SubCategory> UpdateSubCategory(SubCategory subCategory);
        Task<SubCategory> GetNextIncompleteItemAsync();
        Task<List<SubCategory>> GetAllIncompleteItemsAsync(string searchString);
        Task<bool> IsSubCategoryNameExisted(string catename);
    }
}
