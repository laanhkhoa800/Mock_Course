using System;

namespace FA.LegalHCM.Core.Entities
{
    public class CourseCompletion
    {

        public Guid UserId { get; set; }

        public Guid CourseId { get; set; }

        public DateTime CompleteDate { get; set; }

        //Relationship properties
        public virtual Course Course { get; set; }

        public virtual User User { get; set; }
    }
}
