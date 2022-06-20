using System;

namespace FA.LegalHCM.Core.Entities
{
    public class QuizzCompletion
    {
        public Guid QuizzId { get; set; }

        public Guid UserId { get; set; }

        public DateTime? CompleteDate { get; set; }

        public bool IsDeleted { get; set; }

        //Navigation properties
        public virtual Quizz Quizz { get; set; }

        public virtual User User { get; set; }
    }
}
