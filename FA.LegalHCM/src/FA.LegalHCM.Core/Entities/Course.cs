using FA.LegalHCM.SharedKernel;
using FA.LegalHCM.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace FA.LegalHCM.Core.Entities
{
    public class Course : BaseEntity
    {
        public Guid SubCategoryId { get; set; }

        public Guid UserId { get; set; }

        public Guid LanguageId { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public Guid? PromotionId { get; set; }

        public decimal OriginPrice { get; set; }

        public string TrailerUrl { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsPublished { get; set; }

        public string Status { get; set; }

        public bool IsBlocked { get; set; }

        public bool IsBestSeller { get; set; }

        public bool IsFeatured { get; set; }

        public bool IsRejected { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        //Navigation properties
        public virtual SubCategory SubCategory { get; set; }
        public virtual User User { get; set; }
        public virtual Promotion Promotion { get; set; }
        public virtual Language Language { get; set; }

        public virtual ICollection<CourseCompletion> CourseCompletions { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<FavoritedCourse> FavoritedCourses { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<QuestionAndAnswer> QuestionAndAnswers { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
