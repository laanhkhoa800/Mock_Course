using FA.LegalHCM.SharedKernel;
using System;
using System.Collections.Generic;

namespace FA.LegalHCM.Core.Entities
{
    public class Promotion : BaseEntity
    {
        public Guid UserId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime? UpdateAt { get; set; }

        public DateTime CreateAt { get; set; }

        public decimal DiscountPercent { get; set; }

        public bool IsDeleted { get; set; }

        //Navigation properties
        public virtual User User { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
