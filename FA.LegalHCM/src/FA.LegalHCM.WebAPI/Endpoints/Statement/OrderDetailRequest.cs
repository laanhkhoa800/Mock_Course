using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Statement
{
    public class OrderDetailRequest
    {
        public Guid UserId { get; set; }

        public Guid CourseId { get; set; }

        public decimal Price { get; set; }

        public DateTime PurchasedDay { get; set; }

        public string Type { get; set; }
    }
}
