using FA.LegalHCM.SharedKernel;
using System;

namespace FA.LegalHCM.Core.Entities
{
    public class ShoppingCart : BaseEntity
    {
        public Guid UserId { get; set; }

        public Guid CourseId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        //Navigation properties
        public virtual Course Course { get; set; }

        public virtual User User { get; set; }

    }
}
