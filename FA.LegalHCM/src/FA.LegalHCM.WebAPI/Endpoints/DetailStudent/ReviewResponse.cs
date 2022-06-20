using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.DetailStudent
{
    public class ReviewResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string URLImage { get; set; }

        public string Content { get; set; }

        public DateTime Create { get; set; }

        public byte Rating { get; set; }

    }
}
