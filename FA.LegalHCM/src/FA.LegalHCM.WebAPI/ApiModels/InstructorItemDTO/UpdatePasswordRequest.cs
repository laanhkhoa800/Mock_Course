using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.ApiModels.InstructorItemDTO
{
    public class UpdatePasswordRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string CurrentPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}
