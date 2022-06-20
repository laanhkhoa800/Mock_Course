using Ardalis.Specification;
using FA.LegalHCM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FA.LegalHCM.Core.Specifications
{
    class NotificationSpecification : Specification<Notification>
    {
        public NotificationSpecification(Guid id)
        {
            Query.Where(item =>item.IsDeleted.Equals(false) && item.UserId.Equals(id));
        }
    }
}
