using System;
using System.ComponentModel.DataAnnotations;

namespace FA.LegalHCM.WebAPI.Endpoints.Courses
{
    public class CourseRequest
    {
        [MaxLength(60), MinLength(10)]
        public string Title { get; set; }

        [MaxLength(120), MinLength(10)]
        public string SubTitle { get; set; }

        public string Description { get; set; }

        [Required]
        public Guid LanguageId { get; set; }

        [Required]
        public Guid SubCategoryId { get; set; }

        public Guid PromotionId { get; set; }

        [Required]
        public bool IsFree { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }
    }
}
