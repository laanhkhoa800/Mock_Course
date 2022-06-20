using FA.LegalHCM.SharedKernel;
using System;

namespace FA.LegalHCM.Core.Entities
{
    public class Attachment : BaseEntity
    {
        public Guid AssignmentId { get; set; }

        public string FileUrl { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public bool IsDeleted { get; set; } = false;

        //Navigation property
        public virtual Assignment Assignment { get; set; }
    }
}
