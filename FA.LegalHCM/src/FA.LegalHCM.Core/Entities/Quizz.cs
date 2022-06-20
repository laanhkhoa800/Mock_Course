using FA.LegalHCM.SharedKernel;
using System;
using System.Collections.Generic;

namespace FA.LegalHCM.Core.Entities
{
    public class Quizz : BaseEntity
    {
        public Guid SectionId { get; set; }

        public bool IsPublished { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreateAt { get; set; }

        public string Title { get; set; }

        public decimal  PercentComplete { get; set; }

        //Navigation properties
        public virtual Section Section { get; set; }

        public virtual ICollection<QuizzCompletion> QuizzCompletions { get; set; }

        public virtual ICollection<QuizzQuestion> QuizzQuestions { get; set; }
    }
}
