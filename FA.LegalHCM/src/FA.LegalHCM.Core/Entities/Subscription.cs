using System;

namespace FA.LegalHCM.Core.Entities
{
    public class Subscription
    {
        public Guid UserId { get; set; }

        public Guid SubscriberId { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public bool IsDeleted { get; set; }

        //Navigation properties
        public virtual User User { get; set; }

        public virtual User Subscriper { get; set; }
    }
}
