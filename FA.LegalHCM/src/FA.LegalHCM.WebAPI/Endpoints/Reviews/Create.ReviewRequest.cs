using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Reviews
{
    public class ReviewRequest
    {
        [Range(1,5)]
        public int Rating { get; set; }

        [Required]
        [MaxLength(250)]
        public string Content { get; set; }

        [Required]
        public Guid EnrollmentId { get; set; }
    }
}

