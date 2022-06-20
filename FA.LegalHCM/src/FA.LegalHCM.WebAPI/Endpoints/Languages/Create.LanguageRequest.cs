using FA.LegalHCM.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Languages
{
    public class LanguageRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Status { get; set; }

    }
}
