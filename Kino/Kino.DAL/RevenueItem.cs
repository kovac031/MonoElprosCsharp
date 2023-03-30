namespace Kino.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RevenueItem")]
    public partial class RevenueItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RevenueItem()
        {
            RevenueM2M = new HashSet<RevenueM2M>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ItemName { get; set; }

        [StringLength(50)]
        public string ItemSize { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RevenueM2M> RevenueM2M { get; set; }
    }
}
