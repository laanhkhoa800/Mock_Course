using Ardalis.Specification;
using FA.LegalHCM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FA.LegalHCM.Core.Specifications
{
    public class ListUserNotDeleteSpecification : Specification<User>
    {
        public ListUserNotDeleteSpecification()
        {
            Query.Where(item => item.IsDeleted == false).Include(item =>item.Role);
        }
    }
}
