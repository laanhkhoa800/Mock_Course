using System;

namespace FA.LegalHCM.Core.Entities
{
    public class FavoritedCourse
    {
        public Guid CourseId { get; set; }

        public Guid UserId { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        //Navigation properties
        public virtual Course Course { get; set; }

        public virtual User User { get; set; }
    }
}
