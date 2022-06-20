using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.ApiModels.InstructorItemDTO
{
    public class IntructorListReadDto
    {
        public string FistName { get; set; }

        public string LastName { get; set; }

        public DateTime? DOB { get; set; }

        public bool IsDeleted { get; set; }

        public string Email { get; set; }

    }
}
