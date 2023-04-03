namespace Kino.MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Viewing")]
    public partial class Viewing
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Viewing()
        {
            Tickets = new HashSet<Ticket>();
        }

        public Guid Id { get; set; }

        public Guid FilmId { get; set; }

        public TimeSpan StartsAt { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartsOn { get; set; }

        public virtual Film Film { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
