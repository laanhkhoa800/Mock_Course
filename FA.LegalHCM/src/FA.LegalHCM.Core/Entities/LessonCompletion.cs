using System;

namespace FA.LegalHCM.Core.Entities
{
    public class LessonCompletion
    {
        public Guid LessonId { get; set; }

        public Guid UserId { get; set; }

        public DateTime? CompleteDate { get; set; }

        public bool IsDeleted { get; set; } = false;

        //Navigation property
        public virtual User User { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
