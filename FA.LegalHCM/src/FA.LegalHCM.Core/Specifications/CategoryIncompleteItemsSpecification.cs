using Ardalis.Specification;
using FA.LegalHCM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FA.LegalHCM.Core.Specifications
{
    /// <summary>
    /// Fs check Name get category by Name
    /// </summary>
    class CategoryIncompleteItemsSpecification : Specification<Category>
    {
        public CategoryIncompleteItemsSpecification(string name)
        {
            Query.Where(item => item.Name.Equals(name));
        }
    }
    /// <summary>
    /// Query Search category
    /// </summary>
    public class SearchCategorySpecification : Specification<Category>
    {
        public SearchCategorySpecification(string search)
        {
            Query.Where(item => (item.IsDeleted == false && (item.Id.Equals(search) || item.Name.Contains(search) || item.Status.Equals(search))));
        }
    }
    /// <summary>
    /// Fs check IsDelete get list all categories when value is deleteen equals false
    /// </summary>
    public class CategoryIncompleteIsDeleteSpecificationv : Specification<Category>
    {
        public CategoryIncompleteIsDeleteSpecificationv()
        {
            Query.Where(item => item.IsDeleted == false);
        }
    }

}
