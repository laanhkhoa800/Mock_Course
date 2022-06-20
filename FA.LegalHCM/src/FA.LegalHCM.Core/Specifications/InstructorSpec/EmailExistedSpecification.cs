using Ardalis.Specification;
using FA.LegalHCM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FA.LegalHCM.Core.Specifications.InstructorSpec
{
    public class EmailExistedSpecification : Specification<User>
    {
        public EmailExistedSpecification(string email)
        {
            Query.Where(item => item.Email.Equals(email));
        }

    }
}
