using FA.LegalHCM.SharedKernel;
using System;
using System.Collections.Generic;

namespace FA.LegalHCM.Core.Entities
{
    public class QuizzAnswer : BaseEntity
    {
        public Guid QuestionId { get; set; }

        public string ResultDescription { get; set; }

        public string Content { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsCorrect { get; set; }

        //Navigation properties
        public virtual QuizzQuestion QuizzQuestion { get; set; }

        public virtual ICollection<UserQuizzAnswer> UserQuizzAnswers { get; set; }
    }
}
