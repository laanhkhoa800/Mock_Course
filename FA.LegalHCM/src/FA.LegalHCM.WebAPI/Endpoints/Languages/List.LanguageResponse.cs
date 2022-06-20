using FA.LegalHCM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Languages
{
    public class LanguageResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public ICollection<Core.Entities.Course> Courses { get; set; }
    }
}
