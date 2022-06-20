using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.DetailStudent
{
    public class DetailStudentResponse
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public bool IsStatus { get; set; }

        public int CountSubcription { get; set; }
        
        public int CountEnroll { get; set; }
    }
}
