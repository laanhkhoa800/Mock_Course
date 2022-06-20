using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Courses
{
    public class UpdateCourseRequest
    {
        public Guid CourseId { get; set; }
        public Guid SubCategoryId { get; set; }
        public Guid PromotionId { get; set; }
        public Guid LanguageId { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal OriginPrice { get; set; }
        public string TrailerUrl { get; set; }
        public string Status { get; set; }
        public IFormFile Image { get; set; }
        public IFormFile Video { get; set; }
    }
}
