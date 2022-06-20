using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.ApiModels.InstructorItemDTO
{
    public class UpdateProfileRequest
    {
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
