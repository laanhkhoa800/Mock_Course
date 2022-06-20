using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Courses
{
    public class UpdateLessonRequest
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid SectionId { get; set; }
        public string Title { get; set; }
        public int TimeTotal { get; set; }
        public int Volume { get; set; }
        public int Duration { get; set; }
        public DateTime UpdateAt { get; set; }
        public IFormFile File { get; set; }
    }
}
