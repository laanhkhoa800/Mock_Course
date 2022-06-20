using FA.LegalHCM.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.SharedKernel;
using Ardalis.EFCore.Extensions;
using System.Reflection;
using JetBrains.Annotations;
using MediatR;
using FA.LegalHCM.Infrastructure.Data.Config;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;

namespace FA.LegalHCM.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid>
    {
        private readonly IMediator _mediator;

        //public AppDbContext(DbContextOptions options) : base(options)
        //{
        //}

        public AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        #region Entities
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Assignment> Assigments { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseCompletion> CourseCompletions { get; set; }
        public DbSet<CourseRating> CourseRatings { get; set; }
        public DbSet<CourseReview> CourseReviews { get; set; }
        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<DiscussionVote> DiscussionVotes { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<FavoritedCourse> FavoritedCourses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonCompletion> LessonCompletions { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<QuestionAndAnswer> QuestionAndAnswers { get; set; }
        public DbSet<Quizz> Quizzes { get; set; }
        public DbSet<QuizzCompletion> QuizzCompletions { get; set; }
        public DbSet<QuizzQuestion> QuizzQuestions { get; set; }
        public override DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<UserQuizzAnswer> UserQuizzAnswers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Payout> Payouts { get; set; }
        public override DbSet<User> Users { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        
        public DbSet<Review> Reviews { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Config Fluent

            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();

            modelBuilder.ApplyConfiguration(new AssignmentConfiguration());
            modelBuilder.ApplyConfiguration(new AttachmentConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CourseCompletionConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new CourseRatingConfiguration());
            modelBuilder.ApplyConfiguration(new CourseReviewConfiguration());
            modelBuilder.ApplyConfiguration(new DiscussionConfiguration());
            modelBuilder.ApplyConfiguration(new EnrollmentConfiguration());
            modelBuilder.ApplyConfiguration(new FavoritedCourseConfiguration());
            modelBuilder.ApplyConfiguration(new LessonCompletionConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new PromotionConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionAndAnswerConfiguration());
            modelBuilder.ApplyConfiguration(new QuizzAnswerConfiguration());
            modelBuilder.ApplyConfiguration(new QuizzCompletionConfiguration());
            modelBuilder.ApplyConfiguration(new QuizzConfiguration());
            modelBuilder.ApplyConfiguration(new QuizzQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new SectionConfiguration());
            modelBuilder.ApplyConfiguration(new ShoppingCartConfiguration());
            modelBuilder.ApplyConfiguration(new SubscriptionConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserQuizzAnswerConfiguration());
            modelBuilder.ApplyConfiguration(new SubCategoryConfiguration());
            #endregion

            // Remove AspNet prefix of tables: by default, tables in IdentityDbContext have
            // name with AspNet prefix like: AspNetUserRoles, AspNetUser ...
            // The following code runs when initializing the DbContext, creating the database will remove that prefix
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
            if (_mediator == null) return result;

            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach (var domainEvent in events)
                {
                    await _mediator.Publish(domainEvent).ConfigureAwait(false);
                }
            }
            GenerateId();
            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }

        private void GenerateId()
        {
            var entries = ChangeTracker
                            .Entries()
                            .Where(e => e.Entity is BaseEntity && e.State == EntityState.Added);
            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).Id = Guid.NewGuid();
            }
        }

    }
}