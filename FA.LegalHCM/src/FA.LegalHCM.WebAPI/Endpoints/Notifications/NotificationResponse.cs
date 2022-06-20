using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Notifications
{
    public class NotificationResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
