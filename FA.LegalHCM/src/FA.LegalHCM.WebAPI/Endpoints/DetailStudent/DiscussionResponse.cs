using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.DetailStudent
{
    public class DiscussionResponse
    {
        public string UserName { get; set; }

        public string Comment { get; set; }

        public DateTime CreateAt { get; set; }

        public string Avatar { get; set; }

        public int Like { get; set; }

        public int DisLike { get; set; }
    }
}
