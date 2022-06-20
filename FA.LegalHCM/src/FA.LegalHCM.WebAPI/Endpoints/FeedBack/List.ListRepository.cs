using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.FeedBack
{
    public class ListRepository
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Content { get; set; }

        public string Document { get; set; }

        public DateTime CreateAt { get; set; }

    }
}
