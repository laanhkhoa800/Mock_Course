using FA.LegalHCM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FA.LegalHCM.Core.Interfaces
{
    public interface IReviewService
    {
        /// <summary>
        /// get list of all review
        /// </summary>
        /// <returns>List Review</returns>
        public Task<List<Review>> GetAllReviews(Guid userId);
        /// <summary>
        /// get avg of all rating
        /// </summary>
        /// <returns>List AVG Rating</returns>
        public Task<List<double>> GetAVGRating(Guid userId);
       
        /// <summary>
        /// Create new review
        /// </summary>
        /// <returns>new review object</returns>
        public Task<Review> CreateReview(Review review);
        /// <summary>
        /// get avag value of all raing
        /// </summary>
        /// <param name="userId">Param is Review Object</param>
        /// <returns>avg valu of all ratintg</returns>
        public Task<double> GetAllRating(Guid userId);
        public Task<List<Enrollment>> GetEnrollmentId(Guid enrollmentId);


    }
}
