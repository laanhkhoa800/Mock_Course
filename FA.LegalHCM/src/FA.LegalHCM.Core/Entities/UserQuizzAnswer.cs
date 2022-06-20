using System;

namespace FA.LegalHCM.Core.Entities
{
    public class UserQuizzAnswer
    {
        public Guid UserId { get; set; }

        public Guid QuizzAnswerId { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public bool IsDeleted { get; set; }

        //Navigation properties
        public virtual User User { get; set; }

        public virtual QuizzAnswer QuizzAnswer { get; set; }
    }
}
