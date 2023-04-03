namespace Kino.MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Revenue")]
    public partial class Revenue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Revenue()
        {
            Tickets = new HashSet<Ticket>();
        }

        public Guid Id { get; set; }

        public DateTime PurchaseTime { get; set; }

        public int SingleCost { get; set; }

        public int Amount { get; set; }

        public int SumCost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
