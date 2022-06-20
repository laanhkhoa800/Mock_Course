using FA.LegalHCM.SharedKernel;
using System;

namespace FA.LegalHCM.Core.Entities
{
    public class Feedback:BaseEntity
    {
        public Guid UserId { get; set; }

        public DateTime CreateAt { get; set; }

        public string Email { get; set; }

        public string Document { get; set; }

        public string Content { get; set; }

        public virtual User User { get; set; }

        
    }
}
