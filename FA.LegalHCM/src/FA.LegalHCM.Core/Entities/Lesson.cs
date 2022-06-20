using FA.LegalHCM.SharedKernel;
using System;
using System.Collections.Generic;

namespace FA.LegalHCM.Core.Entities
{
    public class Lesson : BaseEntity
    {
        public Guid SectionId { get; set; }

        public string Title { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? UpdateAt { get; set; }

        public DateTime CreateAt { get; set; }

        public int Sort { get; set; }

        public string VideoUrl { get; set; }

        public int? TotalTime { get; set; }

        public float Duration { get; set; }

        public float Volume { get; set; }

        //Navigation properties
        public virtual Section Section { get; set; }

        public virtual ICollection<LessonCompletion> LessonCompletions { get; set; }
    }
}
