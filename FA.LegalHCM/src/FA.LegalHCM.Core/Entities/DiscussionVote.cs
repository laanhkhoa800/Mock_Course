using System;
using System.Collections.Generic;
using System.Text;

namespace FA.LegalHCM.Core.Entities
{
    public class DiscussionVote
    {
        public Guid UserId { get; set; }

        public Guid DiscussionId { get; set; }

        public bool IsLike { get; set; }

        //Navigation properties
        public virtual User User { get; set; }

        public virtual Discussion Discussion { get; set; }
    }
}
