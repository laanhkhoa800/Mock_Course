using Ardalis.ApiEndpoints;
using FA.LegalHCM.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.DetailStudent
{
    public class ListReview : BaseAsyncEndpoint
    {
        private readonly IStudentService _studentService;

        public ListReview(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("/DetailStudent/Review")]
        [SwaggerOperation(
           Summary = "get review list from student id ",
           Description = "get review list from student id",
           OperationId = "DetailStudent.Review",
           Tags = new[] { "DetailStudentEndpoints" })
       ]

        //get review list from student id 
        public async Task<ActionResult<List<ReviewResponse>>> GetAllReivewAsync(Guid id, CancellationToken cancellationToken)
        {
            //get the list of courses the student has purchased
            var items = (await _studentService.GetAllEnrollmentAsync(id));

            List<ReviewResponse> response = new List<ReviewResponse>();
            foreach(var item in items)
            {
                //get a list of reviews and ratings by id of the courses the student has purchased
                var itemReview = (await _studentService.GetcourseReviewAsync(item.Id));
                var itemRating = (await _studentService.GetcourseRatingAsync(item.Id));
                var allReview = new ReviewResponse();
                allReview.Id = item.Id;
                allReview.Title = item.Course.Title;
                allReview.URLImage = item.Course.ImageUrl;
                allReview.Content = itemReview.Content;
                allReview.Create = itemReview.CreateAt;
                allReview.Rating = itemRating.Rating;

                response.Add(allReview);
            }
                
            return Ok(response);
        }
    }
}
