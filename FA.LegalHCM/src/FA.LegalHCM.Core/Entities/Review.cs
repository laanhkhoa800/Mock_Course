using FA.LegalHCM.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FA.LegalHCM.Core.Entities
{
    public class Review:BaseEntity
    {
        public Guid UserId { get; set; }

        public Guid EnrollmentId { get; set; }

        public string Content { get; set; }
        
        public int Rating { get; set; }

        public DateTime CreateAt { get; set; }

        public User User { get; set; }

        public Enrollment Enrollment { get; set; }

        
    }
}
