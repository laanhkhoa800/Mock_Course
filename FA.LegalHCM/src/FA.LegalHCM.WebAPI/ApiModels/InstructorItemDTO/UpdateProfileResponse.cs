using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.ApiModels.InstructorItemDTO
{
    public class UpdateProfileResponse
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; }
    }
}
