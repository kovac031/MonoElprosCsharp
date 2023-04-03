namespace Kino.MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        public Guid Id { get; set; }

        public DateTime PurchaseTime { get; set; }

        public Guid ViewingId { get; set; }

        public Guid SeatingId { get; set; }

        public Guid CustomerId { get; set; }

        public Guid PurchaseId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Revenue Revenue { get; set; }

        public virtual Seating Seating { get; set; }

        public virtual Viewing Viewing { get; set; }
    }
}
