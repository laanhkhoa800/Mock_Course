using FA.LegalHCM.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FA.LegalHCM.Core.Entities
{
    public class Language : BaseEntity
    {
        public string Name { get; set; }

        public string Status { get; set; }

        public ICollection<Course> Courses { get; set; }

    }
}
