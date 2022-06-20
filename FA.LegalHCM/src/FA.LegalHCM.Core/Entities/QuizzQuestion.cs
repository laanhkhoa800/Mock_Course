using FA.LegalHCM.SharedKernel;
using System;
using System.Collections.Generic;

namespace FA.LegalHCM.Core.Entities
{
    public class QuizzQuestion : BaseEntity
    {
        public Guid QuizzId { get; set; }

        public string HtmlContent { get; set; }

        public string Title { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsLastQuestion { get; set; }

        //Navigation properties
        public virtual Quizz Quizz { get; set; }

        public virtual ICollection<QuizzAnswer> QuizzAnswers { get; set; }
    }
}
