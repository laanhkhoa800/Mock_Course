using FA.LegalHCM.SharedKernel;
using System;
using System.Collections.Generic;

namespace FA.LegalHCM.Core.Entities
{
    public class Enrollment : BaseEntity
    {
        public Guid UserId { get; set; }

        public Guid CourseId { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public bool IsDeleted { get; set; }

        //Navigation properties
        public virtual Course Course { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<CourseRating> CourseRatings { get; set; }

        public virtual ICollection<CourseReview> CourseReviews { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
