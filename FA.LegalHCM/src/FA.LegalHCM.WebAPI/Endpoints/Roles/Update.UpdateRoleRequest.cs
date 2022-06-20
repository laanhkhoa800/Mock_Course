using FA.LegalHCM.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Roles
{
    public class UpdateRoleRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Guid> PermissionIds { get; set; }
    }
}
