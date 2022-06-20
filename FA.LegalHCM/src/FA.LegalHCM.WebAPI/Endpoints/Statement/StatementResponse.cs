using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Statement
{
    public class StatementResponse
    {
        public Guid UserId { get; set; }

        public Guid CourseId { get; set; }

        public string Date { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }

        public decimal Amount { get; set; }

        public decimal Fee { get; set; }


    }
}
