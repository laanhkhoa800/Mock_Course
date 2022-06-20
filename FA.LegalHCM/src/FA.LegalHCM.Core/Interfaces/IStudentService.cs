using Ardalis.Result;
using FA.LegalHCM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FA.LegalHCM.Core.Interfaces
{
    public interface IStudentService
    {
        Task<List<User>> GetAllAsync();

        Task<List<User>> GetAllIncompleteItemsAsync(string searchString);

        Task<List<User>> GetDetailStudentAsync(Guid id);

        Task Update(User user);

        Task<User> GetByIdAsync(Guid id);

        Task<List<Enrollment>> GetAllEnrollmentAsync(Guid id);

        Task<List<Discussion>> GetDiscussionAsync(Guid id);

        Task<CourseReview> GetcourseReviewAsync(Guid id);

        Task<CourseRating> GetcourseRatingAsync(Guid id);
    }
}
