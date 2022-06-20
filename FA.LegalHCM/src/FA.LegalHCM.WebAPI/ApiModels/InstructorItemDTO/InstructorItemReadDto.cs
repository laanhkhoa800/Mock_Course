using FA.LegalHCM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.LegalHCM.WebAPI.ApiModels.InstructorItemDTO
{
    public class InstructorItemReadDto
    {
        public string FistName { get; set; }

        public string LastName { get; set; }

        public bool IsDeleted { get; set; }

        public string FacebookLink { get; set; }

        public string LinkedLink { get; set; }

        public string YoutubeLink { get; set; }

        //Navigation properties
        public ICollection<Course> Courses { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }

        public ICollection<Discussion> Discussions { get; set; }

        public ICollection<Discussion> DiscussionSenders { get; set; }

        public ICollection<Subscription> Subscripers { get; set; }

    }
}
