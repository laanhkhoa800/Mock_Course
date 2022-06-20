using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.Endpoints.Notifications
{
    public class NewNotification
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Detail { get; set; }
        //Id receiver
        [Required]
        public Guid UserId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
