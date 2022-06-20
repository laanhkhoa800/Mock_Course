using FA.LegalHCM.SharedKernel;
using System;
using System.Collections.Generic;

namespace FA.LegalHCM.Core.Entities
{
    public class Section : BaseEntity
    {
        public Guid CourseId { get; set; }

        public int TotalTime { get; set; }

        public string Title { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsPublished { get; set; }

        //Navigation properties
        public virtual Course Course { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }

        public virtual ICollection<Quizz> Quizzes { get; set; }
    }
}
