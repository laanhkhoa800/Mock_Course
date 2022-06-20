using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace FA.LegalHCM.Core.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DOB { get; set; }

        public bool IsStatus { get; set; }

        public bool IsDeleted { get; set; }

        public bool Status { get; set; }

        public string Introduction { get; set; }

        public DateTime CreateAt { get; set; }

        public string FacebookLink { get; set; }

        public string LinkedLink { get; set; }

        public string YoutubeLink { get; set; }

        public string Avatar { get; set; }

        public decimal AvailableAmount { get; set; }

        public Guid RoleId { get; set; }

        //Navigation properties
        public virtual ICollection<Course> Courses { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<CourseCompletion> CourseCompletions { get; set; }

        public virtual ICollection<Discussion> Discussions { get; set; }

        public virtual ICollection<Discussion> DiscussionSenders { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public virtual ICollection<FavoritedCourse> FavoritedCourses { get; set; }

        public virtual ICollection<LessonCompletion> LessonCompletions { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual ICollection<Promotion> Promotions { get; set; }

        public virtual ICollection<QuestionAndAnswer> QuestionAndAnswers { get; set; }

        public virtual ICollection<QuizzCompletion> QuizzCompletions { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }

        public virtual ICollection<Subscription> Subscripers { get; set; }

        public virtual ICollection<UserQuizzAnswer> UserQuizzAnswers { get; set; }

        public virtual ICollection<Payout> Payouts { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }

        public virtual ICollection<DiscussionVote> DiscussionVotes { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
