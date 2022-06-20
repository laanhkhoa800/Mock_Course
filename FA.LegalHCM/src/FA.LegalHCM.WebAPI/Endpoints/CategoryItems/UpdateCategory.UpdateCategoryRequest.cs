using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.CategoryItems.UpdateCategory
{
    public class UpdateToCategoryRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
