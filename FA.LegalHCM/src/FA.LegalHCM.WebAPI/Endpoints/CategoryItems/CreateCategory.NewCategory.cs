using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.CategoryItems
{
    public class NewCategory
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
