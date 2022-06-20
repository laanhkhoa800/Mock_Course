using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace FA.LegalHCM.Core.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public virtual ICollection<User> Users { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
