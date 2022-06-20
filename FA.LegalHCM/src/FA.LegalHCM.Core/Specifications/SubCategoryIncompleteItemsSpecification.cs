using Ardalis.Specification;
using FA.LegalHCM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FA.LegalHCM.Core.Specifications
{
    class SubCategoryIncompleteItemsSpecification : Specification<SubCategory>
    {
        public SubCategoryIncompleteItemsSpecification(string name)
        {
            Query.Where(item => item.Name.Equals(name));
        }
    }
    public class SearchSubCategorySpecification : Specification<SubCategory>
    {
        public SearchSubCategorySpecification(string search)
        {
            Query.Where(item => (item.IsDeleted == false && (item.Id.Equals(search) || item.Name.Contains(search) || item.Status.Equals(search) || item.Category.Name.Contains(search))));
        }
    }
    public class SubCategoryIncompleteIsDeleteSpecificationv : Specification<SubCategory>
    {
        public SubCategoryIncompleteIsDeleteSpecificationv()
        {
            Query.Where(item => item.IsDeleted == false);
        }
    }
}
