using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Earning
{
    public class ListEarningResponse
    {
       // public Guid Id { get; set; }

        public int ItemSalesCount { get; set; }

        public decimal Earning { get; set;  }

        public string Day { get; set; }

       
    }
}
