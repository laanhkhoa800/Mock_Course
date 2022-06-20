using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.DetailStudent
{
    public class EnrollmentResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string InstructorName { get; set; }

        public Decimal Price { get; set; }

        public DateTime DateBuy { get; set; }
    }
}
