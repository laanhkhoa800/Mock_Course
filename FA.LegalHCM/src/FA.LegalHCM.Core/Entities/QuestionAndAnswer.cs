using FA.LegalHCM.SharedKernel;
using System;

namespace FA.LegalHCM.Core.Entities
{
    public class QuestionAndAnswer : BaseEntity
    {
        public Guid CourseId { get; set; }

        public string Comment { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public bool IsDeleted { get; set; }

        public Guid? ParentId { get; set; }

        public Guid UserId { get; set; }

        //Navigation properties
        public virtual User User { get; set; }

        public virtual Course Course { get; set; }

        public virtual QuestionAndAnswer QuestionAnswer { get; set; }
    }
}
