using Ardalis.Specification;
using FA.LegalHCM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FA.LegalHCM.Core.Specifications
{
    public class StudentIncompleteItemsSpecification : Specification<User>
    {
        public StudentIncompleteItemsSpecification()
        {
            Query.Where(item => !item.IsDeleted && item.Role.Name == "Student");
        }

        public StudentIncompleteItemsSpecification(string search)
        {
            Query.Where(item => (!item.IsDeleted && item.Role.Name == "Student") && (item.Id.Equals(search) || item.Email.Contains(search) || item.IsStatus.Equals(search)));
        }

        public StudentIncompleteItemsSpecification(Guid id)
        {
            Query.Where(item => (!item.IsDeleted && item.Role.Name == "Student" && item.Id.Equals(id)));
        }

    }

    public class EnrollmentIncompleteItemsSpecification : Specification<Enrollment>
    {
        public EnrollmentIncompleteItemsSpecification(Guid id)
        {
            Query.Where(item => !item.IsDeleted && item.UserId.Equals(id)).Include(x => x.Course).ThenInclude(x => x.User);
        }
    }

    public class DiscussionIncompleteItemsSpecification : Specification<Discussion>
    {
        public DiscussionIncompleteItemsSpecification(Guid id)
        {
            Query.Where(item => !item.IsDeleted && item.SenderId.Equals(id)).Include(x => x.User);
        }
    }

    public class CourseRatingIncompleteItemsSpecification : Specification<CourseRating>
    {
        public CourseRatingIncompleteItemsSpecification(Guid id)
        {
            Query.Where(item => !item.IsDeleted && item.EnrollmentId.Equals(id)).Include(x => x.Enrollment);
        }
    }

    public class CourseRivewIncompleteItemsSpecification : Specification<CourseReview>
    {
        public CourseRivewIncompleteItemsSpecification(Guid id)
        {
            Query.Where(item => !item.IsDeleted && item.EnrollmentId.Equals(id)).Include(x => x.Enrollment);
        }
    }
}
