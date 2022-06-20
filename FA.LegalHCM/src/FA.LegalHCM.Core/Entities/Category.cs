using FA.LegalHCM.SharedKernel;
using System;
using System.Collections.Generic;

namespace FA.LegalHCM.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public bool Status { get; set; } = false;

        public bool IsDeleted { get; set; } = false;

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        //Navigation property
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
