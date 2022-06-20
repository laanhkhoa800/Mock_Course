using FA.LegalHCM.SharedKernel;
using System;
using System.Collections.Generic;

namespace FA.LegalHCM.Core.Entities
{
    public class Discussion : BaseEntity
    {
        public Guid UserId { get; set; }

        public string Comment { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public bool IsDeleted { get; set; } = false;

        public Guid SenderId { get; set; }

        public int Like { get; set; }

        public int DisLike { get; set; }

        //Navigation properties
        public virtual User User { get; set; }

        public virtual User Sender { get; set; }

        public virtual ICollection<DiscussionVote> DiscussionVotes { get; set; }
    }
}
