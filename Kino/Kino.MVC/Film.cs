namespace Kino.MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Film")]
    public partial class Film
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Film()
        {
            Viewings = new HashSet<Viewing>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public int Release { get; set; }

        [StringLength(50)]
        public string Genre { get; set; }

        public int Duration { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Viewing> Viewings { get; set; }
    }
}
