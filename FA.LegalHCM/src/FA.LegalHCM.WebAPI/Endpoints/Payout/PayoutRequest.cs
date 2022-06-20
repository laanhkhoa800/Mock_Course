using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Payout
{
    public class PayoutRequest
    {
        public Guid Id { get; set; }

        public string Remark { get; set; }

        public string Status { get; set; }
    }
}
