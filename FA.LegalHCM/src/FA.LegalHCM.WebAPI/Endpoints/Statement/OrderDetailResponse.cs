using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Statement
{
    public class OrderDetailResponse
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }

        public Guid? PaymentToken { get; set; }

        public decimal Price { get; set; }

        public decimal TotalAmount { get; set; }

        public string Day { get; set; }
    }
}
