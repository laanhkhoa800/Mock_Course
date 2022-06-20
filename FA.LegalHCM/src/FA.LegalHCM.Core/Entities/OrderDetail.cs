using System;
using System.Collections.Generic;

namespace FA.LegalHCM.Core.Entities
{
    public class OrderDetail
    {
        public Guid UserId { get; set; }

        public Guid CourseId { get; set; }

        public decimal Price { get; set; }

        public DateTime PurchasedDay { get; set; }

        public string Type { get; set; }

        //Navigation properties
        public virtual User User { get; set; }

        public virtual Course Course { get; set; }
    }
}
