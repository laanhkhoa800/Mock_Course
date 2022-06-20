using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Reviews
{
    public class ReviewsReponse
    {
        public Guid Id { get; set; }    

        public Guid UserId { get; set; }

        public Guid CoursesId { get; set; }

        public string Content { get; set; }

        public int Rating { get; set; }

        public DateTime CreateAt { get; set; }

    }
}
