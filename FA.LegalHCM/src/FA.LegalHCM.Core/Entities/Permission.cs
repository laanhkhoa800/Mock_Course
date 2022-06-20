using FA.LegalHCM.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FA.LegalHCM.Core.Entities
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
