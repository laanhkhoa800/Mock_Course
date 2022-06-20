using FA.LegalHCM.SharedKernel;
using System;

namespace FA.LegalHCM.Core.Entities
{
    public class Notification : BaseEntity
    {
        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string Detail { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsRead { get; set; }

        //Navigation property
        public virtual User User { get; set; }
    }
}
