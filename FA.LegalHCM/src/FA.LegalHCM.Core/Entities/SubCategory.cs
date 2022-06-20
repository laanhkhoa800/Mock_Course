using FA.LegalHCM.Core.Entities;
using FA.LegalHCM.SharedKernel;
using System;
using System.Collections.Generic;

public class SubCategory : BaseEntity
{
    public string Name { get; set; }

    public bool Status { get; set; }

    public Guid CategoryId { get; set; }

    public bool IsDeleted { get; set; } = false;

    public DateTime CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    //Navigation properties
    public virtual Category Category { get; set; }

    public virtual ICollection<Course> Courses { get; set; }
}
