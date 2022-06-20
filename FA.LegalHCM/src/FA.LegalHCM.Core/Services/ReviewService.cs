using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.Core.Interfaces;
using FA.LegalHCM.Core.Specifications;
using FA.LegalHCM.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.LegalHCM.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository _repository;

        public ReviewService(IRepository repository)
        {
            _repository = repository;
        }
        /// <summary> 
        /// create new review of courses
        /// </summary>
        /// <param name="review">Param is Review Object</param>
        /// <returns>New review</returns>
        public async Task<Review> CreateReview(Review review)
        {
            review.CreateAt = DateTime.Now;

            return await _repository.AddAsync<Review>(review);
        }
        /// <summary>
        /// get avg value of all rating
        /// </summary>
        /// <param name="userId">Param is Review object</param>
        /// <returns>agv value of all rating</returns>
        public async Task<double> GetAllRating(Guid userId)
        {
            var getAVGRating = new GetEnrollmentById(userId);
            var onestar = 0;
            var twostar = 0;
            var threestar = 0;
            var fourstar = 0;
            var fivestar = 0;
            var total = 0;
            var star1 = 1;
            var star2 = 2;
            var star3 = 3;
            var star4 = 4;
            var star5 = 5;
            var allrating = 0;
            //get list course by id user
            IQueryable<Enrollment> getid = await _repository.ListReview<Enrollment>(getAVGRating);
            //count star of rating
            foreach (Enrollment x in getid)
            {
                onestar += x.Reviews.Where(s => s.Rating == 1).Count();
                twostar += x.Reviews.Where(s => s.Rating == 2).Count();
                threestar += x.Reviews.Where(s => s.Rating == 3).Count();
                fourstar += x.Reviews.Where(s => s.Rating == 4).Count();
                fivestar += x.Reviews.Where(s => s.Rating == 5).Count();

            }
            //sum count star of rating
            total = onestar + twostar + threestar + fourstar + fivestar;
            //get avg of all rating
            allrating = ((star1 * onestar) + (star2 * twostar) + (star3 * threestar) + (star4 * fourstar) + (star5 * fivestar)) / total;
            //return avg all rating
            return allrating;
            
        }

        /// <summary>
        /// get all list of review
        /// </summary>
        /// <param name="input">param is Review Object</param>
        /// <returns>list of review</returns>
        public async Task<List<Review>> GetAllReviews(Guid userId)
        {
            var getById = new GetAllReview(userId);
            var items = await _repository.ListAsync<Review>(getById);
            return items;
        }
        /// <summary>
        /// get all rating of student feedback 
        /// </summary>
        /// <param name="input">param is Review Object</param>
        /// <returns>AVG values of each  star </returns>
        public async Task<List<double>> GetAVGRating(Guid userId)
        {
            var getAVGRating = new GetEnrollmentById(userId);
            var onestar = 0;
            var twostar = 0;
            var threestar = 0;
            var fourstar = 0;
            var fivestar = 0;
            var total = 0;
            //get list course by id user
            IQueryable<Enrollment> getid = await _repository.ListReview<Enrollment>(getAVGRating);
            //count star of rating
            foreach (Enrollment x in getid)
            {
                onestar += x.Reviews.Where(s => s.Rating == 1).Count();
                twostar += x.Reviews.Where(s => s.Rating == 2).Count();
                threestar += x.Reviews.Where(s => s.Rating == 3).Count();
                fourstar += x.Reviews.Where(s => s.Rating == 4).Count();
                fivestar += x.Reviews.Where(s => s.Rating == 5).Count();
                
            }
            //sum count star of rating
            total = onestar + twostar + threestar + fourstar + fivestar;
            //return new list with values are AVG of star rating
            return new List<double> 
            { 
              onestar / total * 100, 
              twostar / total * 100, 
              threestar / total * 100, 
              fourstar / total * 100,
              fivestar / total * 100 
            };

        }

        public async Task<List<Enrollment>> GetEnrollmentId(Guid enrollmentId)
        {
            var getById = new GetEnrollmentById(enrollmentId);
            var items = await _repository.ListAsync<Enrollment>(getById);
            return items;
        }

    }
}
