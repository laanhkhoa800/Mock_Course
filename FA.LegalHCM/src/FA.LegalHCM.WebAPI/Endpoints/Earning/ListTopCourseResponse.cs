using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Earning
{
    public class ListTopCourseResponse
    {
        public string Title { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }
    }
}
