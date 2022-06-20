using Ardalis.Result;
using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.Core.Specifications;
using FA.LegalHCM.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.LegalHCM.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentReponsitory _studentReponsitory;
        private readonly IRepository _repository;

        public StudentService(IStudentReponsitory studentReponsitory, IRepository repository)
        {
            _studentReponsitory = studentReponsitory;
            _repository = repository;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var incompleteSpec = new StudentIncompleteItemsSpecification();
            var item = await _studentReponsitory.ListAsync(incompleteSpec);
            return item;
            //if (!item.Any())
            //{
            //    return Result<User>.NotFound();
            //}

            //return new Result<User>(item.First());
            
        }

        public async Task<List<Enrollment>> GetAllEnrollmentAsync(Guid id)
        {
            var incompleteSpec = new EnrollmentIncompleteItemsSpecification(id);

            try
            {
                return await _repository.ListAsync<Enrollment>(incompleteSpec);
            }
            catch(Exception ex)
            {
                // TODO: Log details here
                return Result<List<Enrollment>>.Error(new[] { ex.Message });
            }
           
        }

        public async Task<List<User>> GetAllIncompleteItemsAsync(string searchString)
        {
            if(string.IsNullOrEmpty(searchString))
            {
                var errors = new List<ValidationError>();
                errors.Add(new ValidationError()
                {
                    Identifier = nameof(searchString),
                    ErrorMessage = $"{nameof(searchString)} is required."
                });
                return Result<List<User>>.Invalid(errors);
            }

            var incompleteSpec = new StudentIncompleteItemsSpecification(searchString);

            try
            {
                var items = await _studentReponsitory.ListAsync(incompleteSpec);

                return new Result<List<User>>(items);
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<List<User>>.Error(new[] { ex.Message });
            }
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            try
            {
                return await _studentReponsitory.ListStudentAsync<User>().Include(u => u.Enrollments).Include(u => u.Subscriptions).Where(u => u.Id == id && u.IsDeleted == false).SingleOrDefaultAsync();
            }
            catch(Exception ex)
            {
                // TODO: Log details here
                return Result<User>.Error(new[] { ex.Message });
            }
        }

        public async Task<CourseRating> GetcourseRatingAsync(Guid id)
        {
            try
            {
                return await _studentReponsitory.ListStudentAsync<CourseRating>().Where(item => !item.IsDeleted && item.EnrollmentId.Equals(id)).Include(x => x.Enrollment).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<CourseRating>.Error(new[] { ex.Message });
            }
        }

        public async Task<CourseReview> GetcourseReviewAsync(Guid id)
        {
            try
            {
                return await _studentReponsitory.ListStudentAsync<CourseReview>().Where(item => !item.IsDeleted && item.EnrollmentId.Equals(id)).Include(x => x.Enrollment).SingleOrDefaultAsync(); ;
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<CourseReview>.Error(new[] { ex.Message });
            }
        }

        public async Task<List<User>> GetDetailStudentAsync(Guid id)
        {
            var i = new StudentIncompleteItemsSpecification(id);
            var item = await _studentReponsitory.ListAsync(i);
            return item;
        }

        public async Task<List<Discussion>> GetDiscussionAsync(Guid id)
        {

            var incompleteSpec = new DiscussionIncompleteItemsSpecification(id);

            try
            {
                return await _repository.ListAsync<Discussion>(incompleteSpec);
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<List<Discussion>>.Error(new[] { ex.Message });
            }
        }

        public async Task Update(User user)
        {
            await _studentReponsitory.UpdateAsync<User>(user);
        }

        //public async Task<List<User>> GetAllListCourseAsync(Guid id)
        //{
        //    var item = await _studentReponsitory;
        //    return item;
        //}

        //public async Task<Result<User>> GetAllAsync()
        //{
        //    var incompleteSpec = new StudentIncompleteItemsSpecification();

        //    var items = await _studentReponsitory.ListAsync(incompleteSpec);

        //    if (!items.Any())
        //    {
        //        return Result<User>.NotFound();
        //    }

        //    return new Result<User>(items.First());
        //}
    }
}
