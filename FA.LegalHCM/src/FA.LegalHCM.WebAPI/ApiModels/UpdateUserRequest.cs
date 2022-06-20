using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.ApiModels
{
    public class UpdateUserRequest
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Rolename { get; set; }
    }
}
